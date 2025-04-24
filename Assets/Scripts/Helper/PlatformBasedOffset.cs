using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBasedOffset : MonoBehaviour
{
    [SerializeField] private Vector3 AndroidOffset;
    [SerializeField] private Vector2 UWPOffset;

    private void Start()
    {
#if UNITY_ANDROID
        transform.position += AndroidOffset;
#endif

#if UNITY_WSA
        transform.position += UWPOffset;
#endif
    }
}
