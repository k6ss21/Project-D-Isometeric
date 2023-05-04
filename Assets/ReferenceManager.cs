using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one InstructionBox instance in scene");
        }
        instance = this;
    }

    [Header("Player")]
    public UI_BloodOverlay bloodOverlay;
    public TextMeshProUGUI totalSickCount;

    public TextMeshProUGUI healCountText;

    public Slider r_healthBarSlider;
    public Slider l_healthBarSlider;
    public Slider temperatureBarSlider;
    public Slider immunitySlider;


    public Transform labTeleportPoint;
    public Canvas skillCanvas;


}
