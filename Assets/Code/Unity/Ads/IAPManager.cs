using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;


namespace JevLogin
{
    internal sealed class IAPManager : MonoBehaviour, IStoreListener
    {
        #region Fields

        [SerializeField] private Button _byButton;

        private IStoreController _storeController;
        private IExtensionProvider _extensionProvider;

        private string _productId; 

        #endregion


        #region ClassLifeCycles

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
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log($"{failureReason}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            var product = purchaseEvent.purchasedProduct;
            Debug.Log($"{product.metadata.localizedTitle}");

            StartCoroutine(DoPurchase(product));

            return PurchaseProcessingResult.Pending;
        }

        

        public void OnInitialized(IStoreController controller, IExtensionProvider extension)
        {
            _storeController = controller;
            _extensionProvider = extension;

            foreach (Product product in controller.products.all)
            {
                Debug.Log($"{product.metadata.localizedTitle}");
            }
        } 

        #endregion


        #region Methods

        private void PurchaseNoAds()
        {
            _storeController.InitiatePurchase(_productId);
        }

        public void RestorePurchase()
        {
            //  IAPButton
            //  IOS only
            _extensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions((bool success) => { });
        }

        private IEnumerator DoPurchase(Product product)
        {
            yield return new WaitForSeconds(1.0f);
            _storeController.ConfirmPendingPurchase(product);
        }

        #endregion
    }
}