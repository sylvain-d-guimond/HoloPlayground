using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SolverHandler))]
public class SolverSwitcher : MonoBehaviour
{
    private SolverHandler handler;

    private void Awake()
    {
        handler = GetComponent<SolverHandler>();
    }
}
