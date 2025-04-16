using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Transition : MonoBehaviour
{
    public float Smoothing;
    public float Delay;
    public Transform Target;

    [SerializeField]
    private float startTime;
    private ParentConstraint parentConstraint;

    private void Awake()
    {
        parentConstraint = GetComponent<ParentConstraint>();
    }

    private void OnEnable()
    {
        Set(Target);
    }
    public void Set(Transform parent)
    {
        //Debug.Log($"Transition, scale before:{transform.lossyScale}, {transform.lossyScale.x}");
        var scale = transform.lossyScale;
        //transform.SetGlobalScale(scale);
        //Debug.Log($"Transition, scale after:{transform.lossyScale}, {transform.lossyScale.x}");
        startTime = Time.time;
        //StartCoroutine(SetScale(scale));
    }

    IEnumerator SetScale(Vector3 scale)
    {
        yield return null;

        transform.SetGlobalScale(scale);
        Debug.Log($"Transition, scale after after:{transform.lossyScale}, {transform.lossyScale.x}");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (enabled)
        {
            if (Time.time > Delay + startTime)
            {
                parentConstraint.constraintActive = true;
                enabled = false;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime / Smoothing);
            }
        }

    }
}
