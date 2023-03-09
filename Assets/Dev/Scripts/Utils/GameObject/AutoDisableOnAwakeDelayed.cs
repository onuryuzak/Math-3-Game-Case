using System.Collections;

namespace UnityEngine.MonoUtils
{
    public class AutoDisableOnAwakeDelayed : MonoBehaviour
    {
        [SerializeField] private float delay = 1.5f;
        private void Awake() => StartCoroutine(DisableDelayed());

        private IEnumerator DisableDelayed()
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
        }
    }
}