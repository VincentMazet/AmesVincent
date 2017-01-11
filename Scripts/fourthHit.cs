using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fourthHit : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Ennemy"))
		{
			GameObject.FindGameObjectWithTag ("Detect4").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerExit(){
		GameObject.FindGameObjectWithTag ("Detect4").GetComponent<SpriteRenderer> ().enabled = false;
	}
}
