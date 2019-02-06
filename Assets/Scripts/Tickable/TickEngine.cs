using System;
using System.Collections.Generic;
using System.Threading;

public class TickEngine : IDisposable{

    public const int TICK_MILLISECONDS = 500;

    private List<ITickable> registeredTickables = new List<ITickable>();

    private bool gamePaused = false;
    private bool gameStopped = false;

    public void RegisterTickable(ITickable tickable) {
        registeredTickables.Add(tickable);
    }

    public Thread Start() {
        Thread tickThread = new Thread(Tick);
        tickThread.Start();
        return tickThread;
    }

    private void Tick() {
        while (!gameStopped) {
            Thread.Sleep(TICK_MILLISECONDS);
            if (!gamePaused) { 
                foreach(ITickable tickable in this.registeredTickables) {
                    Thread tickThread = new Thread(tickable.onTick);
                    tickThread.Start();
                }
            }
        }
    }

    public void Pause() {
        gamePaused = true;
    }

    public void Resume() {
        gamePaused = false;
    }

    public void Dispose() {
        gameStopped = true;
    }

    public List<ITickable> RegisteredTickables() {
        return this.registeredTickables;
    }

    
}

