using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Channel/TimeScaleSetter", fileName = "TimeScaleSetter")]
public class TimeScaleSetter : ScriptableObject
{
    [SerializeField] private float defaultTimeScale = 1f;
    [SerializeField] private float defaultFixedTimeStep = 0.02f;
    [SerializeField] private bool updateFixedDeltaTime = true;

    public void ResetTimeScale() => SetTimeScale(defaultTimeScale);

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        if (updateFixedDeltaTime)
            Time.fixedDeltaTime = Time.timeScale * defaultFixedTimeStep;
    }
}