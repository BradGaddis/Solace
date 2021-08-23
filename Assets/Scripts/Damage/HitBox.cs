using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private Health health;
    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void DoDamage(DamageInfo damageInfo)
    {
        health.DecreaseHealth(damageInfo.delta);
        Debug.Log($"Is this running? {this.name}");
    }
}
