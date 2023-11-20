using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_pla_Album : MonoBehaviour
{

    public GameObject album;
    bool open = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            open = !open;
            if (open)
            {
                album.SetActive(true);
            }
            else { album.SetActive(false); }
        }
    }
}
