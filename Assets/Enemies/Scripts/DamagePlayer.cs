using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float maxHealth = 200; //Sets the players health
    public float DamageTaken = 10; //Sets the damage the enemy will do to the player
    public float currentHealth;

    public Camerashake shake;

    private void Start()
    {
         currentHealth = maxHealth;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= DamageTaken;
            StartCoroutine(shake.Shake(.15f, .4f));
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}