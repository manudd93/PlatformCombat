using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class funcTimer
{
    private static List<funcTimer> activeTimerList;
    private static GameObject intItGameObject;
    private static void InitIfNeeded()
    {
        if (intItGameObject == null)
        {
            intItGameObject = new GameObject("FuncTimer_inItGameObject");
            activeTimerList = new List<funcTimer>();
        }
    }
    public static funcTimer Create(Action action, float Timer, string TimerName = null)
    {
        InitIfNeeded();
        GameObject gameObject = new GameObject("funcTimer", typeof(MonoBehavioirHook));
        funcTimer funTimer = new funcTimer(action, Timer, TimerName, gameObject);

        gameObject.GetComponent<MonoBehavioirHook>().onUpdate = funTimer.Update;
        activeTimerList.Add(funTimer);
        return funTimer;
    }
    private static void RemoveTimer(funcTimer functionTimer)
    {
        InitIfNeeded();
        activeTimerList.Remove(functionTimer);
    }
    public static void StopTimer(string TimerName)
    {
        for (int i = 0; i < activeTimerList.Count; i++)
        {
            if (activeTimerList[i].timerName == TimerName)
            {
                //stopTimer
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }
    private class MonoBehavioirHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }
    private Action action;
    private float timer;
    private string timerName;
    private GameObject gameObject;
    bool Destroyng;
    private funcTimer(Action azione, float Timer, string TimerName, GameObject gameObJect)
    {
        this.action = azione;
        this.timer = Timer;
        this.gameObject = gameObJect;
        this.timerName = TimerName;
        Destroyng = false;
    }

    public void Update()
    {
        if (!Destroyng)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                action();
                DestroySelf();
            }
        }
    }


    void DestroySelf()
    {
        Destroyng = true;
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }

}
