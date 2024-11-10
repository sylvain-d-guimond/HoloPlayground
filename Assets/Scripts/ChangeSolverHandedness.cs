using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit;
using MixedReality.Toolkit.SpatialManipulation;

public class ChangeSolverHandedness : MonoBehaviour
{
    public SolverHandler Target;

    public void SetLeft()
    {
        if (Target != null) Target.TrackedHandedness = Handedness.Left;
    }

    public void SetRight()
    {
        if (Target != null) Target.TrackedHandedness = Handedness.Right;
    }

    public void SetBoth()
    {
        if (Target != null) Target.TrackedHandedness = Handedness.Both;
    }
}
