using UnityEngine;
using System.Collections;
using static GameLogger;

public class GameConfig : MonoBehaviour {

    [SerializeField]
    private bool devMode = false;

    [SerializeField]
    private LogLevel logLevel = LogLevel.INFO;

    [SerializeField]
    private int tick_nb_per_day = 24;


    public bool DevMode {
        get { return devMode; }
    }

    public LogLevel LogLevel {
        get { return logLevel; }
    }
    public int TickNbPerDay
    {
        get { return tick_nb_per_day; }
    }

}
