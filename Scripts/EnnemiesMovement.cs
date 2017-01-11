using UnityEngine;
using System.Collections;

public class EnnemiesMovement : MonoBehaviour {
	public int speed = 5;

	public Vector3 direction = Vector3.right;
	private float initialX;
	private float initialY;
	private float initialZ;
	Transform ennemy;


	void Start(){
		ennemy = GameObject.FindGameObjectWithTag("Ennemy").GetComponent<Transform> ();
		initialX  = ennemy.position.x;
		initialY  = ennemy.position.y;
		initialZ  = ennemy.position.z;
	}

	void FixedUpdate () {
		ennemy.Translate ( direction * speed *  Time.deltaTime);
		float x = ennemy.position.x;
		float y = ennemy.position.y;
		float z = ennemy.position.z;

		if((x >= 90 || x <= -90) || (y >= 90 || y <= -90) || (z >= 90 || z <= -90)){
			ennemy.position = new Vector3 (initialX,initialY,initialZ);
		}
	}
}
