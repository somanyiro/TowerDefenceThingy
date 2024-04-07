using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    public CanvasGroup waveStarter;
    public TextMeshProUGUI waveTimeText;
        
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.Subscribe(EventBus.EventType.WaveFinished, OnWaveFinished);
        EventBus.Instance.Subscribe(EventBus.EventType.WaveStarted, OnWaveStarted);
    }

    private void OnDestroy()
    {
        EventBus.Instance.Unsubscribe(EventBus.EventType.WaveFinished, OnWaveFinished);
        EventBus.Instance.Unsubscribe(EventBus.EventType.WaveStarted, OnWaveStarted);
    }

    // Update is called once per frame
    void Update()
    {
        waveTimeText.text = EnemyManager.Instance.TimeTillNextWave.ToString("0");
        waveCountText.text = $"Wave {EnemyManager.Instance.CurrentWave}";
    }

    public void StartWave()
    {
        EventBus.Instance.Trigger(EventBus.EventType.SkippedWavePreparation);
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
