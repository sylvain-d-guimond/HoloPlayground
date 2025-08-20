using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class HmdPresence : MonoBehaviour
{
    public static HmdPresence Instance;
    public UnityEvent OnHeadsetWorn;

    private bool? last;

    public HmdPresence()
    {
        Instance = this;
    }

    void Update()
    {
        var hmd = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        if (hmd.isValid &&
            hmd.TryGetFeatureValue(CommonUsages.userPresence, out bool present) &&
            (!last.HasValue || present != last.Value))
        {
            if (present) OnHeadsetWorn.Invoke();

            last = present;
            //Debug.Log($"[TEST] HMD: {(present ? "Present" : "Not present")}");
        }
    }
}