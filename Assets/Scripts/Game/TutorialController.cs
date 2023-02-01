using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialController : MonoBehaviour
{
    public static TutorialController Instance;

    public FingerZap Spawner;
    public GameObject LightningBall;
    public GameObject FireBall;

    public GameObject TargetPrefab;
    public float PracticeTargetAngle = 30f;
    public float TargetAppearDelay = 0.5f;
    public int TargetCount = 5;
    public float MinTargetDistance = 1.2f;
    public float MinInterTargetDistance = 0.6f;
    private List<PracticeTarget> _targets = new List<PracticeTarget>();
    public UnityEvent OnTargetsDestroyed;

    public UnityEvent OnLightningAppear;
    public UnityEvent OnLightningReady;
    public UnityEvent OnLightningThrown;

    public UnityEvent OnPracticeLightningAppear;
    public UnityEvent OnPracticeLightningReady;
    public UnityEvent OnPracticeLightningThrown;

    public UnityEvent OnFireAppear;
    public UnityEvent OnFireReady;
    public UnityEvent OnFireThrown;

    public UnityEvent OnPracticeFireAppear;
    public UnityEvent OnPracticeFireReady;
    public UnityEvent OnPracticeFireThrown;

    public TutorialController()
    {
        Instance = this;
    }

    public void SpawnTargets()
    {
        StartCoroutine(CoSpawnTargets());
    }

    private IEnumerator CoSpawnTargets()
    {
        while (_targets.Count < TargetCount)
        {
            var direction = Camera.main.transform.rotation;
            direction *= Quaternion.Euler(Vector3.up * Random.Range(-PracticeTargetAngle, PracticeTargetAngle));
            direction *= Quaternion.Euler(Vector3.left * Random.Range(-PracticeTargetAngle, PracticeTargetAngle));
            Debug.Log($"Shoot ray from {Camera.main.transform.position} to {direction * Vector3.forward}");
            if (Physics.Raycast(Camera.main.transform.position, direction * Vector3.forward, out RaycastHit hit))
            {
                if ((hit.point - Camera.main.transform.position).magnitude > MinTargetDistance)
                {
                    var nearest = float.MaxValue;
                    foreach (var target in _targets)
                    {
                        var dist = (target.transform.position - hit.point).magnitude;
                        if (dist < nearest) nearest = dist;
                    }

                    if (nearest > MinInterTargetDistance)
                    {
                        Debug.Log($"Hit at {hit.point}");
                        var position = Camera.main.transform.position + (hit.point - Camera.main.transform.position) * 0.95f;
                        var go = Instantiate(TargetPrefab, Room.Instance.transform);
                        go.transform.position = position;
                        //go.transform.rotation = Quaternion.LookRotation(hit.normal);
                        go.transform.rotation = Quaternion.LookRotation(hit.point - Camera.main.transform.position);

                        _targets.Add(go.GetComponent<PracticeTarget>());
                    }
                }
            }

            yield return new WaitForSeconds(TargetAppearDelay);
        }
    }

    public void Destroy(PracticeTarget target, bool skip = false)
    {
        _targets.Remove(target);

        if (_targets.Count < 1 && !skip)
        {
            OnTargetsDestroyed.Invoke();
        }
    }

    public void ClearTargets()
    {
        _targets.ForEach(x =>
        {
            x.Skip = true;
            Destroy(x.gameObject);
        });
    }

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

    public void SpawnPracticeFireBall()
    {
        Spawner.SpawnObject = FireBall;
        var go = Spawner.Activate();
        var magic = go.GetComponent<Magic>();

        magic.OnAppeared.AddListener(() => {
            OnPracticeFireAppear.Invoke();
            magic.OnAppeared.RemoveAllListeners();
        });
        magic.OnReady.AddListener(() => {
            OnPracticeFireReady.Invoke();
            magic.OnReady.RemoveAllListeners();
        });
        magic.OnThrown.AddListener(() => {
            OnPracticeFireThrown.Invoke();
            magic.OnThrown.RemoveAllListeners();
        });
    }
}
