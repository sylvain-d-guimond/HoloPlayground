using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FingerZap : MonoBehaviour
{
    public AvgDistance Distance;
    public HandednessSwitcher HandednessSwitcher;
    public float TargetScale;
    public float TargetDistance = 0.09f;
    public Transform StartPosition;
    public Transform EndPosition;
    public Transform Room;

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;
    public UnityEvent OnAppear;

    public GameObject SpawnObject
    {
        get => _spawnObject;
        set => _spawnObject = value;
    }

    private GameObject _spawnObject;
    private bool _active;
    private Transform _effect;
    private int _spawnCount;

    private void OnEnable()
    {
        Spawn();
    }
    public GameObject Spawn()
    {
        if (_spawnObject != null)
        {
            OnActivate.Invoke();

            Debug.Log($"Spawn {_spawnObject} {_spawnCount++}");
            var effect = Instantiate(_spawnObject, StartPosition, false);
            effect.transform.localScale = Vector3.zero;
            _effect = effect.transform;

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
        if (Distance.Distance > TargetDistance)
        {
            _effect.GetComponent<Transition>().Set(EndPosition);
            var magic = _effect.GetComponent<Magic>();
            magic.Appear();
            magic.HandednessSwitcher.Handedness = HandednessSwitcher.Handedness;
            _effect.localScale = TargetScale * Vector3.one;
            _effect.SetParent(Room, true);
            Deactivate();
            OnAppear.Invoke();
            gameObject.SetActive(false);
            Debug.Log($"Distance: {Distance.Distance}");
        }

        _effect.localScale = Vector3.one * TargetScale * (TargetDistance - (TargetDistance - Distance.Distance)) / TargetDistance;
        //Debug.Log($"Scale:{_effect.localScale}");
    }
}
