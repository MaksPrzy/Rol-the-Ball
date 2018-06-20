using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//Przechowuj publiczne odniesienie do obiektu gry gracza, abyœmy mogli odnieœæ siê do jego transformacji
	public GameObject player;

	//Przechowaj Vector3 przesuniêcie od gracza (odleg³oœæ do kamery od gracza przez ca³y czas)
	private Vector3 offset;

		void Start ()
	{
		//Utwórz przesuniêcie przez odjêcie pozycji kamery od pozycji gracza
		offset = transform.position - player.transform.position;
	}

	// Po wykonaniu standardowej pêtli "Update ()" i tu¿ przed renderowaniem ka¿dej klatki..
	void LateUpdate ()
	{
		// Ustaw po³o¿enie aparatu (obiekt gry ten skrypt jest do³¹czony)
	transform.position = player.transform.position + offset;
	}
}