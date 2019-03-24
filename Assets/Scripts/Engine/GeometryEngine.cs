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

    public enum Cubeside { TOP, LEFT, RIGHT, BOTTOM, FRONT, BACK, 
        // Todo
        // LEFT_BOTTOM_TO_RIGHT_TOP, RIGHT_BOTTOM_TO_LEFT_TOP, FRONT_BOTTOM_TO_BACK_TOP, BACK_BOTTOM_TO_FRONT_TOP
    }

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

    private static readonly List<Vector2> uvs = new List<Vector2>
    { new Vector2( 0f, 0f ), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };


    public static MeshData createQuad(Cubeside side)
    {

        List<Vector3> vertices = new List<Vector3>();
        List < Vector3 > normals = new List<Vector3>();
        List < int > triangles = new List<int> {  0, 1, 2,
                                         2, 3, 0 };

        switch (side)
        {
            case Cubeside.FRONT:
                vertices = new List<Vector3> {  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.FRONT_TOP_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_LEFT] };
                normals = new List<Vector3>{ Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
                break;
            case Cubeside.BACK:
                vertices = new List<Vector3>{  allVertices[CubeVertices.BACK_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_RIGHT],
                                            allVertices[CubeVertices.BACK_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.BACK_BOTTOM_LEFT] };
                normals = new  List<Vector3>{ Vector3.back, Vector3.back, Vector3.back, Vector3.back };
                break;
            case Cubeside.LEFT:
                vertices = new  List<Vector3>{  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_BOTTOM_LEFT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_LEFT] };
                normals = new  List<Vector3>{ Vector3.left, Vector3.left, Vector3.left, Vector3.left };
                break;
            case Cubeside.RIGHT:
                vertices = new  List<Vector3>{  allVertices[CubeVertices.FRONT_TOP_RIGHT],
                                            allVertices[CubeVertices.BACK_TOP_RIGHT],
                                            allVertices[CubeVertices.BACK_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT] };
                normals = new  List<Vector3>{ Vector3.right, Vector3.right, Vector3.right, Vector3.right };
                break;
            case Cubeside.TOP:
                vertices = new  List<Vector3>{  allVertices[CubeVertices.FRONT_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_LEFT],
                                            allVertices[CubeVertices.BACK_TOP_RIGHT],
                                            allVertices[CubeVertices.FRONT_TOP_RIGHT] };
                normals = new  List<Vector3>{ Vector3.up, Vector3.up, Vector3.up, Vector3.up };
                break;
            case Cubeside.BOTTOM:
                vertices = new  List<Vector3>{  allVertices[CubeVertices.FRONT_BOTTOM_LEFT],
                                            allVertices[CubeVertices.BACK_BOTTOM_LEFT],
                                            allVertices[CubeVertices.BACK_BOTTOM_RIGHT],
                                            allVertices[CubeVertices.FRONT_BOTTOM_RIGHT] };
                normals = new  List<Vector3>{ Vector3.down, Vector3.down, Vector3.down, Vector3.down };
                break;
            default:
                break;
        }

        return new MeshData(vertices, normals, triangles, uvs);
    }

    #endregion

}
