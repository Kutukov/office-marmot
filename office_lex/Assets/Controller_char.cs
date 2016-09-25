using UnityEngine;
using System.Collections;

public class Controller_char : MonoBehaviour {
	public Trig Trig;
	public CharacterController controller;
	public Animator animator;
	public float speed = 2;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 jumpdir = Vector3.zero;
	public float pushPower = 2.0F;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Trig.sit == false) {
			float x = Input.GetAxis ("Horizontal");
			float z = Input.GetAxis ("Vertical");
			animator.SetFloat ("speed", z);
			animator.SetFloat ("rotate", x);
			if (x != 0) {
				transform.Rotate (0f, x * speed, 0f);
			}
			if (z != 0) {
				//animator.SetBool ("run", true);
				Vector3 dir = transform.TransformDirection (new Vector3 (0f, 0f, z * speed * Time.deltaTime));
				controller.Move (dir);
			} 
			/*if (controller.isGrounded) {
				if (Input.GetButton ("Jump")) {
					jumpdir.y = jumpSpeed;
				}
			}
			jumpdir.y -= gravity * Time.deltaTime;
			controller.Move (jumpdir * Time.deltaTime);*/

			//else {
			//animator.SetBool ("run", false);

			controller.Move (Physics.gravity * Time.deltaTime);
		}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit ();
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;

		if (hit.moveDirection.y < -0.3F)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}
}

