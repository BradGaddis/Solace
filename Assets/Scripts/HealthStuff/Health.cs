using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    private int maxHealth = 100;
    public float currentHealth;


    // This script needs to be attached to any object that will take damage/receive health

    public void RecoverHealth()
    {

    }

    public void DropHealth(){
    }
}