using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_SkyFallAimRef : MonoBehaviour
{

    public bool canSetAim;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("PlayZone"))
        {

            canSetAim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("PlayZone"))
        {
            canSetAim = false;
        }

    }
}
