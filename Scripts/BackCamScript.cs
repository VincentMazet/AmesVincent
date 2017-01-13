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
	
	public bool isBrigthnessLow()
	{
		var Brigthnesslow = false;
		var screenWidth = Screen.width;
		var screenHeigth = Screen.height;
		var pixel1 = this.cameraBack.GetPixel ((int)System.Math.Ceiling(screenWidth*0.25),(int)System.Math.Ceiling(screenHeigth*0.25));
		var pixel2 = this.cameraBack.GetPixel ((int)System.Math.Ceiling(screenWidth*0.75),(int)System.Math.Ceiling(screenHeigth*0.75));
		var brigthness1 = (0.2126 * pixel1.r + 0.7152 * pixel1.g + 0.0722 * pixel1.b);
		var brigthness2 = (0.2126 * pixel2.r + 0.7152 * pixel2.g + 0.0722 * pixel2.b);
		if (brigthness1 < (0.2) && brigthness2 < (0.2)) {
			Brigthnesslow = true;
		}
		return Brigthnesslow;
	}
		
}
