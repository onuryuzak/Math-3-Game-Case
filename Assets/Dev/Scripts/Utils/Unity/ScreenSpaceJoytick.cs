using System;
using NaughtyAttributes;
using UnityEngine;

public class ScreenSpaceJoytick : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [SerializeField] [Range(0.00001f, 1)] private float screenThresholdRatio = .5f;
    [SerializeField] [Range(0, 1)] private float minThreshold = .02f;
    [SerializeField] private bool useUnscaledDeltaTime;
    [SerializeField] private bool useSmoothInput;


    [ShowIf("useSmoothInput")] [SerializeField]
    private float xLerpSpeed = 5f;

    [ShowIf("useSmoothInput")] [SerializeField]
    private float yLerpSpeed = 5f;

    #endregion

    #region PRIVATE PROPERTIES

    private float _horizontal;
    private float _vertical;
    private float _screenXSize;
    private float _screenYSize;
    private bool _dragging;
    private float _startX;
    private float _startY;
    private float DeltaTime => useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;

    #endregion

    #region PUBLIC PROPERTIES

    public float Horizontal => _horizontal;
    public float Vertical => _vertical;
    public bool debug;

    #endregion

    #region UNITY METHODS

    private void Start() => Setup();

    private void Update() => UpdateAllData();

    #endregion

    #region PRIVATE METHODS

    private float ScaleInActualRatio(float value)
    {
        return value / screenThresholdRatio;
    }

    private void UpdateStartPositionX()
    {
        _startX = Input.mousePosition.x / _screenXSize;
    }

    private void UpdateStartPositionY()
    {
        _startY = Input.mousePosition.y / _screenYSize;
    }

    private void Setup()
    {
        _screenXSize = Screen.width;
        var heightScale = (float) Screen.height / Screen.width;
        _screenYSize = Screen.height / heightScale;
    }

    private void UpdateAllData()
    {
        HandleMouseDown();
        HandleMouseUp();
        HandleMouseDrag();

        var horizontalAbs = Math.Abs(_horizontal);
        var verticalAbs = Math.Abs(_vertical);

        if (horizontalAbs <= minThreshold)
            _horizontal = 0;

        if (verticalAbs <= minThreshold)
            _vertical = 0;

        if (debug)
            Debug.Log("hor : " + _horizontal + " , ver : " + _vertical);
    }

    private void HandleMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragging = true;
            UpdateStartPositionX();
            UpdateStartPositionY();
        }
    }

    private void HandleMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _dragging = false;
            _horizontal = 0;
            _vertical = 0;
        }
    }

    private void HandleMouseDrag()
    {
        if (_dragging)
        {
            if (Input.GetMouseButton(0))
            {
                var currentRatioX = Input.mousePosition.x / _screenXSize;
                var currentRatioY = Input.mousePosition.y / _screenYSize;

                var xDeltaRatio = currentRatioX - _startX;
                var yDeltaRatio = currentRatioY - _startY;

                var hor = ScaleInActualRatio(xDeltaRatio);
                var ver = ScaleInActualRatio(yDeltaRatio);

                if (useSmoothInput)
                {
                    _horizontal = Mathf.Lerp(_horizontal, hor, xLerpSpeed * DeltaTime);
                    _vertical = Mathf.Lerp(_vertical, ver, yLerpSpeed * DeltaTime);
                }
                else
                {
                    _horizontal = hor;
                    _vertical = ver;
                }

                _horizontal = Mathf.Clamp(_horizontal, -1, 1);
                _vertical = Mathf.Clamp(_vertical, -1, 1);

                UpdateStartPositionX();
                UpdateStartPositionY();
            }
        }
    }

    #endregion
}