using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LegacyManager : MonoBehaviour
{
    private string arcaCollected;
    private int levelUnlocked;

    private void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked");
        arcaCollected = PlayerPrefs.GetString("ArcaCollected");
    }

    public void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt("LevelUnlocked",level);
    }

    public void CollectArca(int index) {
        StringBuilder builder = new StringBuilder(arcaCollected);
        builder.Remove(index, 1);
        builder.Insert(index, "1");

        PlayerPrefs.SetString("ArcaCollected",builder.ToString());
    }

    public bool CheckArcaCollected(int index)
    {
        return arcaCollected[index].Equals("1");
    }
}
