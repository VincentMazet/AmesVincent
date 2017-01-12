using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerClickHandler {

	public int buttonNumber;
	public Texture bImage;

	void Start () {
		
	}


	public void OnPointerClick(PointerEventData eventData)
	{
		//EventManager.TriggerEvent (this.gameObject.name);
		Debug.Log("Hello");
	}
}
