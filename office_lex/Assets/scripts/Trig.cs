using UnityEngine;
using System.Collections;

public class Trig : MonoBehaviour {
	Animator animator;
	public GameObject track;
	GameObject player;
	public Controller_char C_char;
	public bool sit = false;
	public bool ontrig;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftAlt) & (ontrig == true)) {
			if (sit == false)
				sit = true;
			else if (sit == true)
				sit = false;
			
			if (sit == true) {
				player.transform.position = track.transform.position;
				player.transform.rotation = track.transform.rotation;
				C_char.controller.enabled = false;
				C_char.animator.SetBool ("sit", true);
			} else {
				C_char.controller.enabled = true;
				C_char.animator.SetBool ("sit", false);

			}
		}
	}

	void OnTriggerEnter() {
		ontrig = true;	
	}
	void OnTriggerExit() {
		ontrig = false;
	}
}
