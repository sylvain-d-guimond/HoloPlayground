using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvgDistance : MonoBehaviour
{
    public static AvgDistance Instance;

    public Transform[] Targets;

    public float Distance;

    public bool waitForUpdate;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!waitForUpdate)
        {
            var sum = 0f;
            var count = 0;
            for (int i = 0; i < Targets.Length; i++)
            {
                for (int j = 0; j < Targets.Length; j++)
                {
                    if (Targets[i] != Targets[j])
                    {
                        sum += (Targets[i].position - Targets[j].position).magnitude;
                        count++;
                    }
                }
            }

            Distance = sum / count;
        } 
        else waitForUpdate = false;
    }

    private void OnEnable()
    {
        Distance = 0;
        waitForUpdate = true;
    }
}
