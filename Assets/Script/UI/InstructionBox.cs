using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBox : MonoBehaviour
{
   public  GameObject instructionLogPrefab;
   public static InstructionBox instance;

   // int count = 1;
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.P))
    //     {

    //         SpawnInstructionPopUpText("this Is A Test "+ count);
    //         count++;
    //     }
    // }

    void Awake()
    {
           if (instance != null)
        {
            Debug.LogError("Found more than one InstructionBox instance in scene");
        }
        instance = this;
    }
    public void SpawnInstructionPopUpText(string text)
    {
        var InstructionLogGameObj = Instantiate(instructionLogPrefab,transform.position,Quaternion.identity);
        InstructionLogGameObj.transform.parent = transform;
        InstructionLogGameObj.GetComponent<InstructionLog>().ChangeText(text);
    }
}
