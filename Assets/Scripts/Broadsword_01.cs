using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadsword_01 : MonoBehaviour
{

    private float damage = 5.0f;
    private float penetration = 0.0f;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage(damage, penetration);
        }
    }
}
