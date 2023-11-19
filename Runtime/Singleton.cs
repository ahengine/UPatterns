using UnityEngine;

namespace UPatterns
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static bool AutoCreate;
        private static T instance;
        public static T Instance => 
            instance ?? (AutoCreate ? (instance = new GameObject(typeof(T).Name).AddComponent<T>()) : null);
        public static void SetInstance(T value) =>
            instance = value;

        [SerializeField] protected bool isSingleton = true;

        protected virtual void Awake()
        {
            if (isSingleton)
                SetInstance(this as T);
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }
    }
}