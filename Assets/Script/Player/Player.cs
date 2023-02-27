using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player : MonoBehaviour
{


    public PlayerAttack playerAttack;

    public TextMeshProUGUI totalSickCount;


    void OnEnable()
    {
        SickChar.OnHealComplete += AddHealCount;
        EnemyAI.OnAttack += TakeDamage;
        SickChar.OnSetHealing += SetHealing;

        //Ability Events
        Ab_Healing.OnAbilityHeal += TakeHealth;
        Ab_shield.OnShieldActive += ActivateShield;
    }
    void OnDisable()
    {
        SickChar.OnHealComplete -= AddHealCount;
        EnemyAI.OnAttack -= TakeDamage;
        SickChar.OnSetHealing -= SetHealing;

        //Ability Events
        Ab_Healing.OnAbilityHeal -= TakeHealth;
    }

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        UpdateHealCountText();
        currentHealth = health;
        currentTemperature = temperature;
        currentImmunity = totalImmunity;
        UpdateHealthBar();
        UpdateTemperatureBar();
        UpdateImmunitySlider();
        coolTimer = coolInterval;
        totalSickCount.text = FindObjectOfType<GameEventManager>().sickPersonCount.ToString();
        DeActivateShield();

    }
    void Update()
    {
        CoolOverTime();
        AutoSelfHeal(); //Auto heal when health is low 95
        TakeImmunityTimer();

        if (Input.GetKeyDown(KeyCode.K))    //Test Input
        {

        }
        if (isLowTemp)
        {
            LowTemperatureEffect();
        }


    }

    #region OTHERS
    public List<Transform> followPoints = new List<Transform>();
    public Transform RandomFollowPos()
    {
        int rdm = Random.Range(0,followPoints.Count);
        return  followPoints[rdm];
        
    }   

    #endregion

    #region HEALING SICK CHAR

    public int healCount;
    public bool IsHealing = false;
    public TextMeshProUGUI _healCountText;

    void AddHealCount() //ADD H
    {
        healCount++;
        IsHealing = false;
        UpdateHealCountText();
    }

    void UpdateHealCountText()
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
    public Slider healthBarSlider;

    bool invulnerability;
    public void TakeDamage(float damage)
    {
        if (!invulnerability)
        {
            //Debug.Log("Taking Damage(player)" );
            currentHealth -= damage;
            UpdateHealthBar();
            if (currentHealth <= 0)
            {
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
        healthBarSlider.value = value;
    }


    #endregion

    #region TEMPERATURE

    [Header("Temperature")]
    public float temperature; //Total Body Temperature
    float currentTemperature; // Current Temperature
    public Slider temperatureBarSlider; //UI Slider for temperature 
    float coolTimer;
    public float coolInterval;
    public float coolRate;

    float lowTempTimer;
    public float lowTempEffectInterval;
    public float lowTempDamage;

    bool isLowTemp;

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
            TakeDamage(5);
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

    public void TakeImmunity(float value)
    {
        if (immunityLossTimeOut) return;
        currentImmunity -= value;
        ImmunityLossTimer = ImmunityLossInterval;
        UpdateImmunitySlider();
        if (currentImmunity <= 0)
        {
            currentImmunity = 0;
            //DO SOMETHING
        }
    }

    void UpdateImmunitySlider()
    {
        float value = currentImmunity / totalImmunity;
        immunitySlider.value = value;
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



