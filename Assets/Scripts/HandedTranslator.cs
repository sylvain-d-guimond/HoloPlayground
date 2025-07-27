using MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandedTranslator : MonoBehaviour, IHandedComponent
{
    public Vector3 Offset;

    private bool init;
    private Handedness current;

    public Handedness Hand { 
        get => hand; 
        set {
            if (value != current)
            {
                if (value == hand) transform.localPosition += Offset;
                else if (init) transform.localPosition -= Offset;
                current = value;
                init = true;
            }
        }
    }

    [SerializeField]
    private Handedness hand;
}
