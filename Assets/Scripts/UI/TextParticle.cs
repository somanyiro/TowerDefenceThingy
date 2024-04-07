using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextParticle : MonoBehaviour
{
    private Camera playerCamera;
    public TextMeshProUGUI textMeshPro;
    public Image image;
    public Canvas canvas;
    public float risingSpeed = 10;
    public float lifeTime = 1;
    
    public void Setup(string textToDisplay, bool showMoneyIcon, Color textColor)
    {
        textMeshPro.text = textToDisplay;
        textMeshPro.color = textColor;
        if (showMoneyIcon)
            image.enabled = true;
        else
            image.enabled = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;

        IEnumerator coroutine = DestroySelfIn(lifeTime);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.rotation =
            Quaternion.LookRotation(transform.position - playerCamera.transform.position);
        transform.Translate(Vector3.up * risingSpeed * Time.deltaTime);
    }

    IEnumerator DestroySelfIn(float time)
    {
        yield return new WaitForSeconds (time);
        Destroy(gameObject);
    }
    
}
