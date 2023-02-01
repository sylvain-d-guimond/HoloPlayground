using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FingerZap : MonoBehaviour
{
    public AvgDistance Distance;
    public float TargetScale;
    public float TargetDistance = 0.09f;
    public Transform StartPosition;
    public Transform EndPosition;

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    public GameObject SpawnObject
    {
        get => _spawnObject;
        set => _spawnObject = value;
    }

    private GameObject _spawnObject;
    private bool _active;
    private Transform _effect;

    public GameObject Activate()
    {
        if (!_active)
        {
            OnActivate.Invoke();

            var effect = Instantiate(_spawnObject, StartPosition, false);
            effect.transform.localScale = Vector3.zero;
            _effect = effect.transform;

            _active = true;

            return effect;
        }

        return null;
    }

    public void Deactivate()
    {
        OnDeactivate.Invoke();
    }

    private void Update()
    {
        if (_active)
        {
            if (Distance.Distance > TargetDistance)
            {
                _effect.GetComponent<Transition>().Set(EndPosition);
                var magic = _effect.GetComponent<Magic>();
                magic.Appear();
                _effect.localScale = TargetScale * Vector3.one;
                _active = false;
                Deactivate();
            }

            _effect.localScale = Vector3.one * TargetScale * (TargetDistance - (TargetDistance - Distance.Distance)) / TargetDistance;
            //Debug.Log($"Scale:{_effect.localScale}");
        }
    }
}
