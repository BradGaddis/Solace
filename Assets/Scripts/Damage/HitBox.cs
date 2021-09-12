using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private Health health;

    float timer;
    public float startTime;

    
    private void Start()
    {
        health = GetComponent<Health>();
        timer = startTime;
    }

    public void DoPlayerDamage(DamageInfo damageInfo)
    {
        health.DecreaseHealth(damageInfo.delta);

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Debug.Log("Happy thoughts");
        }

    }

    public void DoEnemyDamage()
    {

    }
}
