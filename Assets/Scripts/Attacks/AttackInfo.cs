using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Attack", menuName = "Damage/Attack") ]
public class AttackInfo : ScriptableObject
{
    [SerializeField] public float damageAmount;
    public float DamageAmount => damageAmount;
    [SerializeField]
    private AttackKeys attackKeysEnum;

    public int[] attackLevel;
    
    //public string[] levelDescription = new string[attackLevel.length];




    //public string attackKeys = attackKeysEnum.ToString();


}

public enum AttackKeys{ Space, C }