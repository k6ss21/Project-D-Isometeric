using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int skillPoints;
    public int gainedXp;
    public float masterVolume;
    public float musicVolume;
    public float AmbienceVolume;
    public float SFXVolume;
    public string levelName;
    public int levelIndexNumber;
    public Dictionary<string, bool> abilitiesUnlocked;

    //initial value when start a new game
    public GameData()
    {
        this.skillPoints = 0;
        this.gainedXp = 0;
        this.masterVolume = 1f;
        this.levelName = "Level_3";
        this.levelIndexNumber = 0;
        abilitiesUnlocked = new Dictionary<string, bool>();

    }
}
