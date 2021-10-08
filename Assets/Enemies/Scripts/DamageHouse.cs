using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHouse : MonoBehaviour
{
    public float Health = 10; //Sets the houses health
    public float DamageTaken = 10; //Sets the damage the enemy will do to the house

    public GameObject dieImpact;
    public GameObject restart;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health -= DamageTaken;
        }
        if (Health <= 0)
        {
            Die();
        }
    }
   public void Die()
    {        
        GameObject effectIns = (GameObject)Instantiate(dieImpact, transform.position + Vector3.up, transform.rotation);
        Destroy(effectIns, 2f);

        FindObjectOfType<AudioManager>().Stop("Theme");
        Debug.Log("TEST");
        restart.SetActive(true);
        Destroy(gameObject);
    }

}
