using UnityEngine;

namespace Tools
{
    internal static class ResourceLoader
    {
        public static Sprite LoadSprite(ResourcePath path)
        {
            return Resources.Load<Sprite>(path.PathResource);
        }

        public static GameObject LoadPrefab(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.PathResource);
        }

        public static T LoadObject<T>(ResourcePath path) where T : Object
        {
            return Resources.Load<T>(path.PathResource);
        }
    }
}
