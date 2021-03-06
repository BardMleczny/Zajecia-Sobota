using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;
    public Material material01;
    public Material material02;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
            return;

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 postion = new Vector3(x, 0, z) * offset;
                Instantiate(colorMapping.prefab, postion, Quaternion.identity, transform);
            }
        }
    }
    public void GenerateLabirynth()
    {
        for(int z =0; z<map.height; z++)
        {
            for(int x =0; x< map.width; x++)
            {
                GenerateTile(x, z);
            }
        }
        ColorTheChildren();
    }
    
    private void ColorTheChildren()
    {
        foreach(Transform child in transform)
        {
            if(child.tag == "Wall")
            {
                if (UnityEngine.Random.Range(1, 1000) % 3 == 0)
                    child.gameObject.GetComponent<Renderer>().sharedMaterial = material01;
                else
                    child.gameObject.GetComponent<Renderer>().sharedMaterial = material02;
            }

            if(child.childCount > 0)
            {
                foreach(Transform grandchild in child.transform)
                {
                    if(grandchild.tag == "Wall")
                    {
                        grandchild.gameObject.GetComponent<Renderer>().sharedMaterial =
                            child.gameObject.GetComponent<Renderer>().sharedMaterial;
                    }
                }
            }
        }
    }

}
