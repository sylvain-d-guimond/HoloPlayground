using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSolverHandedness : MonoBehaviour
{
    public SolverHandler Target;

    public void SetLeft()
    {
        Target.TrackedHandedness = Microsoft.MixedReality.Toolkit.Utilities.Handedness.Left;
    }

    public void SetRight()
    {
        Target.TrackedHandedness = Microsoft.MixedReality.Toolkit.Utilities.Handedness.Right;
    }

    public void SetBoth()
    {
        Target.TrackedHandedness = Microsoft.MixedReality.Toolkit.Utilities.Handedness.Both;
    }
}
