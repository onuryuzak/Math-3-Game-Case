using UnityEngine;


public class TimeManager : Singleton<TimeManager>
{
    public float defaultTimeScale = 1f;
    public float defaultFixedTimeStep = 0.02f;
    public float slowMotionTimeScale = 0.1f;
    public float fastMotionTimeScale = 1.75f;
    public bool updateFixedDeltaTime = true;
    public void DoSlowMotion() => SetTimeScale(slowMotionTimeScale);

    public void DoFastMotion() => SetTimeScale(fastMotionTimeScale);

    public void ResetTimeScale() => SetTimeScale(defaultTimeScale);

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        if (updateFixedDeltaTime)
            Time.fixedDeltaTime = Time.timeScale * defaultFixedTimeStep;
    }
}