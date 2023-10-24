using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour
{
    [SerializeField] private GameObject cubo;
    private Renderer renderCubo;
    // Start is called before the first frame update
    void Start()
    {
        renderCubo = cubo.GetComponent<Renderer>();
    }

    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();

        renderCubo.material.mainTexture = texture;
        // do something with texture

        //// cleanup
        //Object.Destroy(texture);
    }

    public void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(RecordFrame());
        }


    }
}
