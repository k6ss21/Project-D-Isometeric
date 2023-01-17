using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManger : MonoBehaviour
{
    Animator _animator;

    string _currentState;

    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_NE = "Player_walk_NE";
    const string PLAYER_WALK_NW = "Player_walk_NW";
    const string PLAYER_WALK_SE = "Player_walk_SE";
    const string PLAYER_WALK_SW = "Player_walk_SW";

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayerWalk(int dir)
    {   
        switch(dir)
        {
            case 1:
            ChangeAnimationState(PLAYER_WALK_NE);
            break;
            case 2:
            ChangeAnimationState(PLAYER_WALK_NW);
            break;
            case 3:
            ChangeAnimationState(PLAYER_WALK_SE);
            break;
            case 4:
            ChangeAnimationState(PLAYER_WALK_SW);
            break;
            default:
            break;
        }

    }

    public void PlayerIdle()
    {
        ChangeAnimationState(PLAYER_IDLE);
    }


    public void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) return;

        _animator.Play(newState);

        _currentState = newState;
    }
}
