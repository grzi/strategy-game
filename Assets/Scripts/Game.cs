using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main controller of the game. Will have the knowledge of all 
/// the top elements needed to control the game
/// </summary>
public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; } = null;

    public GameConfig Config { get; private set; }

    public GameData Data { get; private set; } = new GameData();

    private void Awake() {
        InitSingleton();
        DontDestroyOnLoad(gameObject);
        GameLogger.ConfigureLogging();
        LoadGameObjects();
    }

    private void Start()
    {
        GameObject quad = new GameObject("Quad");
        MeshFilter meshFilter = (MeshFilter)quad.AddComponent(typeof(MeshFilter));

        MeshData meshData = GeometryEngine.createQuad(GeometryEngine.Cubeside.FRONT);
        meshData.Merge(GeometryEngine.createQuad(GeometryEngine.Cubeside.RIGHT));
        meshData.Merge(GeometryEngine.createQuad(GeometryEngine.Cubeside.LEFT));
        meshData.Merge(GeometryEngine.createQuad(GeometryEngine.Cubeside.BACK));
        meshData.Merge(GeometryEngine.createQuad(GeometryEngine.Cubeside.TOP));
        meshData.Merge(GeometryEngine.createQuad(GeometryEngine.Cubeside.BOTTOM));


        Mesh mesh = new Mesh();
        mesh.vertices = meshData.Vertices.ToArray();
        mesh.normals = meshData.Normals.ToArray();
        mesh.uv = meshData.UVs.ToArray();

        mesh.triangles = meshData.Triangles.ToArray();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;
       // meshFilter.mesh = GeometryEngine.createQuad(GeometryEngine.Cubeside.FRONT);

        MeshRenderer renderer = quad.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
    }

    private void InitSingleton()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    void OnApplicationQuit() {
        GameLogger.CloseLog();
    }

    private void LoadGameObjects()
    {
        Config = gameObject.GetComponent<GameConfig>();
    }

    private void SetConfig(GameConfig c)
    {
        Config = c;
    }
}
