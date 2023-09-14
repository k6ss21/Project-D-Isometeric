using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class GameOver : MonoBehaviour
{
    [SerializeField] int xpLossAmount;
    [SerializeField] float time;
    [SerializeField] GameObject abilityUseCanvas;
    [SerializeField] GameObject DeadCanvas;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject timeOutCanvas;

    private float timer;
    private float sec;
    private Coroutine DeadTextCoroutine;
    public static event Action<int> OnRetry;

    void OnEnable()
    {
        Player.OnPlayerDead += AbiilityUsePopUp;
        GameEventManager.OnTimeOutCall += TimeOutPopUp;
        Ab_Regenesis.OnRegenesisCall += StopDeadTextCoroutine;
    }
    void OnDisable()
    {
        Player.OnPlayerDead -= AbiilityUsePopUp;
        GameEventManager.OnTimeOutCall -= TimeOutPopUp;
        Ab_Regenesis.OnRegenesisCall -= StopDeadTextCoroutine;
    }
    void Start()
    {
        abilityUseCanvas.SetActive(false);
        DeadCanvas.SetActive(false);
        timeOutCanvas.SetActive(false);
        Time.timeScale = 1;
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

    void AbiilityUsePopUp()
    {
        abilityUseCanvas.SetActive(true);
        timer = time;
        DeadTextCoroutine = StartCoroutine(ShowDeadText());
    }
    void StopDeadTextCoroutine()
    {
        abilityUseCanvas.SetActive(false);
        StopCoroutine(DeadTextCoroutine); // Stop ShowDeadText Coroutine When player Respawned.
    }
    void TimeOutPopUp()
    {

        timeOutCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator ShowDeadText()
    {
        yield return new WaitForSeconds(time + .5f);
        abilityUseCanvas.SetActive(false);
        DeadCanvas.SetActive(true);
        Time.timeScale = 0;

    }
    void UpdateTimerText()
    {
        timerText.text = sec.ToString();
    }
    public void RetryButton()
    {
        //  Time.timeScale = 1;
        OnRetry?.Invoke(xpLossAmount);
        LevelManager.instance.ReloadLevel();
    }
}
