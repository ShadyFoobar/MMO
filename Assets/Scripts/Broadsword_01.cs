using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadsword_01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            //TODO GO OVER TUTORIAL FOR SETTING UP BASE STATS AND STUFF
            col.GetComponent<IEnemy>().TakeDamage(10);
        }
    }
}
