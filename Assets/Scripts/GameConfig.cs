using UnityEngine;
using System.Collections;
using static GameLogger;

public class GameConfig : MonoBehaviour {

    [SerializeField]
    private bool devMode;

    [SerializeField]
    private LogLevel logLevel;


    public bool DevMode {
        get { return devMode; }
    }

    public LogLevel LogLevel {
        get { return logLevel; }
    }
}
