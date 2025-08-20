using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RadialView))]
public class AutoCenter : MonoBehaviour
{
    public float DelaySeconds = 1f;
    public bool CallOnHeadsetRemove;

    RadialView radialView;

    private void Awake()
    {
        radialView = GetComponent<RadialView>();
    }

    private void OnEnable()
    {
        HmdPresence.Instance.OnHeadsetWorn.AddListener(Call);
    }

    private void OnDisable()
    {
        HmdPresence.Instance.OnHeadsetWorn.RemoveListener(Call);
    }

    private void Start()
    {
        Call();
    }

    public void Call()
    {
        radialView.enabled = true;

        StartCoroutine(CoDeactivate());
    }

    private IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(DelaySeconds);

        radialView.enabled = false;
    }
}
