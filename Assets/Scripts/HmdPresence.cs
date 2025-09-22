using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using System;

#if META_XR
using Meta.XR;
#endif

public class HmdPresence : MonoBehaviour
{
    public static HmdPresence Instance;
    public UnityEvent OnHeadsetWorn;
#if META_XR
    public OVRManager OVRManager;
#endif

    private bool? last;
    private bool hmdPresent;

    public HmdPresence()
    {
        Instance = this;
    }

#if META_XR
    private void OnEnable()
    {
        OVRManager.HMDMounted += OVRManager_HMDMounted;
        OVRManager.HMDUnmounted += OVRManager_HMDUnmounted;
    }

    private void OnDisable()
    {
        OVRManager.HMDMounted -= () => hmdPresent = true;
        OVRManager.HMDUnmounted -= () => hmdPresent = false;
    }

    private void OVRManager_HMDMounted()
    {
        hmdPresent = true;
    }

    private void OVRManager_HMDUnmounted()
    {
        hmdPresent = false;
    }

#endif
    void Update()
    {
#if !META_XR
        var hmd = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        if (hmd.isValid &&
            hmd.TryGetFeatureValue(CommonUsages.userPresence, out bool present) &&
            (!last.HasValue || hmdPresent != last.Value))
#else
        if (!last.HasValue || hmdPresent != last.Value)
#endif
        {
            if (hmdPresent) OnHeadsetWorn.Invoke();

            last = hmdPresent;
            Debug.Log($"[HMD Presence] HMD: {(hmdPresent ? "Present" : "Not present")}");
        }
    }
}