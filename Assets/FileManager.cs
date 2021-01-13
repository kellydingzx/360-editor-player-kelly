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
    public GameObject back_button;

    //Variables for switching videos
    private GameObject[] objs;
    private List<GameObject> needs_back;
    private long location;
    private string url_old_video;

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Get photo.", "", "png");
        GetImage();
        url_display.GetComponent<Text>().text = path;
    }

    public void ChangeVideo()
    {
        string path = EditorUtility.OpenFilePanel("Change photo.", "", "mp4");
        //Record the old video;
        videoPlayer.Stop();
        location = videoPlayer.frame;
        url_old_video = videoPlayer.url;
        //Get new video and play
        videoPlayer.url = path;
        url_video.GetComponent<Text>().text = path;
        videoPlayer.Play();
        //Deactive all buttons from the previous video
        objs = GameObject.FindGameObjectsWithTag("Trigger");
        needs_back = new List<GameObject>();
        foreach (GameObject button in objs)
        {
            if (button.activeSelf)
            {
                needs_back.Add(button);
            }
            button.SetActive(false);
        }
        inputpanel.SetActive(false);
        back_button.SetActive(true);
    }

    public void BacktoPrevVideo()
    {
        videoPlayer.url = url_old_video;
        videoPlayer.frame = location;
        foreach(GameObject button in needs_back)
        {
            button.SetActive(true);
        }
        videoPlayer.Play();
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
}
