using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstHit : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Ennemy"))
		{
			GameObject.FindGameObjectWithTag ("Detect1").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerExit(){
		GameObject.FindGameObjectWithTag ("Detect1").GetComponent<SpriteRenderer> ().enabled = false;
	}
}