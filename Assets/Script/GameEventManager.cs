using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using TMPro;
public class GameEventManager : MonoBehaviour
{
    private float spawnTimer;
    public float minTime; //Min time for flying enemy wave
    public float maxTime; //Max time for flying enemy wave
    public static event Action OnSpawnWaveCall;

    public bool topDown;

    public int sickPersonCount;

    public float maxLevelTimer;
    private float timeRemaining;

   public float defaultTimeMulti;
    private float timeMulti;
    private float min;
    private float sec;
    public TextMeshProUGUI minText; //Minute Text
    public TextMeshProUGUI secText; //Sec Text

    void OnEnable()
    {
        Ab_SlowLevelTimer.OnSlowLevelTimer += SlowTimerSpeed;
    }
    void OnDisable()
    {
        Ab_SlowLevelTimer.OnSlowLevelTimer -= SlowTimerSpeed;
    }
    void Start()
    {
        spawnTimer = Random.Range(minTime, maxTime);
        timeMulti = defaultTimeMulti;
        timeRemaining = maxLevelTimer;
        min=  Mathf.FloorToInt(timeRemaining/60);
        sec = Mathf.FloorToInt(timeRemaining%60);
        UpdateTimerText();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        timeRemaining -= Time.deltaTime * timeMulti;
        min=  Mathf.FloorToInt(timeRemaining/60);
        sec = Mathf.FloorToInt(timeRemaining%60);
        UpdateTimerText();
        GameOverCheck();

        if (spawnTimer <= 0)
        {
            OnSpawnWaveCall?.Invoke();
            spawnTimer = Random.Range(minTime, maxTime);

        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
             OnSpawnWaveCall?.Invoke();
        }

    }

    void GameOverCheck()

    {
        if(timeRemaining<=0)
        {
            Debug.Log("TIMEOUT!!! GAME OVER!!");
        }
    }

    void UpdateTimerText()
    {
        minText.text = min.ToString();
        secText.text = sec.ToString();
    }

    void SlowTimerSpeed(float multi, float time)
    {
        timeMulti = multi;
        StartCoroutine(SlowTimerRoutine(time));
    }

    IEnumerator SlowTimerRoutine(float time)
    {

        yield return new WaitForSeconds(time);
        timeMulti = defaultTimeMulti;
    }
} 

