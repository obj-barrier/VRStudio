using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public Transform avatarTransform;
    public TestState testFlowController;
    public GameObject newScheme;

    // Update is called once per frame
    void Update()
    {
        if (newScheme.activeSelf)
        {
            if (transform.parent == null)
            {
                transform.localScale = avatarTransform.localScale;
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
    }

    public void Attach()
    {
        transform.SetParent(avatarTransform);
    }

    public void Detach()
    {
        transform.SetParent(null);
    }
}
