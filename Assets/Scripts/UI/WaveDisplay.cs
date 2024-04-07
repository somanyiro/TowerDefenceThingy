using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the current wave and the time until the next wave.
/// There is also a button to start the next wave.
/// </summary>
public class WaveDisplay : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    public CanvasGroup waveStarter;
    public TextMeshProUGUI waveTimeText;
        
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe(EventBus.EventType.WaveFinished, OnWaveFinished);
        EventBus.Subscribe(EventBus.EventType.WaveStarted, OnWaveStarted);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(EventBus.EventType.WaveFinished, OnWaveFinished);
        EventBus.Unsubscribe(EventBus.EventType.WaveStarted, OnWaveStarted);
    }

    // Update is called once per frame
    void Update()
    {
        waveTimeText.text = EnemyManager.Instance.TimeTillNextWave.ToString("0");
        waveCountText.text = $"Wave {EnemyManager.Instance.CurrentWave}";
    }

    public void StartWave()
    {
        EventBus.Trigger(EventBus.EventType.SkippedWavePreparation);
        waveStarter.alpha = 0;
        waveStarter.interactable = false;
        waveStarter.blocksRaycasts = false;
    }

    public void OnWaveFinished(object isFinalWave)
    {
        if ((bool)isFinalWave) return;
        
        waveStarter.alpha = 1;
        waveStarter.interactable = true;
        waveStarter.blocksRaycasts = true;
    }

    public void OnWaveStarted(object data)
    {
        waveStarter.alpha = 0;
        waveStarter.interactable = false;
        waveStarter.blocksRaycasts = false;
    }
}
