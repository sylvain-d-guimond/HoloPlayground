using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBasedOffset : MonoBehaviour
{
    [SerializeField] private Vector3 AndroidOffset;
    [SerializeField] private Vector3 UWPOffset;

    [SerializeField] private bool OverrideAndroid;
    [SerializeField] private bool OverrideUWP;

    private void Start()
    {
#if UNITY_ANDROID
#if UNITY_EDITOR
        if (!OverrideUWP)
#endif
            transform.position += AndroidOffset;
#endif

#if UNITY_WSA
#if UNITY_EDITOR
        if (!OverrideAndroid)
#endif
            transform.position += UWPOffset;
#endif

#if UNITY_EDITOR
        if (OverrideAndroid)
            transform.position += AndroidOffset;
        else if (OverrideUWP)
            transform.position += UWPOffset;
#endif
    }
}
