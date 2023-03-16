using System.Collections;
using DG.Tweening;
using Base.Core.GameStates;
using Base.Core.LevelSystem;
using UnityEngine;


public class GameMenu : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private GameStateEvents gameStateEvents;

    [SerializeField] private GameObject winPanel;

    [SerializeField] private float winPanelOpenDelay = 2.5f;
    [SerializeField] private float winPanelOpenDuration = .7f;

    #endregion

    #region PRIVATE FIELDS

    private GameObject _activePanel;
    private bool _gameFinished;

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        gameStateEvents.OnWin.AddListener(OnGameWin);
    }

    private void OnDisable()
    {
        gameStateEvents.OnWin.RemoveListener(OnGameWin);
    }

    #endregion

    #region PUBLIC METHODS

    public void LoadNextLevel() => levelSystem.LoadNextLevel();

    public void RestartLevel() => levelSystem.RestartLevel();

    #endregion

    #region PRIVATE METHODS

    private IEnumerator OpenPanelDelayed(GameObject panel, float delay, float duration)
    {
        yield return new WaitForSecondsRealtime(delay);
        OpenPanel(panel, duration);
    }

    private void OpenPanel(GameObject panel, float duration)
    {
        if (_activePanel)
            _activePanel.SetActive(false);

        _activePanel = panel;
        _activePanel.SetActive(true);
        AnimatePanel(_activePanel.transform, duration);
    }

    private void AnimatePanel(Transform panel, float duration)
    {
        panel.localScale = Vector3.right;
        panel.DOScale(Vector3.one, duration).SetEase(Ease.OutElastic).SetUpdate(true);
    }

    #endregion

    #region CALLBACK METHODS

    private void OnGameWin()
    {
        if (_gameFinished)
            return;
        _gameFinished = true;
        StartCoroutine(OpenPanelDelayed(winPanel, winPanelOpenDelay, winPanelOpenDuration));
    }

    #endregion
}