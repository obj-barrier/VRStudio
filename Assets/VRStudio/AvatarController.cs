using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public TestState testState;

    private Vector3 storedPosition;
    private Quaternion storedRotation;
    private Vector3 storedScale;

    // Start is called before the first frame update
    void Start()
    {
        storedPosition = transform.position;
        storedRotation = transform.rotation;
        storedScale = transform.localScale;
    }

    public void ScaleUp()
    {
        transform.localScale *= 1.5f;
        if (Mathf.Abs(transform.localScale.x - 1f) < 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        testState.UpdateSize(transform.localScale.x);
    }

    public void ScaleDown()
    {
        transform.localScale /= 1.5f;
        if (Mathf.Abs(transform.localScale.x - 1f) < 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        testState.UpdateSize(transform.localScale.x);
    }

    public void ModeSwitch()
    {
        Vector3 tempPosition = transform.position;
        Quaternion tempRotation = transform.rotation;
        Vector3 tempScale = transform.localScale;
        transform.SetPositionAndRotation(storedPosition, storedRotation);
        transform.localScale = storedScale;
        storedPosition = tempPosition;
        storedRotation = tempRotation;
        storedScale = tempScale;
    }
}
