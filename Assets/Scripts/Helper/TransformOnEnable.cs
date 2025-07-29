using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformOnEnable : MonoBehaviour
{
    public Vector3 Position;

    private void OnEnable()
    {
        transform.position += Position;
    }

    private void OnDisable()
    {
        transform.position -= Position;
    }
}
