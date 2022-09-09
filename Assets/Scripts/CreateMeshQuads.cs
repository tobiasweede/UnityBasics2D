using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMeshQuads : MonoBehaviour
{

    void Start()
    {
        var size = 3;
        var width = 5;
        var height = 3;
        GetComponent<MeshFilter>().mesh = CreateMeshTiles(size, width, height);
        transform.position = new Vector3(-(width*size/2), -(height*size/2));
    }

    private Mesh CreateMeshTiles(int size = 3, int width = 5, int height = 3)
    {

        Mesh mesh = new Mesh();

        Vector3[] vertics = new Vector3[4 * width * height];
        Vector2[] uv = new Vector2[4 * width * height];
        int[] triangles = new int[6 * width * height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int index = i * height + j;

                vertics[index * 4 + 0] = new Vector3(size * i, size * j);
                vertics[index * 4 + 1] = new Vector3(size * i, size * (j + 1));
                vertics[index * 4 + 2] = new Vector3(size * (i + 1), size * (j + 1));
                vertics[index * 4 + 3] = new Vector3(size * (i + 1), size * j);

                uv[index * 4 + 0] = new Vector2(0, 0);
                uv[index * 4 + 1] = new Vector2(0, 1);
                uv[index * 4 + 2] = new Vector2(1, 1);
                uv[index * 4 + 3] = new Vector2(1, 0);

                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;
                triangles[index * 6 + 3] = index * 4 + 0;
                triangles[index * 6 + 4] = index * 4 + 2;
                triangles[index * 6 + 5] = index * 4 + 3;
            }
        }

        mesh.vertices = vertics;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }

}
