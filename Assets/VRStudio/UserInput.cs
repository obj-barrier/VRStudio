using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class UserInput : MonoBehaviour
{
    public GameObject oldScheme;
    public GameObject newScheme;

    public InputActionReference triggerPressReference;
    public InputActionReference modeSwitchReference;

    public AvatarController avatarController;
    public PhoneController phoneController;
    public MonitorController monitorController;
    public TestState testState;

    void OnEnable()
    {
        triggerPressReference.action.started += ToggleTake;
        modeSwitchReference.action.started += ToggleMode;
    }

    void OnDisable()
    {
        triggerPressReference.action.started -= ToggleTake;
        modeSwitchReference.action.started -= ToggleMode;
    }

    void ToggleTake(InputAction.CallbackContext context)
    {
        testState.PhotoTaskCheck();
    }

    void ToggleMode(InputAction.CallbackContext context)
    {
        testState.ModeSwitch();
        if (TestState.scheme == Scheme.Old)
        {
            oldScheme.SetActive(!oldScheme.activeSelf);
        }
        else
        {
            newScheme.SetActive(!newScheme.activeSelf);
            if (newScheme.activeSelf)
            {
                avatarController.ModeSwitch();
                phoneController.Attach();
            }
            else
            {
                phoneController.Detach();
                avatarController.ModeSwitch();
            }
            monitorController.ToggleActive();
        }
    }
}
