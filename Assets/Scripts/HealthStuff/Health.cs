using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    protected float currentHealth = 100;
    

    // This script needs to be attached to any object that will take damage/receive health
    private void Update()
    {
        Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void RecoverHealth()
    {

    }

    public void DecreaseHealth(float decreaseAmount)
    {
        currentHealth -= decreaseAmount;
    }
}