using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modifyIngot : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    bool isHot = false;
    int numberOfHits = 0;
    public GameObject sword;
    GameObject ingot;
    GameObject anvil;
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
        if (collider.gameObject.tag == "HotArea")
        {
            StartCoroutine(HeatingUp());
        }
        if (isHot && collider.gameObject.tag == "AnvilArea")
        {
            anvil = collider.gameObject;
            readyToHammer = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (readyToHammer && isHot && collider.gameObject.tag == "Hammer")
        {
            hammeringIngot();
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if(isHot && collider.gameObject.tag == "HotArea")
        {
            StartCoroutine(CoolingDown());
        }
        if (collider.gameObject.tag == "AnvilArea")
        {
            readyToHammer = false;
            anvil = null;
        }
    }

    IEnumerator CoolingDown()
    {
        yield return new WaitForSeconds(15);
        rend.sharedMaterial = material[0];
        isHot = false;
    }

    IEnumerator HeatingUp()
    {
        yield return new WaitForSeconds(5);
        rend.sharedMaterial = material[1];
        isHot = true;
    }

    void hammeringIngot()
    {
        numberOfHits += 1;
        if(numberOfHits >= 5)
        {
            Vector3 p = new Vector3(anvil.transform.position.x, anvil.transform.position.y + (float).2, anvil.transform.position.z);
            Quaternion r = new Quaternion(anvil.transform.rotation.x , anvil.transform.rotation.y , anvil.transform.rotation.z, anvil.transform.rotation.w);
            r *= Quaternion.Euler(90, 0, 0); 
            Destroy(ingot);
            Instantiate(sword, p, r);
        }
    }
}
