using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision1 : MonoBehaviour {
	public float Away_force;
	public ParticleSystem spark;
	public float forceMag;
	private float slomo = 0.0f;

	// Use this for initialization

	void Start () {
		spark.Stop();
		

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    void OnCollisionEnter(Collision colli)
    {
		if(colli.gameObject.tag == "player2")
        {
			Vector3 force_direction = colli.contacts[0].point - transform.position;
			force_direction = -force_direction;
			forceMag = force_direction.sqrMagnitude;
			if(forceMag < 0.45f)
            {
				if (slomo != 2)
				{
					//StartCoroutine(slowdown());
					slomo++;
				}
            }


			GetComponent<Rigidbody>().AddForce(force_direction * Away_force);
			spark.Play();
			
		}
    }
	IEnumerator slowdown()
	{

		Time.timeScale = 0.5f;
		yield return new WaitForSeconds(0.6f);
		Time.timeScale = 1;
		yield return 0;
	}
}
