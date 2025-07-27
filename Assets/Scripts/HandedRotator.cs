using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandedRotator : MonoBehaviour, IHandedComponent
{
    public Vector3 Angle;
    public bool SavePosition;

    private bool init;
    private Handedness current;
    private Quaternion startRotation;

    private void Awake()
    {
        startRotation = transform.localRotation;
    }

    public Handedness Hand { 
        get => hand; 
        set {
            if (value != current)
            {
                if (value == hand) transform.localRotation *= Quaternion.Euler(Angle);
                else if (SavePosition && init) transform.localRotation = startRotation;
                else if (init) transform.localRotation *= Quaternion.Euler(-Angle);
                current = value;
                init = true;
            }
        }
    }

    [SerializeField]
    private Handedness hand;
}
