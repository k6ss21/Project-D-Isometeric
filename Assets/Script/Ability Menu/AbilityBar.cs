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
            Debug.Log("Alpha 1 Press");
            this.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            Debug.Log("Alpha 2 Press");
            this.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Alpha 3 Press");
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Alpha 4 Press");
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(4).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(5).gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
