using UnityEngine;
using System.Collections;

public class PositionTest : MonoBehaviour {

	Transform camera;
	Transform ennemy;

	public float relativeX;
	public float relativeY;
	public float relativeZ;

	void Start(){
		ennemy = GameObject.FindGameObjectWithTag("Ennemy").GetComponent<Transform> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ();
	}

	void FixedUpdate () {
		testRoL ();
	}


	public void testRoL(){
		Vector3 relativePoint = camera.InverseTransformPoint (ennemy.position);

		relativeX = relativePoint.x;
		relativeY = relativePoint.y;
		relativeZ = relativePoint.z;

		if (relativePoint.x < 0.0) {
			GameObject.FindGameObjectWithTag("DetectRight").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_right_0");		
			GameObject.FindGameObjectWithTag("DetectLeft").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_left_1");		
		} else if (relativePoint.x > 0.0) {
			GameObject.FindGameObjectWithTag("DetectLeft").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_left_0");	
			GameObject.FindGameObjectWithTag("DetectRight").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_right_1");	
		}

		if (relativePoint.y < 0.0) {
			GameObject.FindGameObjectWithTag("DetectUp").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_up_0");		
			GameObject.FindGameObjectWithTag("DetectDown").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_down_1");		
		} else if (relativePoint.y > 0.0) {
			GameObject.FindGameObjectWithTag("DetectDown").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_down_0");	
			GameObject.FindGameObjectWithTag("DetectUp").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("HUD/arrow_up_1");	
		}
	}
}
