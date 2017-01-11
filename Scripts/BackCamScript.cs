using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BackCamScript : MonoBehaviour {

	static WebCamTexture cam;
	static RawImage screen;
	private AndroidJavaObject androidCamera;


	GameObject canvas;

	void Start () {
		screen = GameObject.FindGameObjectWithTag("Screen").GetComponent<RawImage> ();
		cam = new WebCamTexture ();
		screen.texture = cam;
		cam.Play ();
	}

	public static void StopCam(){
		cam.Stop ();
	}

	public static void StartCam(){
		screen.texture = cam;
		cam.Play ();
	}
		
}
