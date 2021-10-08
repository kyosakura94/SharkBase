using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int Health = 10; //Sets the players health
    public int DamageTaken = 10; //Sets the damage the enemy will do to the player


    public GameObject dieImpact;
    //public Camerashake shake;

    void OnCollisionEnter(Collision collision)
    {
       // StartCoroutine(shake.Shake(.15f, .4f));
        if (collision.gameObject.tag == "Defence")
        {
            Health -= DamageTaken;

        }
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        GameObject effectIns = (GameObject)Instantiate(dieImpact, transform.position + Vector3.up, transform.rotation);
        Destroy(effectIns, 2f);
        
        Destroy(gameObject);
    }
}

