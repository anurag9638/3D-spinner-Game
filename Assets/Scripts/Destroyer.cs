using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	public Animator spin;
	public float damage = 30f;
	public Movement player;
	
	
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		
		if(transform.position.y < 3.56f)
        {
			//StartCoroutine(Coroutine1());
			spin.GetComponent<Animator>().enabled = false;
			player.speed = 0;
		}
		if(damage <= 20)
        {
			spin.SetFloat("health", 20);
			player.speed = 25f;
		}
		if (damage <= 10)
		{
			spin.SetFloat("health", 10);
			player.speed = 20f;
		}
		if (damage <= 5)
		{
			spin.SetFloat("health", 5);
			player.speed = 15f;
		}
		if (damage == 0)
		{
			spin.GetComponent<Animator>().enabled = false;
			player.speed = 0f;			
		}



	}
	void OnCollisionEnter(Collision colli)
    {
		if(colli.gameObject.tag =="Destroyer")
        {
			Debug.Log("done");
			//StartCoroutine(Coroutine1());
			spin.GetComponent<Animator>().enabled = false;
			player.speed = 0f;


		}
		if(colli.gameObject.tag == "player2")
        {
			if (damage == 1)
			{
				StartCoroutine(Coroutine1());
				
			}
			else
			{
				damage--;
			}
        }

    }

	IEnumerator Coroutine1()
    {
		spin.GetComponent<Animator>().enabled = false;
		Time.timeScale = 0.3f;
		yield return new WaitForSeconds(1);
		Time.timeScale = 1;
		damage--;
		
		yield return 0;
	}
	
}
