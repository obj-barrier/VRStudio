using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefSphereController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        meshRenderer.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        meshRenderer.enabled = true;
    }
}
