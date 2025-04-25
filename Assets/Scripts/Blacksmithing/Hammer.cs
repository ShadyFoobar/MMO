using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int level;

    private int maxHitTime = 2;
    private int currentHitTime = 2;

    IEnumerator HitTimer()
    {
        while (currentHitTime < maxHitTime)
        {
            yield return new WaitForSeconds(1);
            currentHitTime++;
        }
        Debug.Log("Animation for hammer ready");
    }

    public void ResetCurrentHitTime()
    {
        currentHitTime = 0;
        StartCoroutine(HitTimer());
    }

    public bool IsMaxHit()
    {
        return currentHitTime == maxHitTime;
    }
}
