using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(ParentConstraint))]
public class ParentConstraintHelper : MonoBehaviour
{
    private ParentConstraint parentConstraint;

    private void Awake()
    {
        parentConstraint = GetComponent<ParentConstraint>();
    }

    public void LockSourceRotation(bool x, bool y, bool z)
    {
        Axis axis = Axis.None;
        if (x) axis |= Axis.X;
        if (y) axis |= Axis.Y;
        if (z) axis |= Axis.Z;

        parentConstraint.rotationAxis = axis;
    }

    public void LockZRotation(bool z)
    {
        StartCoroutine(CoLockZRotation(z));
    }

    private IEnumerator CoLockZRotation(bool z)
    {
        yield return new WaitForEndOfFrame();

        if (!z) 
            parentConstraint.rotationAxis |= Axis.Z;
        else 
            parentConstraint.rotationAxis &= (Axis.X | Axis.Y);
    }
}
