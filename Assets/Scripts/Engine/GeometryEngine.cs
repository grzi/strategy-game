using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The purpose of this class is to handle the generation of 
/// the different geometrical elements
/// </summary>
public static class GeometryEngine
{

    #region cube

    public enum Cubeside { TOP, LEFT, RIGHT, BOTTOM, FRONT, BACK}

    public enum CubeVertices { FRONT_TOP_LEFT, FRONT_TOP_RIGHT, FRONT_BOTTOM_LEFT, FRONT_BOTTOM_RIGHT,
        BOTTOM_TOP_LEFT, BOTTOM_TOP_RIGHT, BOTTOM_BOTTOM_LEFT, BOTTOM_BOTTOM_RIGHT
    }

    private static readonly Dictionary<CubeVertices, Vector3> allVertices =  new Dictionary<CubeVertices, Vector3>
        {
            { CubeVertices.FRONT_TOP_LEFT, new Vector3(-0.5f, 0.5f, -0.5f)},
            { CubeVertices.FRONT_TOP_RIGHT, new Vector3(0.5f, 0.5f, -0.5f)},
            { CubeVertices.FRONT_BOTTOM_LEFT, new Vector3(-0.5f, -0.5f, -0.5f)},
            { CubeVertices.FRONT_BOTTOM_RIGHT, new Vector3(0.5f, -0.5f, -0.5f)},
            { CubeVertices.BOTTOM_TOP_LEFT, new Vector3(-0.5f, 0.5f, 0.5f)},
            { CubeVertices.BOTTOM_TOP_RIGHT, new Vector3(0.5f, 0.5f, 0.5f)},
            { CubeVertices.BOTTOM_BOTTOM_LEFT, new Vector3(-0.5f, -0.5f, 0.5f)},
            { CubeVertices.BOTTOM_BOTTOM_RIGHT, new Vector3(0.5f, -0.5f, 0.5f)}
        };

    private static readonly Vector2[] uvs = new Vector2[]
    { new Vector2( 0f, 0f ), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };


    public static Mesh createQuad(Cubeside side)
    {
        Mesh quadMesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector3[] normals = new Vector3[4];
        int[] triangles = new int[6];

        switch (side)
        {
            case Cubeside.FRONT:
                vertices = new Vector3[] {  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.FRONT_TOP_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_LEFT] };
                normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
                triangles = new int[] {  0, 1, 2,
                                         2, 3, 0 };
                break;
            default:
                break;
        }

        quadMesh.vertices = vertices;
        quadMesh.normals = normals;
        quadMesh.uv = uvs;
        quadMesh.triangles = triangles;

        quadMesh.RecalculateBounds();

        return quadMesh;
    }

    #endregion

}
