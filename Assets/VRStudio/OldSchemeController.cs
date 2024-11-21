using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class OldSchemeController : MonoBehaviour
{
    public DynamicMoveProvider phoneMove;
    public ActionBasedSnapTurnProvider phoneTurn;
    public GameObject teleportation;
    public Transform phone;

    public float droneTurnSpeed;

    private float droneMoveSpeed;
    private Vector3 hMove;
    private Vector3 vMove;
    private Quaternion yaw = Quaternion.identity;
    private Quaternion pitch = Quaternion.identity;
    private Quaternion roll = Quaternion.identity;

    void OnEnable()
    {
        droneMoveSpeed = phoneMove.moveSpeed;
        phoneMove.moveSpeed = 0f;
        phoneTurn.enableTurnLeftRight = false;
        phoneTurn.enableTurnAround = false;
        teleportation.SetActive(false);
        phone.SetParent(null);
    }

    private void OnDisable()
    {
        phoneMove.moveSpeed = droneMoveSpeed;
        phoneTurn.enableTurnLeftRight = true;
        phoneTurn.enableTurnAround = true;
        teleportation.SetActive(true);
    }

    void OnHorizontalMove(InputValue value)
    {
        hMove = value.Get<Vector2>();
    }

    void OnVerticalMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
        {
            vMove = new Vector3(0f, 0f, input.y);
        }
        else
        {
            vMove = Vector3.zero;
        }
    }

    void OnYaw(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            yaw = Quaternion.AngleAxis(input.x, Vector3.forward);
        }
        else
        {
            yaw = Quaternion.identity;
        }
    }

    void OnPitch(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
        {
            pitch = Quaternion.AngleAxis(input.y, Vector3.right);
        }
        else
        {
            pitch = Quaternion.identity;
        }
    }

    void OnRoll(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            roll = Quaternion.AngleAxis(input.x, Vector3.up);
        }
        else
        {
            roll = Quaternion.identity;
        }
    }

    void Update()
    {
        if (!pitch.Equals(Quaternion.identity))
        {
            vMove = Vector3.zero;
        }
        if (!roll.Equals(Quaternion.identity))
        {
            hMove = Vector3.zero;
        }

        phone.Translate((hMove + vMove) * Time.deltaTime * droneMoveSpeed, Space.Self);
        phone.rotation = Quaternion.Slerp(phone.rotation, phone.rotation * yaw * pitch * roll, Time.deltaTime * droneTurnSpeed);
    }
}
