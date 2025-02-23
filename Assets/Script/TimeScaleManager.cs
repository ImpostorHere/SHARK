using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    public static TimeScaleManager Instance;
    public const float DEFAULT_TIME_SCALE = 1;
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeTimeScale(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }
    public void ResetTimeScale()
    {
        Time.timeScale = DEFAULT_TIME_SCALE;
    }
    public void HitStop(float duration)
    {
        StartCoroutine(HitstopCo(duration));
    }
    IEnumerator HitstopCo(float duration)
    {
        ChangeTimeScale(0);
        yield return new WaitForSecondsRealtime(duration);
        ResetTimeScale();
    }
}

