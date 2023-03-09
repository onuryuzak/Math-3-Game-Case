using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class LoadingUI : Singleton<LoadingUI>
{
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private float loadingDelay = 1f;
    [SerializeField] private bool freezeTimeOnDelay;

    public UnityEvent OnEnabled;
    public UnityEvent OnDisabled;

    public void OnLoadingStarted()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateLoading(true));
    }

    public void OnLoadingEnded()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateLoading(false));
    }

    private IEnumerator UpdateLoading(bool activate)
    {
        if (!activate)
        {
            if (freezeTimeOnDelay)
            {
                Time.timeScale = 0;
                yield return new WaitForSecondsRealtime(loadingDelay);
                Time.timeScale = 1;
            }
            else
            {
                yield return new WaitForSecondsRealtime(loadingDelay);
            }

            loadingPanel.SetActive(false);
            OnDisabled?.Invoke();
        }
        else
        {
            loadingPanel.SetActive(true);
            OnEnabled?.Invoke();
        }
    }
}