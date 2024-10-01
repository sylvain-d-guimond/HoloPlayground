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
        Target.TrackedHandedness = Handedness.Left;
    }

    public void SetRight()
    {
        Target.TrackedHandedness = Handedness.Right;
    }

    public void SetBoth()
    {
        Target.TrackedHandedness = Handedness.Both;
    }
}
