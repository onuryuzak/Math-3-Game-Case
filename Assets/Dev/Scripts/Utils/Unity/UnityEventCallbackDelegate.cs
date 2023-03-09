using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventCallbackDelegate : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool oneShot;
    [SerializeField] private bool hasDelay;
    [SerializeField] [ShowIf("hasDelay")] private float delay = 0.8f;

    [Header("Events")]
    [SerializeField] private UnityEvent OnInvoked;

    private bool didCall;
    
    public void Invoke()
    {
        if (oneShot && didCall)
            return;
        
        if (!gameObject.activeInHierarchy) 
            return;

        didCall = true;
        
        if (hasDelay)
            InvokeWithDelay();
        else
            OnInvoked?.Invoke();
    }

    private void InvokeWithDelay()
    {
        DOTween.Sequence().SetLink(gameObject)
            .AppendInterval(delay)
            .AppendCallback(() => OnInvoked?.Invoke());
    }
}