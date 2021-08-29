using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    //TODO
    string other = "";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        other = collision.gameObject.name;
    }

    public string Description()
    {
        return $"{this.gameObject.name} hit with {this.GetType().Name}";
    }
}
