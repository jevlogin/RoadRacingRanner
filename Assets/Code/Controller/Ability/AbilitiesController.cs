using JetBrains.Annotations;


namespace JevLogin
{
    internal sealed class AbilitiesController : BaseController
    {
        #region Fields
        
        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        #endregion


        #region ClassLifeCycles

        public AbilitiesController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IAbilityRepository abilityRepository,
            [NotNull] IAbilityCollectionView abilityCollectionView,
            [NotNull] IAbilityActivator abilityActivator)
        {
            _inventoryModel = inventoryModel ?? throw new System.ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new System.ArgumentNullException(nameof(abilityRepository));
            _abilityCollectionView = abilityCollectionView ?? throw new System.ArgumentNullException(nameof(abilityCollectionView));
            _abilityActivator = abilityActivator ?? throw new System.ArgumentNullException(nameof(abilityActivator));
        } 

        #endregion
    }
}