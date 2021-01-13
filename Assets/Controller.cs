using System.Collections;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Controller : MonoBehaviour
{
    //Public variables
    public VideoPlayer videoPlayer;
    public GameObject hotspot;
    public GameObject window;
    public GameObject id_display;
    public GameObject back_button;
    public GameObject start_time;

    //Private variables 
    private Hashtable all_hotspots;

    // Start is called before the first frame update
    void Start()
    {
        all_hotspots = new Hashtable();
        window.SetActive(false);
        back_button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,20));
            //Vector4 position = new Vector4(worldPosition.x, worldPosition.y, worldPosition.z, (float)videoPlayer.time);
            double start_time = videoPlayer.time;
            GameObject a = Instantiate(hotspot, worldPosition, transform.rotation);
            a.name = a.GetInstanceID().ToString();
            a.SetActive(true);
            all_hotspots.Add(a.name, new Hotspot(a, start_time,videoPlayer.length));
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f)){
                if(hit.transform.gameObject.tag == "Trigger")
                {
                    window.SetActive(true);
                    id_display.GetComponent<Text>().text = hit.transform.gameObject.GetInstanceID().ToString();
                    videoPlayer.Pause();
                }
            }
        }

        double current_time = videoPlayer.time;
        foreach(DictionaryEntry entry in all_hotspots)
        {
            Hotspot h = (Hotspot)entry.Value;
            if(h.getStart() >= current_time || h.getEnd() <= current_time)
            {
                h.getHotspot().SetActive(false);
            }
            else
            {
                h.getHotspot().SetActive(true);
            }
        }
    }

    public void closeWindow()
    {
        window.SetActive(false);
        videoPlayer.Play();
    }

    public void SetEndtime()
    {
        Hotspot a = (Hotspot)all_hotspots[id_display.GetComponent<Text>().text];
        a.SetEndTime(videoPlayer.time);
        //Debug.Log(a.getEnd());
    }

    class Hotspot
    {
        GameObject hotspot;
        double start_time;
        double end_time;

        public Hotspot(GameObject a, double start, double end)
        {
            this.hotspot = a;
            this.start_time = start;
            this.end_time = end;
        }

        public double getStart()
        {
            return start_time;
        }

        public double getEnd()
        {
            return end_time;
        }

        public GameObject getHotspot()
        {
            return hotspot;
        }

        public void SetEndTime(double endtime)
        {
            this.end_time = endtime;
        }

    }
}
