using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectTask : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public XRSimpleInteractable interactable1;
    public XRSimpleInteractable interactable2;
    public TestState testState;

    private void OnEnable()
    {
        interactable1.enabled = true;
        interactable2.enabled = true;
    }

    private void Update()
    {
        if (!fire1.activeSelf && !fire2.activeSelf)
        {
            testState.ObjectTaskCheck();
            gameObject.SetActive(false);
        }
    }
}
