
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Base.Management 
{
    public abstract class ManagerBase : MonoBehaviour 
    {
        [ReadOnly] public bool IsInitialized;
        public IEnumerator InitManager() 
        {
            yield return InitManagerProgress();
            IsInitialized = true;
        }
        protected abstract IEnumerator InitManagerProgress();

    }
}

