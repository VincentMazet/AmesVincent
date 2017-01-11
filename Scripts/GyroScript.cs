using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour {

	float x;
	float y;

	void Start () {
		Input.gyro.enabled = true;
	}

	void Update () {
		y = Input.gyro.rotationRateUnbiased.y;
		x = Input.gyro.rotationRateUnbiased.x;
		GetComponent<Transform>().Rotate (-x, -y, 0);
	}
}
