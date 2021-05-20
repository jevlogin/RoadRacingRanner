using System.Collections.Generic;

namespace JevLogin
{
    internal interface IAbilityRepository
    {
        IReadOnlyDictionary<int, IAbility> AbilityMapById { get; }
    }
}