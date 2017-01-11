using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExorcizeEnnemyScript : MonoBehaviour {
	
	Button exorcize;

	AndroidJavaClass unityClass;
	AndroidJavaObject unityActivity;
	AndroidJavaObject unityContext;
	AndroidJavaClass customClass;
	AudioSource source;

	void Start () {
		exorcize = GameObject.FindGameObjectWithTag("Exorcize").GetComponent<Button>();
		exorcize.onClick.AddListener(killEnnemy);
		sendActivityReference("fr.vincentmazet.utilslibrary.FlashLight");

		source = GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource> ();

	}

	void killEnnemy(){
		BackCamScript.StopCam ();
		enableFlash ();
		if (GameObject.FindGameObjectWithTag ("Detect4").GetComponent<SpriteRenderer> ().enabled) {

			AudioClip sound = Resources.Load<AudioClip> ("Sounds/Ames_flash_reussi");
			source.PlayOneShot (sound);

			GameObject ennemy = GameObject.FindGameObjectWithTag ("Ennemy");
			Destroy (ennemy);
		} else {
			
			AudioClip sound = Resources.Load<AudioClip>("Sounds/Ames_flash_manque");
			source.PlayOneShot (sound);
		}
		BackCamScript.StartCam ();
		GameObject.FindGameObjectWithTag ("Detect4").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Detect3").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Detect2").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Detect1").GetComponent<SpriteRenderer> ().enabled = false;

	}

	void sendActivityReference(string packageName)
	{
		unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
		unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
		customClass = new AndroidJavaClass(packageName);
		customClass.CallStatic("receiveContextInstance", unityContext);
	}

	bool enableFlash()
	{
		return customClass.CallStatic<bool>("enableFlash");
	}

	bool stopFlash()
	{
		return customClass.CallStatic<bool> ("stopFlash");
	}
}
