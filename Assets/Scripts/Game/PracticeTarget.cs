using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PracticeTarget : MonoBehaviour
{
    public bool Skip { get; set; }
    public UnityEvent OnSpawn;
    public UnityEvent OnHit;

    private void OnEnable()
    {
        OnSpawn.Invoke();
    }

    public void Hit()
    {
        OnHit.Invoke();

        StartCoroutine(CoDestroy());
    }

    private IEnumerator CoDestroy()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
