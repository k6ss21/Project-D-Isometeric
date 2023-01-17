using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AnimationManager : MonoBehaviour, IAnimationManager
{

    const string BOSS_ENEMY_1_N = "Boss_Enemy_1_N";
    const string BOSS_ENEMY_1_NE = "Boss_Enemy_1_NE";
    const string BOSS_ENEMY_1_E = "Boss_Enemy_1_E";
    const string BOSS_ENEMY_1_SE = "Boss_Enemy_1_SE";
    const string BOSS_ENEMY_1_S = "Boss_Enemy_1_S";
    const string BOSS_ENEMY_1_W = "Boss_Enemy_1_W";
    const string BOSS_ENEMY_1_SW = "Boss_Enemy_1_SW";
    const string BOSS_ENEMY_1_NW = "Boss_Enemy_1_NW";

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
        if (_currentState == newState) return;

        animator.Play(newState);

        _currentState = newState;
    }



}
