using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed  ;
	public float jumpHeight;
	public bool isGrounded;
	public GameObject player2;
	public float attackforce;
	private float Move_ability = 1;
	public float evadeForce;
	public bool evade_cooldown;
	public bool attack_cooldown;
	private float evade=1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Move_ability == 1)
		{
			/*Vector3 old_pos = transform.position;*/
			if (Input.GetKey(KeyCode.W))
			{

				/*Vector3 newpos = new Vector3(old_pos.x, old_pos.y, old_pos.z + speed * Time.deltaTime);
				transform.position = newpos;*/
				GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);

			}
			if (Input.GetKey(KeyCode.S))
			{
				/*Vector3 newpos = new Vector3(old_pos.x, old_pos.y, old_pos.z - speed * Time.deltaTime);
				transform.position = newpos;*/
				GetComponent<Rigidbody>().AddForce(Vector3.back * speed);

			}
			if (Input.GetKey(KeyCode.A))
			{
				/*Vector3 newpos = new Vector3(old_pos.x - speed * Time.deltaTime, old_pos.y, old_pos.z );
				transform.position = newpos;*/
				GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
			}
			if (Input.GetKey(KeyCode.D))
			{
				/*Vector3 newpos = new Vector3(old_pos.x + speed * Time.deltaTime, old_pos.y, old_pos.z + speed * Time.deltaTime);
				transform.position = newpos;*/
				GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
			}
			if (Input.GetKey(KeyCode.Space) && isGrounded == true)
			{
				/*Vector3 newpos = new Vector3(old_pos.x, old_pos.y + jumpHeight * Time.deltaTime, old_pos.z + speed * Time.deltaTime);
				transform.position = newpos;*/
				GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
				isGrounded = false;
			}
			if (attack_cooldown == false)
			{
				if (transform.position.y < 30.0f)
				{
					if (Input.GetKey(KeyCode.E))
					{
						Vector3 attackdir = player2.transform.position - transform.position;
						//attackdir = -attackdir;
						GetComponent<Rigidbody>().AddForce(attackdir * attackforce);
						attack_cooldown = true;
						StartCoroutine(CoolDown());



					}
				}
			}
			if (evade_cooldown == false)
			{
				if (transform.position.y < 20.0f)
				{
					if (Input.GetKey(KeyCode.Q))
					{
						Vector3 evade_dir = player2.transform.position - transform.position;
						evade_dir = -evade_dir;
						GetComponent<Rigidbody>().AddForce(evade_dir * evadeForce);
						evade_cooldown = true;
						StartCoroutine(CoolDown());


					}
				}
			}
		}

	}
	void OnCollisionEnter(Collision colli)
    {
		if(colli.gameObject.tag == "ground")
        {
			isGrounded = true;
        }
    }
	IEnumerator CoolDown()
    {
		
		yield return new WaitForSeconds(2);
		evade_cooldown = false;
		attack_cooldown = false;
		
		
		yield return 0;
    }
}
