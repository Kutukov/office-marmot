using UnityEngine;
using System.Collections;
using System;

public class scriptl : MonoBehaviour {
	public Trig Trig;
	public Massa Massa;
	bool iptm = false;
	public float ero1 = 1000;
	bool uls = false;
	float speed = 1;
	string str = "qwerty";
	float l1,l2;
	char c1,c2;
	float cero,cerok = 0;
	int i,i1 = 0;
	System.Random r = new System.Random();
	// Use this for initialization
	void Start () {
		//Rigidbody rb = gameObject.AddComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape"))
			Application.Quit();
		
		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			uls = false;
			ero1 = 1000;
			speed = 1;
			//Destroy (gameObject);
		}
		c1 = prim1 [i]; // номер символа в стринге
		if (Input.inputString == c1.ToString ()) {
			stringToEdit = stringToEdit + c1.ToString ();
			i = i + 1; // для прочтения след. символа
		}
		/*	l1 = stringToEdit.Length;
		if ((l1 != l2) & (l1 <= prim1.Length)) {
			cero = 0;
			for (int i = 0; i < l1; i++) {
				
				c1 = prim1 [i];
				c2 = stringToEdit [i];
				if (c1 != c2)
					cero = cero + 1;
			}
			l2 = l1;
		}
		cerok = cero; */
		ero1 = ero1 - speed;
		//System.Threading.Thread.Sleep(500);
		if (ero1 <= 0) uls = true;
	}

	public string stringToEdit = "";
	public string prim1 = "hello";

	void OnGUI()
	{
		if (Trig.sit == true) {
			if (uls == false) {
				char c = str [1];
				GUI.contentColor = Color.black;
				//GUI.Label (new Rect(200, 500,100,100), Massa.i1.ToString());
				GUI.Label (new Rect (595, 35, 100, 30), "Time");
				GUI.Label (new Rect (600, 50, 100, 30), ero1.ToString ());
				GUI.Label (new Rect (300, 75, 100, 30), prim1);
				GUI.contentColor = Color.white;
				GUI.TextField (new Rect (300, 100, 200, 20), stringToEdit, 25);
				if (stringToEdit == prim1) {
					i1 = r.Next (0, 9);
					prim1 = Massa.word [i1];
					GUI.Label (new Rect (500, 50, 100, 30), "O, VERNO CHERTILLA VVEL");
					ero1 = 1000;
					stringToEdit = "";
					i = 0;
					//prim1 = r.Next (1, 1000);
					//speed = speed * 2;
				}
				/* if (iptm == true) {
				GUI.Label (new Rect (300, 50, 100, 30), "HEEEL YEEE");
				stringToEdit = "yes";
			} */
			} else {
				GUI.contentColor = Color.red;
				GUI.Label (new Rect (500, 500, 500, 500), "YOU FIRED");
			}
		}
	}
}