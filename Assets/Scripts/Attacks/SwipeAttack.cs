using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAttack : MonoBehaviour
{
    private HitBox hitBox;
    private SwipeAttack swipeAttack;
    private void Start()
    {
        hitBox = GetComponent<HitBox>();
    }

}
