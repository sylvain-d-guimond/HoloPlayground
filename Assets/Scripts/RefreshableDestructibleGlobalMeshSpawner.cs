using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshableDestructibleGlobalMeshSpawner : MonoBehaviour
{
    [SerializeField] private DestructibleGlobalMeshSpawner spawner;
    public void RefreshMesh(Material mat)
    {
        spawner.GlobalMeshMaterial = mat;
        spawner.RemoveDestructibleGlobalMesh();
        spawner.AddDestructibleGlobalMesh(MRUK.Instance.GetCurrentRoom());
    }
}
