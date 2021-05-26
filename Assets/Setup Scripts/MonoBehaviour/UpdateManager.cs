using System.Collections.Generic;
using UnityEngine;

public interface IUpdateable
{
    void OnUpdate(float time);
}

public class UpdateManager : Singleton<UpdateManager>
{
    protected UpdateManager() { }

#region Fields
    private List<IUpdateable> UpdateQueue = new List<IUpdateable>();
    private List<IUpdateable> UpdateAddQueue = new List<IUpdateable>();
    private List<IUpdateable> UpdateRemovalQueue = new List<IUpdateable>();
#endregion

#region Methods

    public void Register(IUpdateable script)
    {
        UpdateAddQueue.Add(script);
    }

    public void Unregister(IUpdateable script)
    {
        UpdateRemovalQueue.Add(script);
    }

    void Update()
    {
        if (UpdateAddQueue.Count > 0)
        {
            for (int i = UpdateAddQueue.Count - 1; i >= 0; i--)
            {
                UpdateQueue.Add(UpdateAddQueue[i]);
                UpdateAddQueue.Remove(UpdateAddQueue[i]);
            }
        }
        if (UpdateRemovalQueue.Count > 0)
        {
            for (int i = UpdateRemovalQueue.Count - 1; i >= 0; i--)
            {
                UpdateQueue.Remove(UpdateRemovalQueue[i]);
                UpdateRemovalQueue.Remove(UpdateRemovalQueue[i]);
            }
        }
        foreach (IUpdateable queued in UpdateQueue)
        {
            queued.OnUpdate(Time.deltaTime);
        }
    }
#endregion

}