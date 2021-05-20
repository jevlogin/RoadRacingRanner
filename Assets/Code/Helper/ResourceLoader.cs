using System;
using UnityEngine;


namespace JevLogin
{
    internal static class ResourceLoader
    {
        internal static GameObject LoadPrefab(ResourcePath viewPath)
        {
            return Resources.Load<GameObject>(viewPath.PathResource);
        }

        internal static T LoadObject<T>(ResourcePath resourcePath) where T : Component
        {
            return Resources.Load<T>(resourcePath.PathResource);
        }
    }
}