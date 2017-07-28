using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player; 
	Vector3 Offset;
	void Start()
	{
		Offset = player.position - transform.position;

	}
	void LateUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, player.position - Offset, Time.deltaTime);
	}

}