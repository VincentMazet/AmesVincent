using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class HUDEvent : MonoBehaviour {

	private readXml _readXml;
	private int _eventPointer;
	private AudioSource source;
	public Sprite start;
	public int eventPointer{
		get{ 
			return this._eventPointer;
			}
		set{ 
			this._eventPointer = value;
			interpreter();
			}
	}

	// Use this for initialization
	void Start () {
		this._readXml = (readXml) this.gameObject.GetComponent (typeof(readXml));
		_readXml.initiate ();
		this.source = GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource> ();
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
				var prefab = Resources.Load ("Prefabs/ButtonPrefab") as GameObject;
				if(prefab != null) {
					var button = prefab.GetComponent<Button> ();
					var imagePath = "HUD/Button/" + Path.GetFileNameWithoutExtension (_readXml.getImageFileNameForButtonOfDict (this.eventPointer, i));
					//button.image = Resources.Load (imagePath) as Image;
					//button.name = _readXml.getNameOfDict (this.eventPointer);
					var xPosObject = (int)(Screen.width * _readXml.getXPositionForButtonOfDict (this.eventPointer, i));
					var yPosObject = (int)(Screen.height * _readXml.getYPositionForButtonOfDict (this.eventPointer, i));
					vect = new Vector2 (xPosObject,yPosObject);
					var script = (ButtonManager) prefab.GetComponent (typeof(ButtonManager));
					script.buttonNumber = i;
					//addGameObjectToCanvas (button.gameObject, vect);
					//EventManager.StartListening (button.name, buttonHasFinishedIsTask);
					var instance = Instantiate (button, transform.position, transform.rotation) as Button;
					instance.transform.localPosition = vect;
					instance.onClick.AddListener (buttonHasFinishedIsTask);
					instance.name =_readXml.getNameOfDict (this.eventPointer);
					instance.image.sprite = this.start//Resources.Load (imagePath) as Sprite;
					instance.transform.SetParent(this.gameObject.transform);
					//button.onClick.AddListener (buttonHasFinishedIsTask);
				}
			}
			return;
		case "son":
			AudioClip sound = Resources.Load<AudioClip> ("Sounds/"+Path.GetFileNameWithoutExtension(_readXml.getSoundFileSoundOfDict(this.eventPointer)));

			source.PlayOneShot (sound);
			return;
		default:
			break;
		}
	}

	void addGameObjectToCanvas (GameObject objectToAdd, Vector2 position) {
		GameObject instance = Instantiate (objectToAdd, transform.position, transform.rotation) as GameObject;
		instance.name =_readXml.getNameOfDict (this.eventPointer);
		instance.transform.SetParent(this.gameObject.transform);
	}

	void buttonHasFinishedIsTask() {
		print ("hseiksefik");
		var button = GameObject.Find (_readXml.getNameOfDict (this.eventPointer)).GetComponent<Button> ();
		var script = (ButtonManager) button.GetComponent (typeof(ButtonManager));
		var buttonNumber = script.buttonNumber;
		var nextEvent = _readXml.getNextEventIndexForButtonOfDict(this.eventPointer, buttonNumber);
		if (nextEvent != 0) {
			this.eventPointer = nextEvent; 
		} else {
			eventPointer++;
		}
		//EventManager.StopListening (button.name, buttonHasFinishedIsTask);
		Destroy(button.gameObject);
	}
		
}
