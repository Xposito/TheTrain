using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_cam_takePhoto : MonoBehaviour
{
    //[SerializeField] private GameObject cubo;
    //private Renderer renderCubo;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    renderCubo = cubo.GetComponent<Renderer>();
    //}

    //IEnumerator RecordFrame()
    //{
    //    yield return new WaitForEndOfFrame();
    //    var texture = ScreenCapture.CaptureScreenshotAsTexture();

    //    renderCubo.material.mainTexture = texture;
    //    // do something with texture

    //    //// cleanup
    //    //Object.Destroy(texture);
    //}

    //public void LateUpdate()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        StartCoroutine(RecordFrame());
    //    }


    //}
    bool m_Started;
    public LayerMask m_LayerMask;
    [SerializeField] float m_scale = 1;
    [SerializeField] float m_long = 1;
    [SerializeField] float m_distance = 1;

    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
    }

    void FixedUpdate()
    {
        MyCollisions();
    }

    void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position + new Vector3(0, 0,0 + m_distance), new Vector3(1,1 ,1 * m_long) * m_scale, Quaternion.identity, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(gameObject.transform.position + new Vector3(0,0,0 + m_distance), new Vector3(1 ,1,1 * m_long) * m_scale);
    }
}
