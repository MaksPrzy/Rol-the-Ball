using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	//Przed renderowaniem ka�dej klatki..
	void Update () 
	{
		// Obr�� obiekt gry,ten skrypt jest do��czony do 15 osi X,
		// 30 w osi Y i 45 w osi z, pomno�onej przez //deltaTime w celu uczynienia go na sekund� zamiast na ramk�.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}	