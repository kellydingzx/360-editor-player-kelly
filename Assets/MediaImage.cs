using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaImage : MonoBehaviour
{
    public GameObject canvasImage;
    public Button hide;
    public Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        canvasImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasImage.activeSelf && Input.GetKeyDown(KeyCode.Escape)){
            HideImage();
        }
    }

    void ShowImage()
    {
        canvasImage.SetActive(true);
        //controller.DisplayMedia();
    }

    void HideImage()
    {
        canvasImage.SetActive(false);
        //controller.ReturnToSite();
    }

}
