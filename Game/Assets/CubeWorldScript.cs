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
    private int Width;
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
        string path = game_path + @"/Assets/Worlds/" + name + @".hmap";
        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
        {
            string line1;
            int x = 0;
            while ((line1 = sr.ReadLine()) != null)
            {
                string[] line2 = line1.Split('=');
                if (line2[0] == "width")
                {
                    Width = Convert.ToInt32(line2[1]);
                    if (Math.Log(Width, 2) % 1 != 0)
                    {
                        Debug.Log("Width is not x^2");
                        return;
                    }
                    width = Width + 1;
                    heightMap = new int[width, width];
                }
                else
                {
                    string[] line3 = line1.Split(',');
                    for (int z = 0; z<width;z++)
                    {
                        heightMap[x, z] = Convert.ToInt32(line3[z]);
                    }
                    x++;
                }
            }
        }

    }

    private void GenerateWorld()
    {
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
