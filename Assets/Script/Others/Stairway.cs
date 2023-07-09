using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stairway : MonoBehaviour
{

    public Transform topPoint;
    public Transform bottomPoint;
    private int count = 0;
    public bool singleUse = false;
    public static event Action<Vector3> OnPlayerTeleport;
    public void PlayerToTop()
    {
        if (singleUse)
        {
            if (count == 0)
            {
                OnPlayerTeleport?.Invoke(topPoint.position);
                count++;
            }
        }
        else
        {
            OnPlayerTeleport?.Invoke(topPoint.position);
        }

    }

    public void PlayerToBottom()
    {
        if (singleUse)
        {
            if (count == 0)
            {
                OnPlayerTeleport?.Invoke(bottomPoint.position);
                count++;
            }
        }
        else
        {
            OnPlayerTeleport?.Invoke(bottomPoint.position);
        }
    }
}
