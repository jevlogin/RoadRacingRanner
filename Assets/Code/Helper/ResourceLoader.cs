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
    }
}