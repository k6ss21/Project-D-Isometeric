using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public float angle;
    public Transform projectilePf;


    void OnEnable()
    {
        SickChar.OnHealComplete += AddHealCount;
        EnemyAI.OnAttack += TakeDamage;
        SickChar.OnSetHealing += SetHealing;
    }
    void OnDisable()
    {
        SickChar.OnHealComplete -= AddHealCount;
        EnemyAI.OnAttack -= TakeDamage;
        SickChar.OnSetHealing -= SetHealing;
    }

    void Start()
    {
        UpdateHealCountText();
        currentHealth = health;
        currentTemperature = temperature;
        UpdateHealthBar();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CoolDown(10);
        }
    }

    #region HEALING

    public int healCount;
    public bool IsHealing = false;
    public TextMeshProUGUI _healCountText;

    void AddHealCount()
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
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Debug.Log("Player Is DEAD!!");
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

    public void CoolDown(float temp) //Function for decrease player temp
    {
        currentTemperature -= temp;
        UpdateTemperatureBar();
        if (currentTemperature <= 0)
        {
            //Do Something
        }
    }

    public void WarmUp(float temp) //Function for Increase player temp
    {
        currentHealth += temp;
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

    #endregion
    void Attack()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var projectile = Instantiate(projectilePf, transform.position, Quaternion.identity);

        Vector3 shootDir = (mousePos - transform.position).normalized;
        angle = GetAngleFromVectorFloat(shootDir);
        ChangeDirectionUsingAngle();
        projectile.GetComponent<Projectile>().Setup(shootDir);

        //CinemachineCameraShake.Instance.ShakeCamera(.2f, .05f); // Fix  it Later..
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    void ChangeDirectionUsingAngle()
    {
        if (angle <= 75 && angle >= 15)
        {
            Debug.Log("NE");
        }
        if (angle <= 14 && angle >= 346)
        {
            Debug.Log("E");
        }
        if (angle <= 345 && angle >= 285)
        {
            Debug.Log("SE");
        }

        if (angle <= 284 && angle >= 255)
        {
            Debug.Log("S");

        }
        if (angle <= 254 && angle >= 195)
        {
            Debug.Log("SW");

        }
        if (angle <= 194 && angle >= 165)
        {
            Debug.Log("W");

        }
        if (angle <= 164 && angle >= 105)
        {
            Debug.Log("NW");

        }
        if (angle <= 104 && angle >= 74)
        {
            Debug.Log("N");

        }

    }


}



