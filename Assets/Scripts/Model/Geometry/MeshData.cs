using System;
using System.Collections.Generic;
using UnityEngine;

public class MeshData 
{


    private List<Vector3> vertices;
    private List<Vector3> normals;
    private List<int> triangles;
    private List<Vector2> uvs;

    public MeshData()
    {
        this.vertices = new List<Vector3>();
        this.normals = new List<Vector3>();
        this.triangles = new List<int>();
        this.uvs = new List<Vector2>();
    }

    public MeshData(List<Vector3> _vertices, List<Vector3> _normals, List<int> _triangles, List<Vector2> _uvs)
    {
        this.vertices = _vertices;
        this.normals = _normals;
        this.triangles = _triangles;
        this.uvs = _uvs;
    }

    public void Merge(MeshData toMerge)
    {
        if (toMerge == null || !toMerge.CheckIntegrity())
        {
            return;
        }

        int countVertices = this.Vertices.Count;
        foreach (int triangle in toMerge.Triangles)
        {
            this.Triangles.Add(triangle + countVertices);
        }

        this.vertices.AddRange(toMerge.Vertices);
        this.Normals.AddRange(toMerge.Normals);
        this.UVs.AddRange(toMerge.UVs);

       
       

    }

    public bool CheckIntegrity()
    {
        if (this.Vertices == null || this.Normals == null || this.UVs == null || this.Triangles == null)
        {
            return false;
        }
        return true;
    }

    public List<Vector3> Vertices
    {
        get { return vertices; }
    }

    public List<Vector3> Normals
    {
        get { return normals; }
    }

    public List<int> Triangles
    {
        get { return triangles; }
    }

    public List<Vector2> UVs
    {
        get { return uvs; }
    }

   

}

