using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSetup : MonoBehaviour
{
    [SerializeField] private DestructibleGlobalMeshSpawner MeshSpawner;

    private List<GameObject> _globalMeshSegments = new();
    private DestructibleMeshComponent _destructibleMeshComponent;

    private void OnEnable()
    {
        MeshSpawner.OnDestructibleMeshCreated.AddListener(OnDestructibleMeshCreated);
    }

    private void OnDisable()
    {
        MeshSpawner.OnDestructibleMeshCreated.RemoveListener(OnDestructibleMeshCreated);
    }

    private void OnDestructibleMeshCreated(DestructibleMeshComponent destructibleMeshComponent)
    {
        _destructibleMeshComponent = destructibleMeshComponent;
        destructibleMeshComponent.GetDestructibleMeshSegments(_globalMeshSegments);
        foreach (var globalMeshSegment in _globalMeshSegments)
        {
            globalMeshSegment.AddComponent<MeshCollider>();
        }
    }
}
