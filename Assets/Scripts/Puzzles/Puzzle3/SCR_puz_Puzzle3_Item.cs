using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle3_Item : MonoBehaviour
{
    public int itemNumber;

    [HideInInspector] public BoxCollider col;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public bool used;
    [HideInInspector] public MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        used = false;
        col = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }
}
