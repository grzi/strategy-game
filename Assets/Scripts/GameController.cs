using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main controller of the game. Will have the knowledge of all 
/// the top elements needed to control the game
/// </summary>
public class GameController : MonoBehaviour
{
    private void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        GameLogger.ConfigureLogging();
        LoadGameObjects();
    }

    void OnApplicationQuit() {
        GameLogger.CloseLog();
    }

    private void LoadGameObjects() {
       Config = gameObject.GetComponent<GameConfig>();
    }

    public static GameController Instance { get; private set; } = null;

    public GameConfig Config { get; set; }
}
