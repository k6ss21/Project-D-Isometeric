using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsConter : MonoBehaviour
{
    private float count;
    private IEnumerator  Start()
    {
        GUI.depth = 2;
        while(true)
        {
            count = 1f/Time.unscaledDeltaTime;
            yield return new WaitForSeconds(.1f);

        }
    }
    private void  OnGUI()
    {
        GUI.Label(new Rect(5, 40,100, 25), "FPS:" + Mathf.Round(count));
    }
}
