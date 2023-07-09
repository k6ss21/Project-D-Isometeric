using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlatformManager : MonoBehaviour
{

    public List<GameObject> nextGridPlatForms;
    public List<GameObject> nextPlatFormItems;
    public List<GameObject> nextSicks;
    public GameObject lights;
    public GameObject currentSicks;
    public bool playerPresent = false;

    void Start()
    {
        lights.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            playerPresent = true;
            lights.SetActive(true);
            foreach (GameObject platform in nextGridPlatForms)
            {
                platform.SetActive(false);
            }
            foreach (GameObject items in nextPlatFormItems)
            {
                items.SetActive(false);
            }
            try
            {
                foreach (GameObject sicks in nextSicks)
                {
                    sicks.SetActive(false);
                }
            }
            catch (System.Exception)
            {

                Debug.Log("No Sicks...");
            }



        }


    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = false;
            // foreach(GameObject platform in nextGridPlatForms)
            // {
            //     platform.SetActive(true);
            // }
            nextGridPlatForms[0].SetActive(true);
            lights.SetActive(false);
            foreach (GameObject items in nextPlatFormItems)
            {
                items.SetActive(true);
            }

        }

    }
}
