using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    [Space(25)]
    public string sentString;
    public int sentInt;
    public float sentFloat;
    public bool sentBool;

    private List<EventListener> eventListeners = new List<EventListener>();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(this);
        }
    }

    public void Register(EventListener passedEvent)
    {

        if (!eventListeners.Contains(passedEvent))
        {
            eventListeners.Add(passedEvent);
        }

    }

    public void DeRegister(EventListener passedEvent)
    {

        if (eventListeners.Contains(passedEvent))
        {
            eventListeners.Remove(passedEvent);
        }

    }

}