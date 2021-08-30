using UnityEngine;

namespace Com.SoulSki.Common
{
    /// <summary>
    /// Ensure there is only one ScriptableObject used - good for manager classes
    /// Code by First Gear Games
    /// https://www.youtube.com/watch?v=cH-QQoNNpaI
    /// </summary>
    /// <typeparam name="T">The class that is derived from this type</typeparam>
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    T[] results = Resources.FindObjectsOfTypeAll<T>();
                    if(results.Length == 0)
                    {
                        Debug.LogErrorFormat("There are no SingletonScriptableObjects of type {0}", typeof(T).ToString());
                        return null;
                    }
                    if(results.Length > 1)
                    {
                        Debug.LogErrorFormat("There are more than one SingletonScriptableObjects of type {0}", typeof(T).ToString());
                        return null;
                    }

                    _instance = results[0];
                    _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                }
                return _instance;
            }
        }
    }
}