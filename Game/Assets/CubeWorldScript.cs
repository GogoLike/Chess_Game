using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWorldScript : MonoBehaviour
{
    private int[,] heightMap;
    public GameObject Cube;
    private int Width=4;
    private int width;
    public string game_path = @"D:/Unity_Projects/Chess_Game/Game";
    public string world_name;

    // Start is called before the first frame update
    void Start()
    {
        ReadWorld(world_name);
        GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadWorld(string name)
    {
        string path = game_path + @"/Assets/Worlds/" + name + @".txt";
        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
        {
            string line1;
            while ((line1 = sr.ReadLine()) != null)
            {
                string[] line = line1.Split('=');
                Debug.Log(line[0]);
                Debug.Log(line[1]);
            }
        }

    }

    private void GenerateWorld()
    {
        if (Math.Log(Width, 2) % 1 != 0)
        {
            Debug.Log("Width is not x^2");
            return;
        }
        width = Width + 1;
        heightMap = new int[width, width];
        for (int i1 = 0; i1 < width; i1++) 
        {
            for (int k1 = 0; k1 < width; k1++)
            {
                heightMap[i1, k1] = 1;
            }
        }
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
