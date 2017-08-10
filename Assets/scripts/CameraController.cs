using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraController : MonoBehaviour {

	public Transform player; 
	Vector3 Offset;
	float cameraOrignalY; 
	void Start()
	{
		cameraOrignalY = transform.position.y;
		Offset = player.position - transform.position;
	}

	public void TweenCamera()
	{
		transform.DOMoveY (cameraOrignalY + 0.3f, 0.3f).OnComplete(CameraInitial);
		//Vector3 targetPos = new Vector3(transform.position.x, player.position.y - Offset.y, transform.position.z);
		//transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime*4);
	}

	void CameraInitial()
	{
		transform.DOMoveY (cameraOrignalY, 0.3f);
	}

}