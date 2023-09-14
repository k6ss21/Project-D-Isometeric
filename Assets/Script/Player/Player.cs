using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
public class Player : MonoBehaviour, IDataPersistence
{

    IsoCharacterController isoCharacterController;


    private PlayerAttack playerAttack;
    private int totalSickCount;
    [SerializeField] private TextMeshProUGUI totalSickCountText;
    [SerializeField] private UI_BloodOverlay bloodOverlay;
    [SerializeField] public Transform playerLegPos;

    void OnEnable()
    {
        SickChar.OnHealComplete += AddHealCount;
        EnemyAI.OnAttack += TakeDamage;
        SickChar.OnSetHealing += SetHealing;

        //Ability Events
        Ab_Healing.OnAbilityHeal += TakeHealth;
        Ab_shield.OnShieldActive += ActivateShield;
        Ab_Immunity.OnImmunityTrigger += IntakeImmunity;
        Ab_WarmUp.OnWarmUpTrigger += WarmUp;
    }
    void OnDisable()
    {
        SickChar.OnHealComplete -= AddHealCount;
        EnemyAI.OnAttack -= TakeDamage;
        SickChar.OnSetHealing -= SetHealing;

        //Ability Events
        Ab_Healing.OnAbilityHeal -= TakeHealth;
        Ab_shield.OnShieldActive -= ActivateShield;
        Ab_Immunity.OnImmunityTrigger -= IntakeImmunity;
        Ab_WarmUp.OnWarmUpTrigger -= WarmUp;
    }

    void Awake()
    {

    }

    void Start()
    {
        bloodOverlay = ReferenceManager.instance.bloodOverlay;
        totalSickCountText = ReferenceManager.instance.totalSickCount;
        _healCountText = ReferenceManager.instance.healCountText;
        r_healthBarSlider = ReferenceManager.instance.r_healthBarSlider;
        l_healthBarSlider = ReferenceManager.instance.l_healthBarSlider;
        temperatureBarSlider = ReferenceManager.instance.temperatureBarSlider;
        immunitySlider = ReferenceManager.instance.immunitySlider;
        playerAttack = GetComponent<PlayerAttack>();
        isoCharacterController = GetComponent<IsoCharacterController>();
        UpdateHealCountText();
        currentHealth = health;
        currentTemperature = temperature;
        currentImmunity = totalImmunity;
        UpdateHealthBar();
        UpdateTemperatureBar();
        UpdateImmunitySlider();
        coolTimer = coolInterval;
        totalSickCount =  FindObjectOfType<GameEventManager>().sickPersonCount;
        totalSickCountText.text = totalSickCount.ToString();
        DeActivateShield();

    }
    void Update()
    {
        CoolOverTime();
        AutoSelfHeal(); //Auto heal when health is low 95
        TakeImmunityTimer();
        CheckLowImmunity();

        // if (Input.GetKeyDown(KeyCode.K))    //Test Input
        // {
        //     // ScreenCapture.CaptureScreenshot("screenshot.png");
        //     // Debug.Log("SS Taken");
        //     //TakeImmunity(20);
        //     //LevelManager.instance.LoadNextLevel();
        //     OnPlayerDead?.Invoke();
        // }
        if (isLowTemp)
        {
            LowTemperatureEffect();
        }


    }

    #region DATA PERSISTENCE

    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {

    }

    #endregion


    #region OTHERS
    public List<Transform> followPoints = new List<Transform>();
    public Transform RandomFollowPos()
    {
        int rdm = Random.Range(0, followPoints.Count);
        return followPoints[rdm];

    }
    public void EnableInput(bool b)
    {
        isoCharacterController.canMove = b;
        playerAttack.canAttack = b;
    }

    public void RechargePlayer()
    {
        currentHealth = health;
        currentTemperature = temperature;
        currentImmunity = totalImmunity;
        UpdateHealthBar();
        UpdateImmunitySlider();
        UpdateTemperatureBar();
    }




    #endregion

    #region HEALING SICK CHAR

    public int healCount; //Sick Char Healed Count.
    public bool IsHealing = false;
    public TextMeshProUGUI _healCountText;

    public static event Action OnAllSickHealed;

    void AddHealCount(SickChar sickChar) //ADD Heal count to Update UI.
    {
        healCount++;
        IsHealing = false;
        UpdateHealCountText();
        TakeImmunity(10); // Reduce immunity after Healing
        if(healCount == totalSickCount)
        {
            OnAllSickHealed?.Invoke();
        }
    }

    void UpdateHealCountText() //Update Heal Count UI.
    {
        _healCountText.text = healCount.ToString();
    }

    void SetHealing(bool healing)
    {
        IsHealing = healing;
    }
   

    #endregion

    #region Health

    [Header("Heath")]
    public float health;
    float currentHealth;
    public Slider r_healthBarSlider;
    public Slider l_healthBarSlider;

    bool invulnerability;

    public static event Action OnPlayerDead;
    public void TakeDamage(float damage)
    {
        if (!invulnerability)
        {
            //Debug.Log("Taking Damage(player)" );
            bloodOverlay.ShowBloodOverlay();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.PlayerHurt, this.transform.position);
            currentHealth -= damage;
            UpdateHealthBar();
            if (currentHealth <= 0)
            {
                OnPlayerDead?.Invoke();
                this.gameObject.SetActive(false);
                Debug.Log("Player Is DEAD!!");
            }
        }
        else
        {
            Debug.Log("Invulnerable");
        }
    }

    public void TakeHealth(float h)
    {

        currentHealth += h;
        UpdateHealthBar();
        if (currentHealth >= health)
        {
            currentHealth = health;
        }
    }

    public void UpdateHealthBar()
    {
        float value = currentHealth / health;
        r_healthBarSlider.value = value;
        l_healthBarSlider.value = value;
    }


    #endregion

    #region TEMPERATURE

    [Header("Temperature")]
    [SerializeField] private float temperature; //Total Body Temperature
    private float currentTemperature; // Current Temperature
    [SerializeField] private Slider temperatureBarSlider; //UI Slider for temperature 
    private float coolTimer;
    [SerializeField] private float coolInterval;
    [SerializeField] private float coolRate;

    private float lowTempTimer;
    [SerializeField] private float lowTempEffectInterval;
    [SerializeField] private float lowTempDamage;

    private bool isLowTemp;

    public void CoolOverTime()
    {
        coolTimer -= Time.deltaTime;

        if (coolTimer <= 0)
        {
            CoolDown(coolRate);
            coolTimer = coolInterval;
        }
    }
    public void CoolDown(float temp) //Function for decrease player temp
    {
        currentTemperature -= temp;
        UpdateTemperatureBar();
        if (currentTemperature <= 0)
        {
            currentTemperature = 0;
            isLowTemp = true;
        }
        else
        {
            isLowTemp = false;
        }
    }

    public void WarmUp(float temp) //Function for Increase player temp
    {

        currentTemperature += temp;

        UpdateTemperatureBar();
        if (currentTemperature >= temperature)
        {
            currentTemperature = temperature;
        }
    }

    public void UpdateTemperatureBar()
    {
        float value = currentTemperature / temperature;
        temperatureBarSlider.value = value;
    }

    public void LowTemperatureEffect()
    {
        lowTempTimer -= Time.deltaTime;

        if (lowTempTimer <= 0)
        {
            TakeDamage(lowTempDamage);
            lowTempTimer = lowTempEffectInterval;
            //ADD CAMERA SHAKE LATER
        }

    }
    #endregion

    #region INFECTION

    [Header("Immunity")]
    [Space(5)]
    public float totalImmunity;
    float currentImmunity;

    float ImmunityLossTimer;
    public float ImmunityLossInterval;

    public bool lowImmunity;

    bool immunityLossTimeOut;

    public Slider immunitySlider;

    void TakeImmunityTimer()
    {
        ImmunityLossTimer -= Time.deltaTime;
        if (ImmunityLossTimer <= 0)
        {
            immunityLossTimeOut = false;
        }
        else
        {
            immunityLossTimeOut = true;
        }

    }

    public void IntakeImmunity(float value)
    {
        currentImmunity += value;
        UpdateImmunitySlider();
          if (currentImmunity >= totalImmunity)
        {
            currentImmunity = totalImmunity;
            UpdateImmunitySlider();
            //DO SOMETHING
        }
    }

    public void TakeImmunity(float value)
    {
        if (immunityLossTimeOut) return;
        currentImmunity -= value;
        ImmunityLossTimer = ImmunityLossInterval;
        UpdateImmunitySlider();
        if (currentImmunity <= 0)
        {
            currentImmunity = 0;
            UpdateImmunitySlider();
            //DO SOMETHING
        }
    }

    void UpdateImmunitySlider()
    {
        float value = currentImmunity / totalImmunity;
        immunitySlider.value = value;
    }

    void CheckLowImmunity()
    {
        if (currentImmunity <= 20)
        {
            lowImmunity = true;
        }
        else
        {
            lowImmunity = false;
        }
    }


    #endregion


    #region  Self Funtions

    public float selfHealInterval;
    float selfHealTimer;
    public float selfHealRate;
    void AutoSelfHeal()
    {
        selfHealTimer -= Time.deltaTime;

        if (!isLowTemp && health >= 95 && selfHealTimer <= 0)
        {
            TakeHealth(selfHealRate);
            selfHealTimer = selfHealInterval;
        }
    }
    #endregion

    #region SHIELD
    [Header("Heath")]
    [Space(5)]
    public GameObject shield;

    void ActivateShield(float time)
    {
        shield.SetActive(true);
        invulnerability = true;
        StartCoroutine(InvulnerableTimer(time));

    }
    IEnumerator InvulnerableTimer(float time)
    {
        yield return new WaitForSeconds(time);
        DeActivateShield();
    }

    void DeActivateShield()
    {
        invulnerability = false;
        shield.SetActive(false);

    }



    #endregion


}



