using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//Przechowuj publiczne odniesienie do obiektu gry gracza, aby�my mogli odnie�� si� do jego transformacji
	public GameObject player;

	//Przechowaj Vector3 przesuni�cie od gracza (odleg�o�� do kamery od gracza przez ca�y czas)
	private Vector3 offset;

		void Start ()
	{
		//Utw�rz przesuni�cie przez odj�cie pozycji kamery od pozycji gracza
		offset = transform.position - player.transform.position;
	}

	// Po wykonaniu standardowej p�tli "Update ()" i tu� przed renderowaniem ka�dej klatki..
	void LateUpdate ()
	{
		// Ustaw po�o�enie aparatu (obiekt gry ten skrypt jest do��czony)
	transform.position = player.transform.position + offset;
	}
}