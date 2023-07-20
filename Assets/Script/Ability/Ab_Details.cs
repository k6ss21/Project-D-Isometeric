using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_Details : MonoBehaviour
{
    public string name;
    [TextArea(10,20)]
    public string description;

    public int skillPointsNeeded;
}
