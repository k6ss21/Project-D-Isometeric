using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManger : MonoBehaviour
{
    Animator _animator;

    string _currentState;

    #region WALK ANIMATION
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_NE = "Player_walk_NE";
    const string PLAYER_WALK_NW = "Player_walk_NW";
    const string PLAYER_WALK_SE = "Player_walk_SE";
    const string PLAYER_WALK_SW = "Player_walk_SW";

    const string PLAYER_WALK_N = "Player_walk_N";
    const string PLAYER_WALK_W = "Player_walk_W";
    const string PLAYER_WALK_E = "Player_walk_E";
    const string PLAYER_WALK_S = "Player_walk_S";

    #endregion

    #region IDLE ANIMATION
    const string PLAYER_IDLE_NE = "Player_Idle_NE";
    const string PLAYER_IDLE_NW = "Player_Idle_NW";
    const string PLAYER_IDLE_SE = "Player_Idle_SE";
    const string PLAYER_IDLE_SW = "Player_Idle_SW";

    const string PLAYER_IDLE_N = "Player_Idle_N";
    const string PLAYER_IDLE_W = "Player_Idle_W";
    const string PLAYER_IDLE_E = "Player_Idle_E";
    const string PLAYER_IDLE_S = "Player_Idle_S";

    #endregion

    #region ATTACK1 ANIMATION

    const string PLAYER_ATTACK1_NE = "Player_Attack1_NE";
    const string PLAYER_ATTACK1_NW = "Player_Attack1_NW";
    const string PLAYER_ATTACK1_SE = "Player_Attack1_SE";
    const string PLAYER_ATTACK1_SW = "Player_Attack1_SW";

    const string PLAYER_ATTACK1_E = "Player_Attack1_E";
    const string PLAYER_ATTACK1_W = "Player_Attack1_W";
    const string PLAYER_ATTACK1_N = "Player_Attack1_N";
    const string PLAYER_ATTACK1_S = "Player_Attack1_S";

    #endregion



    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayerWalk(string dir)
    {
        switch (dir)
        {
            case "NE":
                ChangeAnimationState(PLAYER_WALK_NE);
                break;
            case "NW":
                ChangeAnimationState(PLAYER_WALK_NW);
                break;
            case "SE":
                ChangeAnimationState(PLAYER_WALK_SE);
                break;
            case "SW":
                ChangeAnimationState(PLAYER_WALK_SW);
                break;
            case "N":
                ChangeAnimationState(PLAYER_WALK_N);
                break;
            case "W":
                ChangeAnimationState(PLAYER_WALK_W);
                break;
            case "E":
                ChangeAnimationState(PLAYER_WALK_E);
                break;
            case "S":
                ChangeAnimationState(PLAYER_WALK_S);
                break;
            default:
                break;
        }

    }

    public void PlayerIdle(string dir)
    {
        switch (dir)
        {
            case "NE":
                ChangeAnimationState(PLAYER_IDLE_NE);
                break;
            case "NW":
                ChangeAnimationState(PLAYER_IDLE_NW);
                break;
            case "SE":
                ChangeAnimationState(PLAYER_IDLE_SE);
                break;
            case "SW":
                ChangeAnimationState(PLAYER_IDLE_SW);
                break;
            case "N":
                ChangeAnimationState(PLAYER_IDLE_N);
                break;
            case "W":
                ChangeAnimationState(PLAYER_IDLE_W);
                break;
            case "E":
                ChangeAnimationState(PLAYER_IDLE_E);
                break;
            case "S":
                ChangeAnimationState(PLAYER_IDLE_S);
                break;

        }
    }

    public void PlayerIdle()
    {
        ChangeAnimationState(PLAYER_IDLE);
    }

    public void Attack(string dir)
    {
        switch (dir)
        {
            case "NE":
                ChangeAnimationState(PLAYER_ATTACK1_NE);
                break;
            case "NW":
                ChangeAnimationState(PLAYER_ATTACK1_NW);
                break;
            case "SE":
                ChangeAnimationState(PLAYER_ATTACK1_SE);
                break;
            case "SW":
                ChangeAnimationState(PLAYER_ATTACK1_SW);
                break;
            case "N":
                ChangeAnimationState(PLAYER_ATTACK1_N);
                break;
            case "S":
                ChangeAnimationState(PLAYER_ATTACK1_S);
                break;
            case "E":
                ChangeAnimationState(PLAYER_ATTACK1_E);
                break;
            case "W":
                ChangeAnimationState(PLAYER_ATTACK1_W);
                break;
        }

    }

    public void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) return;

        _animator.Play(newState);

        _currentState = newState;
    }
}
