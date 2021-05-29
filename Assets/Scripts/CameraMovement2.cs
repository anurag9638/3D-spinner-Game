using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
	public GameObject player;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = new Vector3(player.transform.position.x - 4.33f, player.transform.position.y + 8.81f, player.transform.position.z - 7.0f);
		transform.position = pos;
	}
}
