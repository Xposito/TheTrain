using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioTag : MonoBehaviour
{
    public Tutorial tutorial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle2"))
        {

            other.gameObject.layer = 7;
            tutorial.CambioDeEstado();
            Collider collider = gameObject.GetComponent<Collider>();
            collider.enabled = false;

        }
    }

}
