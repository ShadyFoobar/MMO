using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modifyIngot : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    bool isHot = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "HotArea")
        {
            StartCoroutine(HeatingUp());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(isHot)
        {
            StartCoroutine(CoolingDown());
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
}
