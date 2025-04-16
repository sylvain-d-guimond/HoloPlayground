using MixedReality.Toolkit.UX;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetAnimPosition : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string animClip;
    [SerializeField] string animatorParam;

    public UnityEvent<float> OnCall;

    private void Start()
    {
        animator.Play(animClip);
    }

    [Button("Reset")]
    private void OnEnable()
    {
        animator.Play(animClip);
    }

    public void Call(float value)
    {
        OnCall.Invoke(value);

        animator.SetFloat(animatorParam, value);
    }

    public void Call(SliderEventData eventData)
    {
        Call(eventData.NewValue);
    }
}
