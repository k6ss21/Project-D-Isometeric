using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_2_AnimationManager : MonoBehaviour
{
    
    #region WALK ANIMATION
    const string BOSS_ENEMY_2_N = "Boss_Enemet_2_N";
    const string BOSS_ENEMY_2_NE = "Boss_Enemet_2_NE";
    const string BOSS_ENEMY_2_E = "Boss_Enemet_2_E";
    const string BOSS_ENEMY_2_SE = "Boss_Enemet_2_SE";
    const string BOSS_ENEMY_2_S = "Boss_Enemet_2_S";
    const string BOSS_ENEMY_2_W = "Boss_Enemet_2_W";
    const string BOSS_ENEMY_2_SW = "Boss_Enemet_2_SW";
    const string BOSS_ENEMY_2_NW = "Boss_Enemet_2_NW";

    #endregion

    #region IDLE ANIMATION

    const string BOSS_ENEMY_2_IDLE_N = "Boss_Enemet_2_Idle_N";
    const string BOSS_ENEMY_2_IDLE_E = "Boss_Enemet_2_Idle_E";
    const string BOSS_ENEMY_2_IDLE_S = "Boss_Enemet_2_Idle_S";
    const string BOSS_ENEMY_2_IDLE_W = "Boss_Enemet_2_Idle_W";

    const string BOSS_ENEMY_2_IDLE_NW = "Boss_Enemet_2_Idle_NW";
    const string BOSS_ENEMY_2_IDLE_NE = "Boss_Enemet_2_Idle_NE";
    const string BOSS_ENEMY_2_IDLE_SW = "Boss_Enemet_2_Idle_SW";
    const string BOSS_ENEMY_2_IDLE_SE = "Boss_Enemet_2_Idle_SE";

    #endregion

    #region ATTACK ANIMATION

    const string BOSS_ENEMY_2_ATTACK1_N = "Boss_Enemet_2_Attack1_N";
    const string BOSS_ENEMY_2_ATTACK1_E = "Boss_Enemet_2_Attack1_E";
    const string BOSS_ENEMY_2_ATTACK1_S = "Boss_Enemet_2_Attack1_S";
    const string BOSS_ENEMY_2_ATTACK1_W = "Boss_Enemet_2_Attack1_W";

    const string BOSS_ENEMY_2_ATTACK1_NE = "Boss_Enemet_2_Attack1_NE";
    const string BOSS_ENEMY_2_ATTACK1_NW = "Boss_Enemet_2_Attack1_NW";
    const string BOSS_ENEMY_2_ATTACK1_SE = "Boss_Enemet_2_Attack1_SE";
    const string BOSS_ENEMY_2_ATTACK1_SW = "Boss_Enemet_2_Attack1_SW";

    #endregion


    public Animator animator;

    string _currentState;


    public void Walk(string dir)
    {
        switch (dir)
        {
            case "N":
                ChangeAnimationState(BOSS_ENEMY_2_N);
                break;
            case "NE":
                ChangeAnimationState(BOSS_ENEMY_2_NE);
                break;
            case "E":
                ChangeAnimationState(BOSS_ENEMY_2_E);
                break;
            case "SE":
                ChangeAnimationState(BOSS_ENEMY_2_SE);
                break;
            case "S":
                ChangeAnimationState(BOSS_ENEMY_2_S);
                break;
            case "W":
                ChangeAnimationState(BOSS_ENEMY_2_W);
                break;
            case "SW":
                ChangeAnimationState(BOSS_ENEMY_2_SW);
                break;
            case "NW":
                ChangeAnimationState(BOSS_ENEMY_2_NW);
                break;
            default:
                break;

        }

    }

    public void Idle(string dir)
    {
        switch (dir)
        {
            case "N":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_N);
                break;
            case "E":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_E);
                break;
            case "S":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_S);
                break;
            case "W":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_W);
                break;

            case "NE":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_NE);
                break;
            case "NW":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_NW);
                break;
            case "SE":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_SE);
                break;
            case "SW":
                ChangeAnimationState(BOSS_ENEMY_2_IDLE_SW);
                break;
            default:
                break;

        }
    }

    public void Attack1(string dir)
    {
        switch (dir)
        {
            case "N":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_N);
                break;
            case "E":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_E);
                break;
            case "S":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_S);
                break;
            case "W":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_W);
                break;

            case "NE":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_NE);
                break;
            case "NW":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_NW);
                break;
            case "SE":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_SE);
                break;
            case "SW":
                ChangeAnimationState(BOSS_ENEMY_2_ATTACK1_SW);
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
