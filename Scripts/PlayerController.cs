using UnityEngine;

//Obejmuj¹ obszar nazw wymaganych do korzystania z interfejsu u¿ytkownika Unity
za pomoc¹ UnityEngine. UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Tworzenie zmiennych publicznych dla szybkoœci gracza i dla tekstu obiektów gry UI
	public float speed;
	public Text countText;
	public Text winText;

	// Utwórz prywatne odniesienia do komponentu rigidbody na odtwarzaczu, a liczba odebranych obiektów podniós³ do tej pory
	private Rigidbody rb;
	private int count;

		void Start ()
	{
		//Przypisz sk³adnikowi Rigidbody do naszej prywatnej zmiennej RB
		rb = GetComponent<Rigidbody>();

		// Ustaw licznik na zero 
		count = 0;

		// Uruchom funkcjê SetCountText, aby zaktualizowaæ interfejs u¿ytkownika (patrz ni¿ej)
		SetCountText ();

		// Ustaw tekst w³aœciwoœci naszego interfejsu u¿ytkownika Wygraj tekst na pusty ci¹g, co "you win" (gra nad wiadomoœci¹) puste
		
winText.text = "";
	}

		void FixedUpdate ()
	{
		// Ustaw niektóre lokalne zmienne float równe wartoœci naszych wejœæ poziomych i pionowych

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Tworzenie zmiennej Vector3 i przypisanie X i z do funkcji naszych zmiennych p³ywakowych poziomej i pionowej powy¿ej
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Dodaj fizyczn¹ si³ê do naszego gracza rigidbody za pomoc¹ naszego "ruchu" Vector3 powy¿ej, 
		// pomno¿enie przez "Speed"-Nasza publiczna prêdkoœæ gracza, która pojawia siê w Inspektorze
		rb.AddForce (movement * speed);
	}

	// Gdy ten obiekt gry przecina kolizjê z "jest Trigger" zaznaczone,//zapisaæ odniesienie do tego kolizji w zmiennej o nazwie "inne"..
	void OnTriggerEnter(Collider other) 
	{
		//  a jeœli obiekt gry przecinamy ma tagu "odebraæ" przypisane do niego..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Zrobiæ inny obiekt gry (odebraæ) nieaktywny, aby znikn¹æ
			other.gameObject.SetActive (false);

			// Dodaj jeden do zmiennej wynik "Count"
			count = count + 1;

			// Uruchom funkcjê "SetCountText ()" (patrz ni¿ej)
			SetCountText ();
		}
	}

	// Tworzenie samodzielnej funkcji, która mo¿e aktualizowaæ countText ' UI i sprawdziæ, czy wymagana kwota do wygrania zosta³a osi¹gniêta
	void SetCountText()
	{
		// Zaktualizuj pole tekstowe naszej zmiennej countText '
		countText.text = "Count: " + count.ToString ();

		//SprawdŸ, czy nasze "Count" jest równa lub przekroczona 12
		if (count >= 12) 
		{
			// Ustaw wartoœæ tekstow¹ naszego "winText"
			winText.text = "You Win!";
		}
	}
}