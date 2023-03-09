using UnityEngine;
using UnityEngine.Events;

public class InputDataListener : MonoBehaviour
{
    [SerializeField] private PlayerInputData inputData;

    public UnityEvent OnTapped;
    public UnityEvent OnReleased;

    private void OnEnable()
    {
        inputData.OnTapped.AddListener(OnTappedCallback);
        inputData.OnReleased.AddListener(OnReleasedCallback);
    }


    private void OnDisable()
    {
        inputData.OnTapped.RemoveListener(OnTappedCallback);
        inputData.OnReleased.RemoveListener(OnReleasedCallback);
    }

    protected virtual void OnTappedCallback()
    {
        OnTapped?.Invoke();
    }

    protected virtual void OnReleasedCallback()
    {
        OnReleased?.Invoke();
    }
}