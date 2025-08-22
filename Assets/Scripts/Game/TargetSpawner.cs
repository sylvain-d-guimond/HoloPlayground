using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetSpawner : MonoBehaviour
{
    public Vector3 MinValues;
    public Vector3 MaxValues;

    public GameObject TargetPrefab;

    private List<GameObject> targets= new List<GameObject>();

    [SerializeField] bool debug;

    public void Spawn(int number)
    {
        var pick = Random.Range(0, number);

        for (int i = 0; i < number; i++)
        {
            var direction = new Vector3(Random.Range(MinValues.x, MaxValues.x),
                Random.Range(MinValues.y, MaxValues.y),
                Random.Range(MinValues.z, MaxValues.z));

            if (debug) Debug.Log($"[TargetSpawner] Casting ray from {Camera.main.transform.position} towards {direction}");
            var ray = new Ray(Camera.main.transform.position, direction);

            LayerMask mask = ~0;
            var practiceMask = LayerMask.GetMask("Practice");
            mask &= ~(practiceMask);

            if (Physics.Raycast(ray, out var hit, 100f, mask))
            {
                var target = Instantiate(TargetPrefab, Room.Instance.transform);
                target.transform.position = hit.point - 0.2f*(hit.point - Camera.main.transform.position);
                target.transform.rotation = Quaternion.LookRotation(hit.point - Camera.main.transform.position);
                targets.Add(target);

                //Random target will spawn N more targets
                if (i == pick) {
                    var pt = target.GetComponent<PracticeTarget>();
                    if (pt != null)
                    {
                        pt.OnHit.AddListener(() => Spawn(number));
                    }
                }

                if (debug)
                {
                    Debug.Log($"[TargetSpawner] Hit at {hit.point}");
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                }
            } else { Debug.LogWarning($"Failed to spawn target. Is spatial perception on?"); }
        }
    }

    public void RemoveAll()
    {
        foreach (var target in targets) 
            Destroy(target.gameObject);

        targets.Clear();
    }
}
