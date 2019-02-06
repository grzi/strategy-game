using UnityEngine;
using System.Collections;
using static GameLogger;

public class GameConfig : MonoBehaviour {

    [SerializeField]
    private bool devMode = false;

    [SerializeField]
    private LogLevel logLevel = LogLevel.INFO;


    public bool DevMode {
        get { return devMode; }
    }

    public LogLevel LogLevel {
        get { return logLevel; }
    }
}
