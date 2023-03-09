using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MaskTransition : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private Image image;
    [SerializeField] private float outsideToInsideDuration = .5f;
    [SerializeField] private Ease outsideToInsideEase;
    [SerializeField] private float insideToOutsideDuration = .5f;
    [SerializeField] private Ease insideToOutsideEase;

    #endregion

    #region PUBLIC EVENTS

    public UnityEvent OnAnimateToInsideCompleted;
    public UnityEvent OnAnimateToOutsideCompleted;

    #endregion

    #region PRIVATE FIELDS

    private Material material;
    private static readonly int Progress = Shader.PropertyToID("_Progress");

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        material = Instantiate(image.material);
        image.material = material;
    }

    #endregion

    #region PUBLIC METHODS

    public void AnimateToInside() => AnimateProgress(1, outsideToInsideDuration, outsideToInsideEase)
        .OnComplete(() => OnAnimateToInsideCompleted?.Invoke());

    public void AnimateToOutside() => AnimateProgress(0, insideToOutsideDuration, insideToOutsideEase)
        .OnComplete(() => OnAnimateToOutsideCompleted?.Invoke());

    #endregion

    #region PRIVATE METHODS

    private Tween AnimateProgress(float progress, float duration, Ease ease = Ease.Unset)
    {
        return DOTween.To(
            () => material.GetFloat(Progress),
            value => material.SetFloat(Progress, value),
            progress,
            duration).SetEase(ease);
    }

    #endregion
}