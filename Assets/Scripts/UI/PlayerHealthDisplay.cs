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
        slider = GetComponent<Slider>();
        slider.maxValue = GameManager.Instance.maxPlayerHealth;
        GetComponent<RectTransform>().sizeDelta = new Vector2(19 * GameManager.Instance.maxPlayerHealth / 2, 26); 
        //this is based on the size of the texture that's filling the slider
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.Instance.PlayerHealth;
    }
}
