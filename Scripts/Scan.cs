using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scan : MonoBehaviour {

    Button scan;
	GameObject spriteScan;
	RuntimeAnimatorController spriteController;
	AudioSource source;


	void Start () {
		source = GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource> ();
		spriteScan = GameObject.FindGameObjectWithTag ("ScanSprite");
		scan = GameObject.FindGameObjectWithTag("Scan").GetComponent<Button>();
		spriteController = Resources.Load<RuntimeAnimatorController>("Sprites/Canvas");
		scan.onClick.AddListener(launchScan);
	}

	void launchScan(){
		spriteScan.GetComponent<Animator> ().runtimeAnimatorController = null;
		spriteScan.GetComponent<Animator> ().runtimeAnimatorController = spriteController;
		AudioClip sound = Resources.Load<AudioClip>("Sounds/Ames_scan_pièce");
		source.PlayOneShot (sound);
	}
}
