using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoOnce : MonoBehaviour
{
    public UnityEvent OnCall;

    private int _callCount;

    public void Call()
    {
        if (_callCount++ < 1)
        {
            OnCall.Invoke();
        }
    }

    public void Reset()
    {
        _callCount = 0;
    }
}
