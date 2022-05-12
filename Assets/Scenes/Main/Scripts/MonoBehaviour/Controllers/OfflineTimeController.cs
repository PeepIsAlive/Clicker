using System;
using UnityEngine;

public class OfflineTimeController : MonoBehaviour
{
    private const string Key = "LastSession";
    
    public int ValueForOfflineTime { get; private set; }

    public void SaveLastSessionDate()
    {
        PlayerPrefs.SetString(Key, DateTime.Now.ToString());
    }

    public void OnStart(int valuePerSeconds)
    {
        TimeSpan timeSpan;

        if (PlayerPrefs.HasKey(Key))
        {
            timeSpan = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(Key));
        }

        ValueForOfflineTime = (timeSpan != null) ? (int)timeSpan.TotalSeconds * valuePerSeconds : 0;
    }
}
