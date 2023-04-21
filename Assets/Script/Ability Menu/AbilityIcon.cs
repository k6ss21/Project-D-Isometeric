using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class AbilityIcon : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    public bool isLocked;

    public GameObject abilityButtonPrefab;
    public GameObject draggingObj;
    RectTransform draggingObjRectTransform;

    public static event Action<string, string, AbilityIcon> OnAbilityIconClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        Ab_Details ab_Details = abilityButtonPrefab.GetComponent<Ab_Details>();
        OnAbilityIconClick?.Invoke(ab_Details.name,ab_Details.description, this);
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) return;

        if (isLocked) { InstructionBox.instance.SpawnInstructionPopUpText("Ability Locked!!"); return; }
        //   Debug.Log("OnBeginDrag");
        draggingObj = Instantiate(this.gameObject, transform.position, Quaternion.identity);
        draggingObj.transform.SetParent(transform.root);
        draggingObj.transform.SetAsLastSibling();
        draggingObjRectTransform = draggingObj.GetComponent<RectTransform>();
        draggingObjRectTransform.sizeDelta = new Vector2(70, 70);
        draggingObj.GetComponent<Image>().raycastTarget = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDragging");
        if (eventData.button == PointerEventData.InputButton.Right) return;
        if (isLocked) { InstructionBox.instance.SpawnInstructionPopUpText("Ability Locked!!"); return; }
        draggingObjRectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag");

        if (eventData.button == PointerEventData.InputButton.Right) return;
        if (isLocked) { InstructionBox.instance.SpawnInstructionPopUpText("Ability Locked!!"); return; }
        if (draggingObj.transform.parent == transform.root)
        {
            Destroy(draggingObj);
        }
        draggingObj.GetComponent<Image>().raycastTarget = true;

    }


}
