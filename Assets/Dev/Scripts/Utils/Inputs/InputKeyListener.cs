using UnityEngine;
using UnityEngine.Events;

public class InputKeyListener : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    public UnityEvent OnInputKey;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode)) OnInputKey.Invoke();
    }
}