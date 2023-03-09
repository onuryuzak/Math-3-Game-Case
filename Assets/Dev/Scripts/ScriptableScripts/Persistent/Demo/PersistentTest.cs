using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PersistentSO
{
    public class PersistentTest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private PersistentIntVariable persistentIntVariable;

        private void Awake() => UpdateText();

        public void UpdateText() => text.text = persistentIntVariable.Value.ToString();

        public void Increase() => persistentIntVariable.Value++;

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}