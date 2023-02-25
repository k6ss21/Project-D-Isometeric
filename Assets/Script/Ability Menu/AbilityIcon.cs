using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public GameObject abilityButtonPrefab;
    public GameObject draggingObj;
    RectTransform draggingObjRectTransform;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) return;
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
        draggingObjRectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // Debug.Log("OnEndDrag");

        if (eventData.button == PointerEventData.InputButton.Right) return;
        if (draggingObj.transform.parent == transform.root)
        {
            Destroy(draggingObj);
        }
        draggingObj.GetComponent<Image>().raycastTarget = true;

    }
}
