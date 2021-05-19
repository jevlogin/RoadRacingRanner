using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;
using UnityEngine.UI;


namespace JevLogin
{
    internal sealed class IAPManager : MonoBehaviour, IStoreListener
    {
        #region Fields

        [SerializeField] private Button _byButton;
        [SerializeField] private Button _restoreButton;

        private IStoreController _storeController;
        private IExtensionProvider _extensionProvider;

        private string _productId;
        private bool _isInitialized;

        #endregion


        #region ClassLifeCycles

        private void Awake()
        {
            if (Application.platform != RuntimePlatform.IPhonePlayer)
            {
                _restoreButton.gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            IAPConfigurationHelper.PopulateConfigurationBuilder(ref builder, ProductCatalog.LoadDefaultCatalog());

            _productId = "disable_ads";

            builder.AddProduct(_productId, ProductType.NonConsumable);
            UnityPurchasing.Initialize(this, builder);
        }

        private void OnEnable()
        {
            _byButton.onClick.AddListener(PurchaseNoAds);
        }

        private void OnDisable()
        {
            _byButton.onClick.RemoveListener(PurchaseNoAds);
        }

        #endregion


        #region IStoreListener

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log($"{error}");
            _isInitialized = false;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log($"{failureReason}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
#if UNITY_ANDROID || UNITY_IOS
            bool validPurchase = false;
            CrossPlatformValidator validator = new CrossPlatformValidator(GooglePlayTangle.Data(), AppleTangle.Data(), Application.identifier);
            try
            {
                IPurchaseReceipt[] result = validator.Validate(purchaseEvent.purchasedProduct.receipt);
                validPurchase = true;
                foreach (IPurchaseReceipt productReceipt in result)
                {
                    validPurchase &= productReceipt.purchaseDate == DateTime.UtcNow;
                }
            }
            catch (IAPSecurityException)
            {
                Debug.Log("Invalid receipt, not unlocking content");
                validPurchase = false;
            }
#endif

            var product = purchaseEvent.purchasedProduct;
            Debug.Log($"{product.metadata.localizedTitle}");

            StartCoroutine(DoPurchase(product));

            return PurchaseProcessingResult.Pending;
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extension)
        {
            _storeController = controller;
            _extensionProvider = extension;
            _isInitialized = true;

            foreach (Product product in controller.products.all)
            {
                Debug.Log($"{product.metadata.localizedTitle}");
            }
        } 

        #endregion


        #region Methods

        private void PurchaseNoAds()
        {
            if (!_isInitialized)
            {
                return;
            }
            _storeController.InitiatePurchase(_productId);
        }

        public string GetCost(string productId)
        {
            var product = _storeController.products.WithID(productId);

            if (product != null)
            {
                return product.metadata.localizedPriceString;
            }

            return "N/A";
        }
        public void RestorePurchase()
        {
            //  IAPButton
            //  IOS only
            if (!_isInitialized)
            {
                return;
            }

#if UNITY_IOS
            _extensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions((bool success) => { }); 
#else
            _extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions((bool success) => { });
#endif
        }

        private IEnumerator DoPurchase(Product product)
        {
            yield return new WaitForSeconds(1.0f);
            _storeController.ConfirmPendingPurchase(product);
        }

        #endregion
    }
}