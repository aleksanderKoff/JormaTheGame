using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCam : MonoBehaviour
{
    public GameObject Camera;
    public Transform cam;
    public float transitionDuration = 2.5f;

    private Vector3 targetPos;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            Camera.GetComponent<cameraController> ().enabled = false;
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = Camera.transform.position;
        targetPos = new Vector3(569.49f, -1.59f, -1f);
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            Camera.transform.position = Vector3.Lerp(startingPos, targetPos, t);
            yield return 0;
        }
    }
    
}
