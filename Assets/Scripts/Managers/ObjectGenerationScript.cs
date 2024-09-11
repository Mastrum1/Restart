using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectGenerationScript : MonoBehaviour
{
    public static ObjectGenerationScript generation;
    [SerializeField] private List<Object> ObjectsBonus;
    [SerializeField] private List<Object> ObjectsMalus;
    [SerializeField] private int  numberToSpawn;
    [SerializeField] [Range(0.0f, 100f)] private int percentBonus = 50;
    [SerializeField] private Terrain terrain;

    private void Awake()
    {
        if (generation) Destroy(this);
        else generation = this;
        Generate();
    }

    private void Generate()
    {
        for (var i = 0; i < numberToSpawn; i++)
        {
            var value =Random.Range(0, 100);
            if(ObjectsMalus.Count < 1)
                Spawning(ObjectsBonus[Random.Range(0, ObjectsBonus.Count )]);
            else if (ObjectsBonus.Count < 1)
                Spawning(ObjectsMalus[Random.Range(0, ObjectsMalus.Count )]);
            else
                Spawning(value > percentBonus ? ObjectsMalus[Random.Range(0, ObjectsMalus.Count )] : ObjectsBonus[Random.Range(0, ObjectsBonus.Count )]);
        }
    }

    private void Spawning(Object obj)
    {
        var terrainWidth = terrain.terrainData.size.x;
        var terrainLength = terrain.terrainData.size.z;
        var xTerrainPos = terrain.transform.position.x;
        var zTerrainPos = terrain.transform.position.z;
        float randX = Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ)) + 0.5f;
        Instantiate(obj, new Vector3(randX, yVal, randZ), quaternion.identity);
    }
}
