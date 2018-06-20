using UnityEngine;

//Obejmuj� obszar nazw wymaganych do korzystania z interfejsu u�ytkownika Unity
za pomoc� UnityEngine. UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Tworzenie zmiennych publicznych dla szybko�ci gracza i dla tekstu obiekt�w gry UI
	public float speed;
	public Text countText;
	public Text winText;

	// Utw�rz prywatne odniesienia do komponentu rigidbody na odtwarzaczu, a liczba odebranych obiekt�w podni�s� do tej pory
	private Rigidbody rb;
	private int count;

		void Start ()
	{
		//Przypisz sk�adnikowi Rigidbody do naszej prywatnej zmiennej RB
		rb = GetComponent<Rigidbody>();

		// Ustaw licznik na zero 
		count = 0;

		// Uruchom funkcj� SetCountText, aby zaktualizowa� interfejs u�ytkownika (patrz ni�ej)
		SetCountText ();

		// Ustaw tekst w�a�ciwo�ci naszego interfejsu u�ytkownika Wygraj tekst na pusty ci�g, co "you win" (gra nad wiadomo�ci�) puste
		
winText.text = "";
	}

		void FixedUpdate ()
	{
		// Ustaw niekt�re lokalne zmienne float r�wne warto�ci naszych wej�� poziomych i pionowych

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Tworzenie zmiennej Vector3 i przypisanie X i z do funkcji naszych zmiennych p�ywakowych poziomej i pionowej powy�ej
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Dodaj fizyczn� si�� do naszego gracza rigidbody za pomoc� naszego "ruchu" Vector3 powy�ej, 
		// pomno�enie przez "Speed"-Nasza publiczna pr�dko�� gracza, kt�ra pojawia si� w Inspektorze
		rb.AddForce (movement * speed);
	}

	// Gdy ten obiekt gry przecina kolizj� z "jest Trigger" zaznaczone,//zapisa� odniesienie do tego kolizji w zmiennej o nazwie "inne"..
	void OnTriggerEnter(Collider other) 
	{
		//  a je�li obiekt gry przecinamy ma tagu "odebra�" przypisane do niego..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Zrobi� inny obiekt gry (odebra�) nieaktywny, aby znikn��
			other.gameObject.SetActive (false);

			// Dodaj jeden do zmiennej wynik "Count"
			count = count + 1;

			// Uruchom funkcj� "SetCountText ()" (patrz ni�ej)
			SetCountText ();
		}
	}

	// Tworzenie samodzielnej funkcji, kt�ra mo�e aktualizowa� countText ' UI i sprawdzi�, czy wymagana kwota do wygrania zosta�a osi�gni�ta
	void SetCountText()
	{
		// Zaktualizuj pole tekstowe naszej zmiennej countText '
		countText.text = "Count: " + count.ToString ();

		//Sprawd�, czy nasze "Count" jest r�wna lub przekroczona 12
		if (count >= 12) 
		{
			// Ustaw warto�� tekstow� naszego "winText"
			winText.text = "You Win!";
		}
	}
}