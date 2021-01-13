using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Controller : MonoBehaviour
{
    //Public variables
    public VideoPlayer videoPlayer;
    public GameObject hotspot;
    public GameObject window;
    //Private variables 
    
   
    // Start is called before the first frame update
    void Start()
    {
        window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,20));
            //Vector4 position = new Vector4(worldPosition.x, worldPosition.y, worldPosition.z, (float)videoPlayer.time);
            GameObject a = Instantiate(hotspot, worldPosition, transform.rotation);
            a.name = "first";
            a.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f)){
                if(hit.transform.gameObject.tag == "Trigger")
                {
                    window.SetActive(true);
                }
            }
        }
    }

    public void closeWindow()
    {
        window.SetActive(false);
    }

}
