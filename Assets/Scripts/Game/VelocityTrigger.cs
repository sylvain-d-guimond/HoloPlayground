using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using MixedReality.Toolkit;
using NaughtyAttributes;

public class VelocityTrigger : MonoBehaviour, IHandedComponent
{
    public Transform Reference;
    public float Speed;
    public bool Active;
    public bool DeactivateOnTrigger = true;

    [SerializeField] private UnityEvent _onTrigger;

    private Vector3 _previousPosition;
    private bool _init;
    private Handedness _hand;

    [SerializeField, ReadOnly] private float _velocity, _maxVelocity;

    HandManager handManager => HandManager.Instance;

    public Handedness Hand { get => _hand; set => _hand = value; }

    Task _resetVelocity;

    private void Start()
    {
        _resetVelocity = ResetMaxVelocity();
    }

    private void OnDisable()
    {
        _init = false;
    }

    public void SetActive(bool active)
    {
        if (Active = active) _init = false;
    }

    private void FixedUpdate()
    {
        if (Active)
        {
            if (!handManager.IsHandTracked(_hand)) { _init = false; }

            if (_init)
            {
                var velocity = (Reference.position - _previousPosition).magnitude;
                if (velocity > Speed)
                {
                    _onTrigger.Invoke();
                    if (DeactivateOnTrigger) Active = false;
                }

                if (velocity > _maxVelocity) _maxVelocity = velocity;
            }
            else _init = true;
        }

        _velocity = (Reference.position - _previousPosition).magnitude;
        _previousPosition = Reference.position;

    }

    async Task ResetMaxVelocity()
    {
        while (Application.isPlaying)
        {
            await Task.Delay(5000);
            _maxVelocity = 0;
        }
    }
}
