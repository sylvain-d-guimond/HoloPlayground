using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGazeManager : MonoBehaviour
{
    public List<EyeGazeTarget> CurrentTargets;

    private IMixedRealityEyeGazeProvider _provider;
    private List<GameObject> _hitList = new List<GameObject>();

    private void Start()
    {
        _provider = CoreServices.InputSystem.EyeGazeProvider;
    }

    private void LateUpdate()
    {
        if (_provider != null && _provider.IsEyeTrackingEnabledAndValid)
        {
            _hitList.Clear();
            var hits = Physics.RaycastAll(_provider.LatestEyeGaze, 10f);

            foreach (var hit in hits)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("EyeTarget"))
                {
                    _hitList.Add(hit.transform.gameObject);
                }
            }

            //add
            foreach (var hit in _hitList)
            {
                var target = hit.GetComponent<EyeGazeTarget>();

                if (target != null && !CurrentTargets.Contains(target))
                {
                    CurrentTargets.Add(target);
                    target.OnEnter.Invoke();
                }
            }

            //remove
            foreach (var target in CurrentTargets)
            {
                if (!_hitList.Contains(target.gameObject))
                {
                    CurrentTargets.Remove(target);
                    target.OnExit.Invoke();
                }
            }
        }
    }

    public void Select()
    {
        foreach (var target in CurrentTargets)
        {
            target.OnSelect.Invoke();
        }
    }
}
