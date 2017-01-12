using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour, IPointerClickHandler {

	public int buttonNumber;
	public Texture bImage;

	void Start () {
		//var button = this.GetComponent<Button> ();
		var button = GameObject.FindGameObjectWithTag ("button1").GetComponents<Button>()[0];
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener (buttonHasBeenClick);
		bImage = Resources.Load("HUD/button/start") as Texture;
	}

	public void buttonHasBeenClick() {
		Debug.LogError ("hseiksefik");
		//EventManager.TriggerEvent (this.name);
	}

	void OnGUI() {
		if (GUILayout.Button(bImage))
			print("You clicked the button!");
		
	}



	public void OnPointerClick(PointerEventData eventData)
	{

		Debug.Log("Hello");
	}
}
