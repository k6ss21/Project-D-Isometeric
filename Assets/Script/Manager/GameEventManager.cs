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
    [Header("Flyinng Enemy Wave Settings")]
    [SerializeField] private float minTime; //Min time for flying enemy wave
    [SerializeField] private float maxTime; //Max time for flying enemy wave
    public static event Action OnSpawnWaveCall;
    [Space(10)]
    public bool topDown;

    public int sickPersonCount;

    [Header("Level Timer Settings")]
    [SerializeField]private float maxLevelTimer;
    private float timeRemaining;
    [SerializeField]private float defaultTimeMulti;
    private float timeMulti;
    private float min;
    private float sec;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI minText; //Minute Text
    [SerializeField] private TextMeshProUGUI secText; //Sec Text

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
        min = Mathf.FloorToInt(timeRemaining / 60);
        sec = Mathf.FloorToInt(timeRemaining % 60);
        UpdateTimerText();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        timeRemaining -= Time.deltaTime * timeMulti;
        min = Mathf.FloorToInt(timeRemaining / 60);
        sec = Mathf.FloorToInt(timeRemaining % 60);
        UpdateTimerText();
        GameOverCheck();

        if (spawnTimer <= 0)
        {
            OnSpawnWaveCall?.Invoke();
            spawnTimer = Random.Range(minTime, maxTime);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnSpawnWaveCall?.Invoke();
        }

    }

    void GameOverCheck()

    {
        if (timeRemaining <= 0)
        {
            Debug.Log("TIMEOUT!!! GAME OVER!!");
        }
    }

    void UpdateTimerText()
    {
        minText.text = min.ToString("00");
        secText.text = sec.ToString("00");
    }

    void SlowTimerSpeed(float multi, float time)
    {
        Debug.Log("Slow Timer"+ multi);
        timeMulti = multi;
        StartCoroutine(SlowTimerRoutine(time));
    }

    IEnumerator SlowTimerRoutine(float time)
    {

        yield return new WaitForSeconds(time);
        timeMulti = defaultTimeMulti;
    }
}

