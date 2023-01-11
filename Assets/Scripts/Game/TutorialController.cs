using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialController : MonoBehaviour
{
    public FingerZap Spawner;
    public GameObject LightningBall;
    public GameObject FireBall;

    public UnityEvent OnLightningAppear;
    public UnityEvent OnLightningReady;
    public UnityEvent OnLightningThrown;

    public UnityEvent OnPracticeLightningAppear;
    public UnityEvent OnPracticeLightningReady;
    public UnityEvent OnPracticeLightningThrown;

    public UnityEvent OnFireAppear;
    public UnityEvent OnFireReady;
    public UnityEvent OnFireThrown;

    public void SpawnLightningBall()
    {
        Spawner.SpawnObject = LightningBall;
        var go = Spawner.Activate();
        var magic = go.GetComponent<Magic>();

        magic.OnAppeared.AddListener(() => {
            OnLightningAppear.Invoke();
            magic.OnAppeared.RemoveAllListeners();
        });
        magic.OnReady.AddListener(() => {
            OnLightningReady.Invoke();
            magic.OnReady.RemoveAllListeners();
        });
        magic.OnThrown.AddListener(() => {
            OnLightningThrown.Invoke();
            magic.OnThrown.RemoveAllListeners();
        });
    }

    public void SpawnPracticeLightningBall()
    {
        Spawner.SpawnObject = LightningBall;
        var go = Spawner.Activate();
        var magic = go.GetComponent<Magic>();

        magic.OnAppeared.AddListener(() => {
            OnPracticeLightningAppear.Invoke();
            magic.OnAppeared.RemoveAllListeners();
        });
        magic.OnReady.AddListener(() => {
            OnPracticeLightningReady.Invoke();
            magic.OnReady.RemoveAllListeners();
        });
        magic.OnThrown.AddListener(() => {
            OnPracticeLightningThrown.Invoke();
            magic.OnThrown.RemoveAllListeners();
        });
    }

    public void SpawnFireBall()
    {
        Spawner.SpawnObject = FireBall;
        var go = Spawner.Activate();
        var magic = go.GetComponent<Magic>();

        magic.OnAppeared.AddListener(() => {
            OnFireAppear.Invoke();
            magic.OnAppeared.RemoveAllListeners();
        });
        magic.OnReady.AddListener(() => {
            OnFireReady.Invoke();
            magic.OnReady.RemoveAllListeners();
        });
        magic.OnThrown.AddListener(() => {
            OnFireThrown.Invoke();
            magic.OnThrown.RemoveAllListeners();
        });
    }
}
