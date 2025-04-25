using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Castor : MonoBehaviour
{
    GameObject castor;
    public Material[] material;
    Renderer rend;

    private float heatInterval = 1f; // Time between each stage
    private float coolInterval = 150f; // Time between each stage
    private int currentMaterialIndex = 0;
    private bool isHeating = false;
    private Coroutine heatingCoroutine;
    private Coroutine coolingCoroutine;

    public GameObject ingotPrefab;
    public GameObject emptyCastorPrefab;


    bool hasFullyHeated = false;

    bool isHot = false;
    bool isCooled = false;

    void Start()
    {
        castor = gameObject;
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
    }

    IEnumerator CoolingDown()
    {

        while (currentMaterialIndex > 0)
        {

            yield return new WaitForSeconds(coolInterval);

            currentMaterialIndex--;
            rend.material = material[currentMaterialIndex];
            if (currentMaterialIndex == 0 && hasFullyHeated == true)
            {
                castorPopIngot();
            }
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
            if (currentMaterialIndex == material.Length - 1)
            {
                hasFullyHeated = true;
            }
        }

    }


    void castorPopIngot()
    {

        Vector3 p = new Vector3(castor.transform.position.x, castor.transform.position.y + (float).2, castor.transform.position.z);
        Quaternion r = new Quaternion(castor.transform.rotation.x, castor.transform.rotation.y, castor.transform.rotation.z, castor.transform.rotation.w);
        r *= Quaternion.Euler(90, 0, 0);
        Destroy(castor);
        Instantiate(castor, p, r);
        Instantiate(ingotPrefab, p, r);


    }

}
