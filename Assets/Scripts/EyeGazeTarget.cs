using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EyeGazeTarget : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public UnityEvent OnSelect;

    public void Enter()
    {
        OnEnter.Invoke();
    }

    public void Exit()
    {
        OnExit.Invoke();
    }

    public void Select()
    {
        OnSelect.Invoke();
    }
}
