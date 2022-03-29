using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WindowLights : MonoBehaviour
{
    [SerializeField] GameObject windowLightPrefab;

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(position)) continue;
            Transform light = Instantiate(windowLightPrefab, position, Quaternion.identity).transform;
            light.SetParent(this.transform);
        }
    }
}
