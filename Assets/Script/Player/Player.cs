using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    IsoCharacterController isoCharacterController;


    private PlayerAttack playerAttack;

    [SerializeField] private TextMeshProUGUI totalSickCount;
    [SerializeField] private UI_BloodOverlay bloodOverlay;

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
        isoCharacterController = GetComponent<IsoCharacterController>();
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
        CheckLowImmunity();

        if (Input.GetKeyDown(KeyCode.K))    //Test Input
        {
            // ScreenCapture.CaptureScreenshot("screenshot.png");
            // Debug.Log("SS Taken");
            TakeImmunity(20);
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

    void AddHealCount(SickChar sickChar) //ADD Heal count to Update UI.
    {
        healCount++;
        IsHealing = false;
        UpdateHealCountText();
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



