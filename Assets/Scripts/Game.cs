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

    public GameConfig Config { get; private set; } = new GameConfig();

    public GameData Data { get; private set; } = new GameData();

    private void Awake() {
        InitSingleton();
        DontDestroyOnLoad(gameObject);
        GameLogger.ConfigureLogging();
        LoadGameObjects();
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
}
