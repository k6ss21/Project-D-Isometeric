using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOver_UI : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject abilityUseCanvas;
     [SerializeField] GameObject DeadCanvas;
    [SerializeField] TextMeshProUGUI timerText;
    private float timer;
    private float sec;

    void OnEnable()
    {
        Player.OnPlayerDead += PopUp;
    }
    void OnDisable()
    {
        Player.OnPlayerDead -= PopUp;
    }
    void Start()
    {
        abilityUseCanvas.SetActive(false);
         DeadCanvas.SetActive(false);
    }
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            sec = Mathf.FloorToInt(timer % 60);
            UpdateTimerText();
        }
        


    }

    void PopUp()
    {
        abilityUseCanvas.SetActive(true);
        timer = time;
    }

    void UpdateTimerText()
    {
        timerText.text = sec.ToString();
    }
    IEnumerator ShowDeadText()
    {
        yield return new WaitForSeconds(time);
        abilityUseCanvas.SetActive(false);
        DeadCanvas.SetActive(true);

    }
}
