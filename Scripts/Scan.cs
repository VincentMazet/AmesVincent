using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scan : MonoBehaviour {

    Button scan;
	GameObject spriteScan;
	RuntimeAnimatorController spriteController;

	void Start () {
		spriteScan = GameObject.FindGameObjectWithTag ("ScanSprite");
		scan = GameObject.FindGameObjectWithTag("Scan").GetComponent<Button>();
		spriteController = Resources.Load<RuntimeAnimatorController>("Sprites/Canvas");
		scan.onClick.AddListener(launchScan);
	}

	void launchScan(){
		spriteScan.GetComponent<Animator> ().runtimeAnimatorController = null;
		spriteScan.GetComponent<Animator> ().runtimeAnimatorController = spriteController;
	}
}
