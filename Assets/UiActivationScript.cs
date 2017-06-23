using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiActivationScript : MonoBehaviour
{
    public bool UiActive = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            UiActive = !UiActive;
        }

    }
    void OnGUI()
    {
        if (UiActive)
        {
            
        }
    }
}
