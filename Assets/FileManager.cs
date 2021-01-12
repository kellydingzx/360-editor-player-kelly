using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FileManager : MonoBehaviour
{
    public string path;
    public RawImage image;
    public GameObject url_display;

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Get photo.", "", "png");
        GetImage();
        url_display.GetComponent<Text>().text = path;
    }

    //public void ChangeVideo()
    //{
    //    string path 
    //}

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
