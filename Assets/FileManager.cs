using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Video;

public class FileManager : MonoBehaviour
{
    public string path;
    public GameObject inputpanel;
    public RawImage image;
    public GameObject url_display;
    public VideoPlayer videoPlayer;
    public GameObject url_video;

    public GameObject[] objs;

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Get photo.", "", "png");
        GetImage();
        url_display.GetComponent<Text>().text = path;
    }

    public void ChangeVideo()
    {
        string path = EditorUtility.OpenFilePanel("Change photo.", "", "mp4");
        videoPlayer.Stop();
        double prev_location = videoPlayer.time;
        videoPlayer.url = path;
        url_video.GetComponent<Text>().text = path;
        videoPlayer.Play();
        inputpanel.SetActive(false);
        //deactive all buttons from the previous video
        objs = GameObject.FindGameObjectsWithTag("Trigger");
        foreach (GameObject button in objs)
        {
            button.SetActive(false);
        }
    }

    public void BacktoPrev()
    {

    }

    void GetImage()
    {
        if(path != null)
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        WWW www = new WWW("file:///" + path);
        image.texture = www.texture;
    }

    public string getPhoto()
    {
        return path;
    }

    public void DeactivateAllButtons()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Trigger");

        foreach (GameObject button in objs)
        {

            button.SetActive(false);

            //button.interactable = false ;

        }

    }
}
