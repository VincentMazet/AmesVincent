using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class thirdHit : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Ennemy"))
		{
			GameObject.FindGameObjectWithTag ("Detect3").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerExit(){
		GameObject.FindGameObjectWithTag ("Detect3").GetComponent<SpriteRenderer> ().enabled = false;
	}
}
