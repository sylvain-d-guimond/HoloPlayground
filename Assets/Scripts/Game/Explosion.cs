using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    public UnityEvent OnExplode;

    private void Start()
    {
        OnExplode.AddListener(() => StartCoroutine(CoSelfDestruct()));
    }

    private IEnumerator CoSelfDestruct()
    {
        yield return new WaitForSeconds(4f);

        Destroy(gameObject);
    }
}
