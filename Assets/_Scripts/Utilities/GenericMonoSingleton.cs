using UnityEngine;

namespace ServiceLocator.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private T instance;
        public T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if(instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

