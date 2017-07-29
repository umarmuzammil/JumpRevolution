using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraController : MonoBehaviour {

	public Transform player; 
	Vector3 Offset;
	void Start()
	{
		Offset = player.position - transform.position;

	}
	void Update()
	{
        Vector3 targetPos = new Vector3(transform.position.x, player.position.y - Offset.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime*4);
	}

}