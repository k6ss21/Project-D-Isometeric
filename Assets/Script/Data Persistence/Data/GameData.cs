using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int skillPoints;
    public int gainedXp;
    public Dictionary<string, bool> abilitiesUnlocked;

    //initial value when start a new game
    public GameData()
    {
        this.skillPoints = 0;
        this.gainedXp = 0;
        abilitiesUnlocked = new Dictionary<string, bool>();
      
    }
}
