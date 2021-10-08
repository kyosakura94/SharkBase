using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSheild : MonoBehaviour
{
    public float Health = 100000f; //Sets the players health
    public float DamageTaken = 10f; //Sets the damage the enemy will do to the player
    public int Score = 0;

    public Camerashake shake;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(shake.Shake(.15f, .4f));
            Health += DamageTaken;
            Score += 1;
            if (Score > 5)
            {
                Score = 0;
            }
        }

        if (Health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

}
