using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : DamageSource
{
    public float amountDamage = 5f;
    public string damageName = "Touch Damage";
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var hitBox = collision.GetComponent<HitBox>();
        if (hitBox != null)
        {
            // hit the player

            var damageInfo = new DamageInfo() { Source = this, delta = amountDamage };

            hitBox.DoDamage(damageInfo);
            Debug.Log(this.Description());
        }
    }
}
