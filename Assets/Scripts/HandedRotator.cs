using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandedRotator : MonoBehaviour, IHandedComponent
{
    public Vector3 Angle;

    private bool init;
    private Handedness current;

    public Handedness Hand { 
        get => hand; 
        set {
            if (value != current)
            {
                if (value == hand) transform.rotation *= Quaternion.Euler(Angle);
                else if (init) transform.rotation *= Quaternion.Euler(-Angle);
                current = value;
                init = true;
            }
        }
    }

    [SerializeField]
    private Handedness hand;
}
