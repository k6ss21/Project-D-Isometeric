using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stairway : MonoBehaviour
{

    public Transform topPoint;
    public Transform bottomPoint;
    public static event Action<Vector3> OnPlayerTeleport;
    public void PlayerToTop()
    {
        OnPlayerTeleport?.Invoke(topPoint.position);
    }

    public void PlayerToBottom()
    {
        OnPlayerTeleport?.Invoke(bottomPoint.position);
    }
}
