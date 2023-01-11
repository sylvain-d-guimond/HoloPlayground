using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEyeGaze : MonoBehaviour
{
    public bool IsEyeTrackingEnabled;
    public bool IsEyeTrackingDataValid;

    // Update is called once per frame
    void Update()
    {
        IsEyeTrackingEnabled = CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabled;
        IsEyeTrackingDataValid = CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid;
    }
}
