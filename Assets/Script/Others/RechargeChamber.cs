using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RechargeChamber : MonoBehaviour
{
    private CustomInput input = null;
    SpriteRenderer spriteRenderer;
    Player player;

    public GameObject instructionPopUp;

    [Header("Range Settings")]
    [SerializeField] float radius;
    public LayerMask playerLayer;

    [Space(10)]

    [Header("Recharge Settings")]
    [SerializeField] Sprite emptyChamberSprite;
    [SerializeField] Sprite rechargeSprite;
    [SerializeField] float rechargeTime;

    bool isRecharging;

    [Space(10)]

    [Header("UI")]

    [SerializeField] Slider progressBar;
    [SerializeField] Canvas sliderCanvas;

    float timer;
    private void Awake()
    {
        input = new CustomInput();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sliderCanvas.gameObject.SetActive(false);
    }
    void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (collider != null)
        {
            player = collider.GetComponent<Player>();

            //TODO:
            instructionPopUp.SetActive(true);
            if (input.Player.Use.WasPerformedThisFrame())
            {
                // Debug.Log("Recharge");
                spriteRenderer.sprite = rechargeSprite; //Change Recharge Chamber sprite.
                player.EnableInput(false); //Disable Player Input
                player.GetComponent<SpriteRenderer>().enabled = false;// Turn Off Player Sprite 
                sliderCanvas.gameObject.SetActive(true);//UnHide Progress Bar.
                isRecharging = true;
                StartCoroutine(RechargeTimer()); // Start Recharge Coroutine.
            }
        }
        else
        {
            instructionPopUp.SetActive(false);
        }

        if (isRecharging)
        {
            UpdateProgressBar(); //Update Progess Bar UI.
        }
    }

    IEnumerator RechargeTimer()
    {
        yield return new WaitForSeconds(rechargeTime);
        player.RechargePlayer(); // RechargePlayer  func in Player Script. 
        spriteRenderer.sprite = emptyChamberSprite; //Change Recharge Chamber sprite.
        player.EnableInput(true); // Enable Player Input.
        player.GetComponent<SpriteRenderer>().enabled = true; // Turn On Player Sprite 
        isRecharging = false;
        sliderCanvas.gameObject.SetActive(false); //Hide Progress Bar.
        timer = 0; //Reset Timer

    }
    void UpdateProgressBar()
    {
        timer += Time.deltaTime;
        float fillAmount = timer / rechargeTime;
        progressBar.value = fillAmount;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
