using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modifyIngot : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    bool isHot = false;
    float numberOfHits = 0;
    public GameObject weapon;
    public GameObject fxPrefab;
    GameObject ingot;
    GameObject anvil;

    private float heatInterval = 1f; // Time between each stage
    private float coolInterval = 150f; // Time between each stage
    private int currentMaterialIndex = 0;
    private bool isHeating = false;
    private Coroutine heatingCoroutine;
    private Coroutine coolingCoroutine;

    bool readyToHammer = false;

    void Start()
    {
        ingot = gameObject;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("HotArea") && !isHeating)
        {
            isHeating = true;

            if (coolingCoroutine != null)
            {
                StopCoroutine(coolingCoroutine);
                coolingCoroutine = null;
            }

            if (heatingCoroutine == null)
            {
                heatingCoroutine = StartCoroutine(HeatingUp());
            }
        }
        if (isHot && collider.CompareTag("AnvilArea"))
        {
            anvil = collider.gameObject;
            readyToHammer = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (readyToHammer && isHot && collider.CompareTag("Hammer"))
        {
            Hammer hammer = collider.GetComponent<Hammer>();
            if (hammer != null)
            {
                Debug.Log("Found Hammer! Level: " + hammer.level);
                hammeringIngot(hammer.level, hammer.IsMaxHit());
                hammer.ResetCurrentHitTime();
            }
            else
            {
                Debug.Log("No Hammer script found on: " + collider.name);
            }
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("HotArea"))
        {
            isHeating = false;

            if (heatingCoroutine != null)
            {
                StopCoroutine(heatingCoroutine);
                heatingCoroutine = null;
            }

            if (coolingCoroutine == null)
            {
                coolingCoroutine = StartCoroutine(CoolingDown());
            }
        }
        if (collider.gameObject.tag == "AnvilArea")
        {
            readyToHammer = false;
            anvil = null;
        }
    }

    IEnumerator CoolingDown()
    {

        while (currentMaterialIndex > 0)
        {

            yield return new WaitForSeconds(coolInterval);

            currentMaterialIndex--;
            rend.material = material[currentMaterialIndex];

        }

        isHot = false;
    }

    IEnumerator HeatingUp()
    {
        while (currentMaterialIndex < material.Length - 1)
        {

            yield return new WaitForSeconds(heatInterval);
            isHot = true; // Fully heated
            currentMaterialIndex++;
            rend.material = material[currentMaterialIndex];
        }

    }

    void hammeringIngot(int level, bool isMaxHit)
    {
        float mulitplyer = level;
        if (isMaxHit)
        {
            mulitplyer *= .5f;
        }

        ingot.transform.localScale += new Vector3(0, 0, .2f * mulitplyer);
        numberOfHits += mulitplyer;
        Instantiate(fxPrefab, ingot.transform.position, Quaternion.identity);

        if (numberOfHits >= 10)
        {
            Vector3 p = new Vector3(anvil.transform.position.x, anvil.transform.position.y + (float).2, anvil.transform.position.z);
            Quaternion r = new Quaternion(anvil.transform.rotation.x, anvil.transform.rotation.y, anvil.transform.rotation.z, anvil.transform.rotation.w);
            r *= Quaternion.Euler(90, 0, 0);
            Destroy(ingot);
            Instantiate(weapon, p, r);
        }

    }
}
