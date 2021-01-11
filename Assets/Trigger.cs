using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject plane;
    // Start is called before the first frame update
    void OnTrigger()
    {
        MeshRenderer m = plane.GetComponent<MeshRenderer>();
        m.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
