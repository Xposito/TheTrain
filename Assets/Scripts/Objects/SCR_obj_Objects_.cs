using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_obj_Objects_ : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;

    public Material material1;
    public Material material2;

    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material1;
    }

    private void Update()
    {
        if (!playerOptions.usingCam)
        {
            changeMaterial1();
        }

        if (playerOptions.usingCam)
        {
            changeMaterial2();
        }
    }

    public void changeMaterial1()
    {
        meshRenderer.material = material1;
    }

    public void changeMaterial2()
    {
        meshRenderer.material = material2;
    }
}
