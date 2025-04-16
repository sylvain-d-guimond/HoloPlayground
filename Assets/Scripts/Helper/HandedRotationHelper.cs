using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hack - not reusable
public class HandedRotationHelper : MonoBehaviour, IHandedComponent
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Handedness Hand
    {
        get => hand;
        set
        {
            hand = value;
            if (hand == Handedness.Left)
            {
                transform.localPosition = leftPosition;
                transform.localRotation = leftRotation;
            }
            else if (hand == Handedness.Right)
            {
                transform.localPosition = Position;
                transform.localEulerAngles = Rotation;
            }
        }
    }

    [SerializeField] private Handedness hand;

    private Vector3 leftPosition;
    private Quaternion leftRotation;

    private void Start()
    {
        leftPosition = transform.localPosition;
        leftRotation = transform.localRotation;
    }
}
