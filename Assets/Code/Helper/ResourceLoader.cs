using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    internal static class ResourceLoader
    {
        internal static GameObject LoadPrefab(ResourcePath viewPath)
        {
            return Resources.Load<GameObject>(viewPath.PathResource);
        }

        internal static T LoadObject<T>(ResourcePath resourcePath) where T : Object
        {
            return Resources.Load<T>(resourcePath.PathResource);
        }
    }
}