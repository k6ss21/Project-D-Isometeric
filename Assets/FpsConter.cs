using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsConter : MonoBehaviour
{
    private float count;
    public TextMeshProUGUI text;
    private IEnumerator  Start()
    {
        while(true)
        {
            count = 1f/Time.unscaledDeltaTime;
            yield return new WaitForSeconds(.1f);

        }
    }

    void Update()
    {
        int c = (int)count;
        text.text = c.ToString();
    }
   
}
