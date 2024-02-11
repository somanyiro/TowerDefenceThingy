using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = HealthManager.Instance.PlayerHealth;
    }
    
    private void Awake()
    {
        GameManager.Instance.SetupGame += OnSetupGame;
    }

    void OnSetupGame(object sender, EventArgs e)
    {
        slider = GetComponent<Slider>();
        slider.maxValue = HealthManager.Instance.maxPlayerHealth;
        GetComponent<RectTransform>().sizeDelta = new Vector2(19 * HealthManager.Instance.maxPlayerHealth / 2, 26);
        //this is based on the size of the texture that's filling the slider
    }
}
