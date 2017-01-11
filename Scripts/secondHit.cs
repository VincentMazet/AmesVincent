using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class secondHit : MonoBehaviour {
	
	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Ennemy"))
		{
			GameObject.FindGameObjectWithTag ("Detect2").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerExit(){
		GameObject.FindGameObjectWithTag ("Detect2").GetComponent<SpriteRenderer> ().enabled = false;
	}
}
