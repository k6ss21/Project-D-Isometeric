using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRat_AnimationManager : MonoBehaviour, IAnimationManager
{
    const string BOSS_ENEMY_1_N = "Rat_Enemy_N";
    const string BOSS_ENEMY_1_NE = "Rat_Enemy_NE";
    const string BOSS_ENEMY_1_E = "Rat_Enemy_E";
    const string BOSS_ENEMY_1_SE = "Rat_Enemy_SE";
    const string BOSS_ENEMY_1_S = "Rat_Enemy_S";
    const string BOSS_ENEMY_1_W = "Rat_Enemy_W";
    const string BOSS_ENEMY_1_SW = "Rat_Enemy_SW";
    const string BOSS_ENEMY_1_NW = "Rat_Enemy_NW";

    public Animator animator;

    string _currentState;


    public void Walk(string dir)
    {
        switch (dir)
        {
            case "N":
                ChangeAnimationState(BOSS_ENEMY_1_N);
                break;
            case "NE":
                ChangeAnimationState(BOSS_ENEMY_1_NE);
                break;
            case "E":
                ChangeAnimationState(BOSS_ENEMY_1_E);
                break;
            case "SE":
                ChangeAnimationState(BOSS_ENEMY_1_SE);
                break;
            case "S":
                ChangeAnimationState(BOSS_ENEMY_1_S);
                break;
            case "W":
                ChangeAnimationState(BOSS_ENEMY_1_W);
                break;
            case "SW":
                ChangeAnimationState(BOSS_ENEMY_1_SW);
                break;
            case "NW":
                ChangeAnimationState(BOSS_ENEMY_1_NW);
                break;
            default:
                break;

        }

    }
    public void ChangeAnimationState(string newState)
    {
        Debug.Log("change animation state");
        if (_currentState == newState) return;

        animator.Play(newState);

        _currentState = newState;
    }

}
