﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

	UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	public GameObject character;
	public GameObject monster;
	public Camera deathCam;
	float speed = 5;
	bool active;


	void Start () {
		controller = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ();

	}

	IEnumerator HitCam(){
		yield return new WaitForSeconds (.867f);
		active = false;
		Camera.main.gameObject.SetActive (false);
		deathCam.gameObject.SetActive (true);
		yield return new WaitForSeconds (.867f);
		deathCam.gameObject.SetActive (false);
	
	}

	public void Attacked (){
		controller.enabled = false;
		active = true;
		StartCoroutine (HitCam ());
	}

	void Look(Vector3 target){
		Vector3 targetDir = target - (transform.position + new Vector3 (0, .5f));
		//targetDir.y = 0.0f;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (targetDir), Time.time * speed);
	}

	void Update(){
		if (active) {
			Look (monster.transform.position + (new Vector3(0,1.5f,0)) );
		}
	}

}
