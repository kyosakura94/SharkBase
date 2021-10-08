using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToHouse : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target; //Allows the AI to see if the player is in its radius
    NavMeshAgent agent;

    void Start()
    {
        target = TrackHouse.instance.target.transform; //sets the target to the one selected in the track player script
        agent = GetComponent<NavMeshAgent>(); // gets the component for agent
    }


    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); //Gets the distance from the enemy to the player

        if (distance <= lookRadius) //If the distance bettwen our player and enemy is in the look radius it will start chasing 
        {
            agent.SetDestination(target.position); //Send the AI the players position
            if (distance <= agent.stoppingDistance)
            {
                FaceTaregt(); //Uses the FaceTarget method to face the player
            }
        }
    }

    void FaceTaregt()
    {
        Vector3 direction = (target.position - transform.position).normalized; //Get direction to the target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); //Point towards the player
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius); //Draws a sphere to show where the enemy can see
    }
}