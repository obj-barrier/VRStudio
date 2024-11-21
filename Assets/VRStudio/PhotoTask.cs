using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTask : MonoBehaviour
{
    private int enableTime;

    private void OnEnable()
    {
        enableTime = Time.frameCount;
    }

    private void Update()
    {
        if (Time.frameCount == enableTime + 1)
        {
            GetComponent<Camera>().enabled = false;
        }
    }
}
