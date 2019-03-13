using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Deprecated, was for tests purposes
/// </summary>
public class WorldController : MonoBehaviour
{

    public GameObject voxel;
    public int height = 2, depth = 2, width = 2;

    public IEnumerator BuildWorld()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector3 position = new Vector3(x, y, z);
                    GameObject cube = Instantiate(voxel, position, Quaternion.identity);
                    cube.name = x + "_" + y + "_" + z;
                }
                yield return null;
            }
        }
       
    }

    void Start()
    {
        StartCoroutine(BuildWorld());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
