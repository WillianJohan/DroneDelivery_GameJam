using System;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] int TotalSeconds = 60;
    [SerializeField] TMP_Text SecondsDisplay;

    float ElapsedSeconds;
    bool IsStarded = false;

    public static event Action OnFinishedTime;

    private void Start()
    {
        //ButtonBehaviour.OnButtonDown += HandleButtonDown;
        OnFinishedTime += HandleFinishedTime;
        SecondsDisplay.text = "Seconds: " + TotalSeconds.ToString();
    }

    private void OnDestroy()
    {
        OnFinishedTime -= HandleFinishedTime;
    }

    void Update()
    {
        if (!IsStarded)
            return;

        ElapsedSeconds += Time.deltaTime;

        if (TotalSeconds < ElapsedSeconds)
            OnFinishedTime?.Invoke();
        else
            SecondsDisplay.text = (TotalSeconds - ElapsedSeconds).ToString().Substring(0, 4) + "s";
    }

    void HandleFinishedTime()
    {
        IsStarded = false;
        OnFinishedTime -= HandleFinishedTime;
        SecondsDisplay.text = "0";
    }

    public void StartCounter()
    {
        ElapsedSeconds = 0;
        IsStarded = true;
    }
}
