using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    static PickupBlock freezeEventInvoker;
    static UnityAction<int> freezeEventListener;
    static PickupBlock speedUpEventInvoker;
    static UnityAction<int, float> speedUpEventListener;

    public static void AddFreezeInvoker(PickupBlock invoker)
    {
        freezeEventInvoker = invoker;
        if (freezeEventListener != null)
        {
            freezeEventInvoker.AddFreezeEventListener(freezeEventListener);
        }
    }
    public static void AddFreezeListener(UnityAction<int> freezeEventHandler)
    {
        freezeEventListener = freezeEventHandler;
        if (freezeEventInvoker != null)
        {
            freezeEventInvoker.AddFreezeEventListener(freezeEventListener);
        }
    }
    public static void AddSpeedUpInvoker(PickupBlock invoker)
    {
        speedUpEventInvoker = invoker;
        if (speedUpEventListener != null)
        {
            speedUpEventInvoker.AddSpeedUpEventListener(speedUpEventListener);
        }
    }
    public static void AddSpeedUpListener(UnityAction<int,float> speedupEventHandler)
    {
        speedUpEventListener = speedupEventHandler;
        if (speedUpEventInvoker != null)
        {
            speedUpEventInvoker.AddSpeedUpEventListener(speedUpEventListener);
        }
    }
}
