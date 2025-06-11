using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnActivate : MonoBehaviour
{
    public Vector3 Angle;

    private void OnEnable()
    {
        transform.rotation *= Quaternion.Euler(Angle);
    }

    private void OnDisable()
    {
        transform.rotation *= Quaternion.Euler(-Angle);
    }
}
