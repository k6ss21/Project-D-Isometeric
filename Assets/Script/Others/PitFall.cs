using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{
    public bool pitFightActive;
    public bool pitFightCompleted;
    public int totalSickCount;
    public int healedSickCount;
    private IsoCharacterController isoCharacterController;
    [SerializeField] private Transform pitPos;

    void OnEnable()
    {
        SickChar.OnHealComplete += AddSickCount;
    }
    void OnDisable()
    {
        SickChar.OnHealComplete += AddSickCount;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!pitFightCompleted)
        {
            if (other.CompareTag("Player"))
            {
                pitFightActive = true;
                isoCharacterController =other.GetComponent<IsoCharacterController>();
                isoCharacterController.Teleport(pitPos.position);
            }
        }
    }
    void AddSickCount(SickChar sickChar)
    {
        if (pitFightActive)
        {
            healedSickCount += 1;
            if(healedSickCount >= totalSickCount)
            {
                pitFightActive = false;
                pitFightCompleted = true;
                isoCharacterController.TeleportToLastPos();
            }
        }

    }


}
