using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magic : MonoBehaviour
{
    public MagicType Type;
    public MagicStage Stage = MagicStage.Prepare;
    public UnityEvent OnActivate;
    public UnityEvent OnAppeared;
    public UnityEvent OnReady;
    public UnityEvent OnThrown;
    public UnityEvent OnCollision;
    public bool StaticInstance;

    private void OnEnable()
    {
        if (!StaticInstance)
            MagicManager.Instance.Add(this);
    }

    private void OnDisable()
    {
        if (!StaticInstance)
            MagicManager.Instance.Remove(this);
    }

    public void Activate()
    {
        OnActivate.Invoke();
    }

    public void Appear()
    {
        this.Stage = MagicStage.Prepare;
        OnAppeared.Invoke();
    }

    public void SetReady()
    {
        this.Stage = MagicStage.Ready;
        OnReady.Invoke();
    }

    public void Thrown()
    {
        this.Stage = MagicStage.Thrown;
        OnThrown.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        OnCollision.Invoke();
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (other.GetComponent<PracticeTarget>() != null)
        {
            Destroy(other.gameObject);
        }

        MagicManager.Instance.Explode(this);

        StartCoroutine(CoDelayedDestroy(0));
    }

    private IEnumerator CoDelayedDestroy(int delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}

public enum MagicStage
{
    Appear,
    Prepare,
    Ready,
    Thrown
}

public enum MagicType
{
    Lightning,
    Fire
}