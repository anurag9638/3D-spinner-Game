using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
	public float speed;
	public float jumpHeight;
	public bool isGrounded;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		/*Vector3 old_pos = transform.position;*/
		if (Input.GetKey(KeyCode.UpArrow))
		{
			/*Vector3 newpos = new Vector3(old_pos.x, old_pos.y, old_pos.z + speed * Time.deltaTime);
			transform.position = newpos;*/
			GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);

		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			/*Vector3 newpos = new Vector3(old_pos.x, old_pos.y, old_pos.z - speed * Time.deltaTime);
			transform.position = newpos;*/
			GetComponent<Rigidbody>().AddForce(Vector3.back * speed);

		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			/*Vector3 newpos = new Vector3(old_pos.x - speed * Time.deltaTime, old_pos.y, old_pos.z );
			transform.position = newpos;*/
			GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			/*Vector3 newpos = new Vector3(old_pos.x + speed * Time.deltaTime, old_pos.y, old_pos.z + speed * Time.deltaTime);
			transform.position = newpos;*/
			GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
		}
		if (Input.GetKey(KeyCode.Keypad0) && isGrounded == true)
		{
			/*Vector3 newpos = new Vector3(old_pos.x, old_pos.y + jumpHeight * Time.deltaTime, old_pos.z + speed * Time.deltaTime);
			transform.position = newpos;*/
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
			isGrounded = false;
		}
		
	}
	void OnCollisionEnter(Collision colli)
	{
		if (colli.gameObject.tag == "ground")
		{
			isGrounded = true;
		}
	}
}
