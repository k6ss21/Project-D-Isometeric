using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour, IDropHandler
{
    Image IconImage;
   public GameObject abilityPrefab;

    AbilitySpace abilitySpace;
    public void OnDrop(PointerEventData eventData)
    {
      //  Debug.Log("Ondrop");
        if (eventData.pointerDrag != null)
        {
            
            var abilityDragObj = eventData.pointerDrag.GetComponent<AbilityIcon>();
            IconImage.sprite = abilityDragObj.draggingObj.GetComponent<Image>().sprite;
            abilityPrefab = abilityDragObj.abilityButtonPrefab;
            abilitySpace.UpdateList();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        IconImage = GetComponent<Image>();
        abilitySpace = GetComponentInParent<AbilitySpace>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
