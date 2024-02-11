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
        EnemyManager.Instance.WaveFinished += OnWaveFinished;
        EnemyManager.Instance.WaveStarted += OnWaveStarted;
    }

    // Update is called once per frame
    void Update()
    {
        waveTimeText.text = EnemyManager.Instance.TimeTillNextWave.ToString("0");
        waveCountText.text = $"Wave {EnemyManager.Instance.CurrentWave}";
    }

    public void StartWave()
    {
        EnemyManager.Instance.SkipWavePreperation();
        waveStarter.alpha = 0;
        waveStarter.interactable = false;
        waveStarter.blocksRaycasts = false;
    }

    public void OnWaveFinished(object sender, EventArgs e)
    {
        waveStarter.alpha = 1;
        waveStarter.interactable = true;
        waveStarter.blocksRaycasts = true;
    }

    public void OnWaveStarted(object sender, EventArgs e)
    {
        waveStarter.alpha = 0;
        waveStarter.interactable = false;
        waveStarter.blocksRaycasts = false;
    }
}
