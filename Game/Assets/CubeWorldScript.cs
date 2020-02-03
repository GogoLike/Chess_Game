using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWorldScript : MonoBehaviour
{
    private int[,] heightMap;
    private int[,] fsquare;
    public GameObject Cube;
    public int Width;
    private int width;
    private int logrange;
    private System.Random rand;
    public int nw, ne, sw, se;

    private void SetFSquare(int nw, int ne, int sw, int se)
    {
        fsquare = new int[2, 2];
        if (nw == 0) nw = 1;
        if (ne == 0) ne = 1;
        if (sw == 0) sw = 1;
        if (se == 0) se = 1;
        fsquare[0, 0] = nw;
        fsquare[0, 1] = ne;
        fsquare[1, 0] = sw;
        fsquare[1, 1] = se;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateWorld()
    {
        if (Math.Log(Width, 2) % 1 != 0)
        {
            Debug.Log("Width is not x^2");
            return;
        }
        logrange = (int)Math.Log(Width, 2);
        rand = new System.Random();
        SetFSquare(nw, ne, se, se);
        width = Width + 1;
        heightMap = new int[width, width];
        for (int i1 = 0; i1 < width; i1++) 
        {
            for (int k1 = 0; k1 < width; k1++)
            {
                heightMap[i1, k1] = 1 + rand.Next(0, 10);
            }
        }
        heightMap[0, 0] = fsquare[0, 0];
        heightMap[0, width - 1] = fsquare[0, 1];
        heightMap[width - 1, 0] = fsquare[1, 0];
        heightMap[width - 1, width - 1] = fsquare[1, 1];
        for (int x = 0; x<width; x++)
        {
            for(int z = 0; z<width; z++)
            {
                float height = heightMap[x, z] * 0.5f;
                float sheight = (height / 2) - 0.25f;
                Vector3 newposition = new Vector3(x, sheight, z);
                Vector3 scale = new Vector3(1, height, 1);
                GameObject cloneCube = (GameObject)Instantiate(Cube, newposition, Quaternion.identity);
                cloneCube.transform.position = newposition;
                cloneCube.transform.localScale = scale;
                cloneCube.name = "Height_" + x + "_" + z;
            }
        }
    }

}
