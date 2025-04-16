using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Events;
using MixedReality.Toolkit;
using NaughtyAttributes;

public class FingerCharge : MonoBehaviour, IHandedComponent
{
    public VisualEffect Effect;
    public float DesiredAngle = 130f;
    public float MinLoadCharge = 0.7f;
    public float LoadDuration = 3f;

    public UnityEvent OnLoaded;
    public Handedness Hand { get => hand; set { hand = value; } }

    private bool charging;
    [SerializeField, ReadOnly] float load;
    private Handedness hand;


    private void OnEnable()
    {
        charging = true;
    }


    void Update()
    {
        if (charging)
        {
            var hand = HandManager.Instance;
            var angle = hand.FingerAngle(this.hand, Fingers.All);
            var charge = 1 - Mathf.Abs(DesiredAngle - angle) / DesiredAngle;
            //Debug.Log($"FingerCharge: Hand:{this.hand} angle:{angle} charge:{charge}");

            load = Mathf.Clamp01(load + (charge > MinLoadCharge ? 1 : -1) * (Time.deltaTime / LoadDuration));

            if (Mathf.Approximately(load, 1f))
            {
                load = 1f;
                charge = 1f;
                charging = false;
                if (DebugMode.instance.DebugLevel <= DebugLevels.Debug) Debug.Log($"Load from {gameObject.name} triggering {OnLoaded.GetPersistentEventCount()} events");
                OnLoaded.Invoke();
                if (DebugMode.instance.DebugLevel <= DebugLevels.Debug) Debug.Log("Loaded");
            }

            Effect.SetFloat("Load", load);
            Effect.SetFloat("Charge", charge);
        }
    }
}
