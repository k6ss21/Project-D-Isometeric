using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityBar : MonoBehaviour
{
    public List<GameObject> CurrentAbilityList;

    void Update()
    {

        ManageInput();

    }

    void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //  CurrentAbilityList[0].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
