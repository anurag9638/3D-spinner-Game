using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision2 : MonoBehaviour {
	public float Away_force;
	public ParticleSystem spark;
	public float forceMag;

	// Use this for initialization
	void Start () {
		spark.Stop();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision colli)
	{
		if (colli.gameObject.tag == "player1")
		{
			Vector3 force_direction = colli.contacts[0].point - transform.position;
			force_direction = -force_direction;
			forceMag = force_direction.sqrMagnitude;
			GetComponent<Rigidbody>().AddForce(force_direction * Away_force);
			spark.Play();

		}
	}
}
