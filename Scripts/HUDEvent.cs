using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUDEvent : MonoBehaviour {

	private readXml _readXml;
	private int eventPointer;

	// Use this for initialization
	void Start () {
		this._readXml = (readXml) this.gameObject.GetComponent (typeof(readXml));
		_readXml.initiate ();
		interpreter ();
	}

	void Update () {
		
	}
	//si c'est un boutton mettre un listenner sur les deux boutton, il appelle la 
	void interpreter() {
		var vect = new Vector2 ();
		switch (_readXml.getTypeOfDict (this.eventPointer)) {
		case "button":
			for (int i = 1; i < (_readXml.getNumberOfButtonsOfDict(this.eventPointer) + 1); i++) {
				var prefab = Resources.Load ("ButtonPrefab") as GameObject;
				if(prefab != null) {
					var button = prefab.GetComponent<Button> ();
					button.image = Resources.Load ("HUD/button/"+_readXml.getImageFileNameForButtonOfDict (this.eventPointer, i)) as Image;
					button.name = _readXml.getNameOfDict (this.eventPointer);
					var xPosObject = (int)(Screen.width * _readXml.getXPositionForButtonOfDict (this.eventPointer, i));
					var yPosObject = (int)(Screen.height * _readXml.getYPositionForButtonOfDict (this.eventPointer, i));
					vect = new Vector2 (xPosObject,yPosObject);
					var script = (ButtonManager) prefab.GetComponent (typeof(ButtonManager));
					script.buttonNumber = i;
					addGameObjectToCanvas (button.gameObject, vect);
					button.onClick.AddListener (buttonHasFinishedIsTask);
				}
			}
			return;
		default:
			break;
		}
	}

	void addGameObjectToCanvas (GameObject objectToAdd, Vector2 position) {
		GameObject instance = Instantiate (objectToAdd, transform.position, transform.rotation) as GameObject;
		instance.transform.parent = this.gameObject.transform;
	}

	void buttonHasFinishedIsTask() {
		Debug.LogError ("hseiksefik");
		var button = GameObject.Find (_readXml.getNameOfDict (this.eventPointer)).GetComponent<Button> ();
		var script = (ButtonManager) button.GetComponent (typeof(ButtonManager));
		var buttonNumber = script.buttonNumber;
		var nextEvent = _readXml.getNextEventIndexForButtonOfDict(this.eventPointer, buttonNumber);
		if (nextEvent != 0) {
			this.eventPointer = nextEvent; 
		} else {
			nextEvent++;
		}
		Destroy(button);
	}
		
}
