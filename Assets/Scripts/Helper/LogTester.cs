using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTester : MonoBehaviour
{
    [Button]
    public void Call(string message)
    {
        Debug.Log(message);
    }
}
