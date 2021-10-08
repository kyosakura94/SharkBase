using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {

        transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
