using UnityEngine;
using UnityEngine.Events;

public class OnClickGameObjectListener : MonoBehaviour
{
    public UnityEvent OnMouseDownEvent;
    public UnityEvent OnMouseUpEvent;
    public UnityEvent OnMouseDragEvent;
    public UnityEvent OnMouseEnterEvent;
    public UnityEvent OnMouseExitEvent;
    public UnityEvent OnMouseOverEvent;
    public UnityEvent OnMouseUpAsButtonEvent;

    private void OnMouseDown() => OnMouseDownEvent?.Invoke();
    private void OnMouseUp() => OnMouseUpEvent?.Invoke();
    private void OnMouseDrag() => OnMouseDragEvent?.Invoke();
    private void OnMouseEnter() => OnMouseEnterEvent?.Invoke();
    private void OnMouseExit() => OnMouseExitEvent?.Invoke();
    private void OnMouseOver() => OnMouseOverEvent?.Invoke();
    private void OnMouseUpAsButton() => OnMouseUpAsButtonEvent?.Invoke();
}