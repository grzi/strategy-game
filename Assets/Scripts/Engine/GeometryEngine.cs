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
        BACK_TOP_LEFT, BACK_TOP_RIGHT, BACK_BOTTOM_LEFT, BACK_BOTTOM_RIGHT
    }

    private static readonly Dictionary<CubeVertices, Vector3> allVertices =  new Dictionary<CubeVertices, Vector3>
        {
            { CubeVertices.FRONT_TOP_LEFT, new Vector3(-0.5f, 0.5f, -0.5f)},
            { CubeVertices.FRONT_TOP_RIGHT, new Vector3(0.5f, 0.5f, -0.5f)},
            { CubeVertices.FRONT_BOTTOM_LEFT, new Vector3(-0.5f, -0.5f, -0.5f)},
            { CubeVertices.FRONT_BOTTOM_RIGHT, new Vector3(0.5f, -0.5f, -0.5f)},
            { CubeVertices.BACK_TOP_LEFT, new Vector3(-0.5f, 0.5f, 0.5f)},
            { CubeVertices.BACK_TOP_RIGHT, new Vector3(0.5f, 0.5f, 0.5f)},
            { CubeVertices.BACK_BOTTOM_LEFT, new Vector3(-0.5f, -0.5f, 0.5f)},
            { CubeVertices.BACK_BOTTOM_RIGHT, new Vector3(0.5f, -0.5f, 0.5f)}
        };

    private static readonly Vector2[] uvs = new Vector2[]
    { new Vector2( 0f, 0f ), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };


    public static MeshData createQuad(Cubeside side)
    {

        Vector3[] vertices = new Vector3[4];
        Vector3[] normals = new Vector3[4];
        int[] triangles = new int[] {  0, 1, 2,
                                         2, 3, 0 };

        switch (side)
        {
            case Cubeside.FRONT:
                vertices = new Vector3[] {  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.FRONT_TOP_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_LEFT] };
                normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
                break;
            case Cubeside.BACK:
                vertices = new Vector3[] {  allVertices[CubeVertices.BACK_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_RIGHT],
                                            allVertices[CubeVertices.BACK_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.BACK_BOTTOM_LEFT] };
                normals = new Vector3[] { Vector3.back, Vector3.back, Vector3.back, Vector3.back };
                break;
            case Cubeside.LEFT:
                vertices = new Vector3[] {  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_BOTTOM_LEFT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_LEFT] };
                normals = new Vector3[] { Vector3.right, Vector3.right, Vector3.right, Vector3.right };
                break;
            case Cubeside.RIGHT:
                vertices = new Vector3[] {  allVertices[CubeVertices.FRONT_TOP_RIGHT],
                                            allVertices[CubeVertices.BACK_TOP_RIGHT],
                                            allVertices[CubeVertices.BACK_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT] };
                normals = new Vector3[] { Vector3.left, Vector3.left, Vector3.left, Vector3.left };
                break;
            case Cubeside.TOP:
                vertices = new Vector3[] {  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_RIGHT],
                                            allVertices[CubeVertices.FRONT_TOP_RIGHT] };
                normals = new Vector3[] { Vector3.down, Vector3.down, Vector3.down, Vector3.down };
                break;
            case Cubeside.BOTTOM:
                vertices = new Vector3[] {  allVertices[CubeVertices.FRONT_BOTTOM_LEFT],
                                            allVertices[CubeVertices.BACK_BOTTOM_LEFT],
                                            allVertices[CubeVertices.BACK_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT] };
                normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
                break;
            default:
                break;
        }

        return new MeshData(vertices,normals, triangles, uvs);
    }

    #endregion

}
