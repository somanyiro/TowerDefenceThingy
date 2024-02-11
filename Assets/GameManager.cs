using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public delegate void SetupGameEventHandler(object sender, EventArgs e);
    public event SetupGameEventHandler SetupGame;
    
    // Start is called before the first frame update
    void Start()
    {
        OnSetupGame(EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance is not null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    protected virtual void OnSetupGame(EventArgs e)
    {
        SetupGameEventHandler handler = SetupGame;
        handler?.Invoke(this, e);
    }
}
