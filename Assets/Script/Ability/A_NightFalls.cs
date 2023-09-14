using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class A_NightFalls : MonoBehaviour
{
    public Light2D envLight;
    public float lightIntensity;
    public Player player;

    public Animator animator;

    void Awake()
    {
        lightIntensity = envLight.intensity;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           // Debug.Log("Abilities 1");
            transform.position = player.transform.position;
            animator.Play("Ability1");
        
        }
        LightEffect();
    }

    void LightEffect()
    {
        envLight.intensity = lightIntensity;
    }

    public void CompleteAnimation()
    {
        animator.Play("New State");
    }

}
