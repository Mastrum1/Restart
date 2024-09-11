using UnityEngine;
using UnityEngine.Events;

public class Timer {
    public float CurrentTime { get; private set; }
    public float TickInterval { get; private set; }
    public bool Running { get; private set; }
    public bool IsPaused { get; private set; }

    public event UnityAction OnTimerStart;
    public event UnityAction OnTimerStop;
    public event UnityAction OnTimerTick;

    public Timer(float tickInterval) {
        Running = false;
        IsPaused = false;
        CurrentTime = 0f;
        TickInterval = tickInterval;
    }

    public void Start() {
        Running = true;
        CurrentTime = 0f;
        OnTimerStart?.Invoke();
    }

    public void Stop() {
        Running = false;
        CurrentTime = 0f;
        OnTimerStop?.Invoke();
    }

    public void Pause() => IsPaused = true;
    public void Resume() => IsPaused = false;
    
    public void Update(float deltaTime) {
        if (!Running) return;
        if (IsPaused) return;
        CurrentTime += deltaTime;
        if(CurrentTime >= TickInterval) {
            CurrentTime -= TickInterval;
            OnTimerTick?.Invoke();
        }
    }

    public void Reset() => CurrentTime = 0;

    public void Reset(float newInterval) {
        TickInterval = newInterval;
        Reset();
    }
}