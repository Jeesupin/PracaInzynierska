using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public static float ClampAng(float angle, float min, float max){
		//Funkcja ma zabiezpieczyc aby po dojsciu do 360 stopni mozna bylo sie dalej obracac

		if (angle < -360) {
			angle += 360f;
		}
		if (angle > 360f) {
			angle -= 360f;
		}
		return Mathf.Clamp (angle, min, max);
	
	}
		
	// Trzy opcje, dzieki temu mozemy ustalic ktora ma jak dzialac
	public enum RotationAxes
	{
		MouseXY = 0,
		MouseX = 1,
		MouseY = 2
	}

	//Domyslna wartosc
	public RotationAxes axes = RotationAxes.MouseXY;
	//Czulosc myszy na osi X i Y
	public float sensitivityX = 10f;
	public float sensitivityY = 10f;

	public float minimumX = -360f;
	public float maximumX = 360f;
	public float minimumY = -45f;
	public float maximumY = 45f;

	float rotationX = 0f;
	float rotationY = 0f;

	Quaternion originalRotation;



	// Use this for initialization
	void Start () {
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseXY) {
			//Wczytaj input myszki
			rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationX = ClampAng(rotationX, minimumX, maximumX);
			rotationY = ClampAng(rotationY, minimumY, maximumY);

			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		} else if (axes == RotationAxes.MouseX) {
			rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
			rotationX = ClampAng(rotationX, minimumX, maximumX);
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		} else {

			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY = ClampAng(rotationY, minimumY, maximumY);

			Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}

	}


}
