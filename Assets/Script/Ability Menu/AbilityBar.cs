using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class AbilityBar : MonoBehaviour
{
    private CustomInput input = null;
    public List<GameObject> CurrentAbilityList;

    private void Awake()
    {
        input = new CustomInput();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Ability.Slot_1.performed += Slot_1_Performed;
        input.Ability.Slot_2.performed += Slot_2_Performed;
        input.Ability.Slot_3.performed += Slot_3_Performed;
        input.Ability.Slot_4.performed += Slot_4_Performed;
        input.Ability.Slot_5.performed += Slot_5_Performed;
        input.Ability.Slot_6.performed += Slot_6_Performed;

    }
    private void OnDisable()
    {
        input.Disable();
        input.Ability.Slot_1.performed -= Slot_1_Performed;
        input.Ability.Slot_2.performed -= Slot_2_Performed;
        input.Ability.Slot_3.performed -= Slot_3_Performed;
        input.Ability.Slot_4.performed -= Slot_4_Performed;
        input.Ability.Slot_5.performed -= Slot_5_Performed;
        input.Ability.Slot_6.performed -= Slot_6_Performed;

    }
    void Update()
    {

        //   ManageInput();

    }

    private void Slot_1_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           // Debug.Log("Alpha 1 Press");
            this.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
    private void Slot_2_Performed(InputAction.CallbackContext context)
    {
        //Debug.Log("Alpha 2 Press");
        this.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
    }
    private void Slot_3_Performed(InputAction.CallbackContext context)
    {
       // Debug.Log("Alpha 3 Press");
        this.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
    }
    private void Slot_4_Performed(InputAction.CallbackContext context)
    {
       // Debug.Log("Alpha 4 Press");
        this.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.Invoke();
    }
    private void Slot_5_Performed(InputAction.CallbackContext context)
    {
       // Debug.Log("Alpha 5 Press");
        this.transform.GetChild(4).gameObject.GetComponent<Button>().onClick.Invoke();
    }
    private void Slot_6_Performed(InputAction.CallbackContext context)
    {
       // Debug.Log("Alpha 6 Press");
        this.transform.GetChild(5).gameObject.GetComponent<Button>().onClick.Invoke();
    }



    void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //  CurrentAbilityList[0].GetComponent<Button>().onClick.Invoke();
           // Debug.Log("Alpha 1 Press");
            this.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
           // Debug.Log("Alpha 2 Press");
            this.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           // Debug.Log("Alpha 3 Press");
            //CurrentAbilityList[1].GetComponent<Button>().onClick.Invoke();
            this.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           // Debug.Log("Alpha 4 Press");
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
