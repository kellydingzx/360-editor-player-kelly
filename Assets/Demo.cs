using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Demo : MonoBehaviour
{
    public GameObject button;
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        window.SetActive(false);
    }

    // Update is called once per frame
  
    void OnClick()
    {
        window.SetActive(true);
    }
}
