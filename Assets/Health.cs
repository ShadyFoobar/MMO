using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;



public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100.0f;
    bool primaryIsPressed;
    bool secondaryIsPressed;

    void Update()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        if (inputDevices.Count > 1)
        {
            Debug.Log("Here are the input devices: " + inputDevices[1].name);
            inputDevices[1].TryGetFeatureValue(CommonUsages.primaryButton, out primaryIsPressed);
            Debug.Log(primaryIsPressed);
            inputDevices[1].TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryIsPressed);
            Debug.Log(secondaryIsPressed);
        }


        if (healthAmount<= 0)
        {
            Debug.Log("IM DEAD");
        }
        if(primaryIsPressed)
        {
            Debug.Log("THIS IS BUTTON TWO");

            TakeDamage(20);
        }
        if(secondaryIsPressed)
        {
            Debug.Log("THIS IS BUTTON ONE");
            Healing(20);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100;
    }
}
