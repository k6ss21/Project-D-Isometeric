using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{

    private enum Levels
    {
        Level_1,
        Level_2,
        Level_3,
        Level_4,
        Level_5,
        Level_6,
        Level_7,
        Level_8,
        Level_9,
        Level_10

    }

    [SerializeField] Levels level;

    public void LevelButton()
    {
        switch (level)
        {
            case Levels.Level_1:
                LevelManager.instance.LoadLevel("Level_1");
                break;
            case Levels.Level_2:
                LevelManager.instance.LoadLevel("Level_2");
                break;
            case Levels.Level_3:
                LevelManager.instance.LoadLevel("Level_3");
                break;
            case Levels.Level_4:
                LevelManager.instance.LoadLevel("Level_4");
                break;
            case Levels.Level_5:
                LevelManager.instance.LoadLevel("Level_5");
                break;
            case Levels.Level_6:
                LevelManager.instance.LoadLevel("Level_6");
                break;
            case Levels.Level_7:
                LevelManager.instance.LoadLevel("Level_7");
                break;
            case Levels.Level_8:
                LevelManager.instance.LoadLevel("Level_8");
                break;
            case Levels.Level_9:
                LevelManager.instance.LoadLevel("Level_9");
                break;
            case Levels.Level_10:
                LevelManager.instance.LoadLevel("Level_10");
                break;

            default:
                break;
        }
    }
}
