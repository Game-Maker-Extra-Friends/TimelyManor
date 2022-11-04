using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private bool IsRotatingDoor = true;
    [SerializeField]
    private float Speed = 1f;
    [Header("Rotation Configs")]
    [SerializeField]
    private float RotationAmount = 90f;
    [SerializeField]
    private float ForwardDirection = 0;

    private Vector3 StartRotation;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        // Forward = right since sliding door should slide which will be on the Z axis of the door.
        Forward = transform.right;
    }

    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (IsRotatingDoor)
            {
                // Determine whether player is in front or behind the door so it can open inward or outward.
                float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
                Debug.Log($"Dot: {dot.ToString("N3")}");
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
                Debug.Log("The dot number is: " + dot);
            }
        }
    }


    private IEnumerator DoRotationOpen(float ForwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        // Open the door in the direction depending on where the player is.
        if(ForwardAmount >= ForwardDirection)
        {

            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y + RotationAmount, 0));
            Debug.Log("Door open Forward");
        }
        else
        {
            
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y - RotationAmount, 0));
            Debug.Log("Door open backward");
        }

        IsOpen = true;

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            // Speed to edit door opening speed.
            time += Time.deltaTime * Speed;
        }
    }


    public void Close()
    {
        if (IsOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (IsRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }


    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        // End is start this time
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        IsOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            // Speed to edit door opening speed.
            time += Time.deltaTime * Speed;
        }
    }
}
