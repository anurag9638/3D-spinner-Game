using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos= new Vector3(player.transform.position.x - 1.33f, player.transform.position.y + 2.61f, player.transform.position.z - 2.74f);
		transform.position = pos;
	}
}
