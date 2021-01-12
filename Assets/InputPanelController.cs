﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputPanelController : MonoBehaviour
{
    public GameObject nameinputField;
    public GameObject textInputField;
    public GameObject photoDisplay;

    public void ClickSave()
    {
        string name = nameinputField.GetComponent<InputField>().text;
        string text = textInputField.GetComponent<InputField>().text;
        string url = photoDisplay.GetComponent<Text>().text;

        Debug.Log(name);
        Debug.Log(text);
        Debug.Log(url);
    }




    public class Trigger{
        private string name;
        private string text;
        private string url_photo;
        private Vector3 location_for_hotspot;
        private float start_time;
        private float end_time;

        public void setNameAndText(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        public void setPhoto(string path)
        {
            this.url_photo = path;
        }

        public string getName()
        {
            return this.name;
        }

        public string getText()
        {
            return this.text;
        }

        public string getPhoto()
        {
            return this.url_photo;
        }
    }
}
