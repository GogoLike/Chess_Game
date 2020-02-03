using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeighMapScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terrain tr = GetComponent<Terrain>();
        System.Random rand = new System.Random();
        int z = 129;
        float[,] a = new float[z,z];
        for(int i = 0; i<z; i++)
        {
            for(int k = 0; k<z; k++)
            {
                a[i, k] = (float)rand.NextDouble();
            }
        }
        tr.terrainData.SetHeights(0, 0, a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
