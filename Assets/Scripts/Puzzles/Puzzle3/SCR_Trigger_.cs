using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Trigger_ : MonoBehaviour
{
    private Camera mainCamera;
    SCR_event_Lvl2 event2;

    void Start()
    {
        // Obtén la referencia a la cámara principal
        mainCamera = Camera.main;
        event2 = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_event_Lvl2>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(IsObjectVisible() == true)
        {
            event2.CambioDeEstado();
            transform.gameObject.SetActive(false);
        }
    }

    bool IsObjectVisible()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        // Obtiene el bounds del objeto con el tag especificado
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Puertas");
        foreach (GameObject obj in objectsWithTag)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                Bounds bounds = renderer.bounds;

                // Verifica si el bounds del objeto está dentro del frustum de la cámara
                if (GeometryUtility.TestPlanesAABB(planes, bounds))
                {
                    return true;
                }
            }
        }

        return false;
    }
}

