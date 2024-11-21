using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewSchemeController : MonoBehaviour
{
    public InputActionReference scaleUpReference;
    public InputActionReference scaleDownReference;
    public InputActionReference modeSwitchReference;

    public AvatarController avatarController;
    public PhoneController phoneController;
    public MonitorController monitorController;

    public int mode = 1;
    public bool inTutorial = true;

    void OnEnable()
    {
        scaleUpReference.action.started += ToggleUp;
        scaleDownReference.action.started += ToggleDown;
    }

    void OnDisable()
    {
        scaleUpReference.action.started -= ToggleUp;
        scaleDownReference.action.started -= ToggleDown;
    }

    void ToggleUp(InputAction.CallbackContext context)
    {
        avatarController.ScaleUp();
    }

    void ToggleDown(InputAction.CallbackContext context)
    {
        avatarController.ScaleDown();
    }
}
