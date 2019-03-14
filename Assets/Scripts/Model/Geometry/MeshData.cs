using System;
using UnityEngine;

public class MeshData
{


    private Vector3[] vertices;
    private Vector3[] normals;
    private int[] triangles;
    private Vector2[] uvs;

    public MeshData(Vector3[] _vertices, Vector3[] _normals, int[] _triangles, Vector2[] _uvs)
    {
        this.vertices = _vertices;
        this.normals = _normals;
        this.triangles = _triangles;
        this.uvs = _uvs;
    }

    public Vector3[] Vertices
    {
        get { return vertices; }
    }

    public Vector3[] Normals
    {
        get { return normals; }
    }

    public int[] Triangles
    {
        get { return triangles; }
    }

    public Vector2[] UVs
    {
        get { return uvs; }
    }

   
}

