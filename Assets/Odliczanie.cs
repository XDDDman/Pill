using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Odliczanie : MonoBehaviour
{
    public PointsManager pointsManager;
    public TextMeshProUGUI countdownText;

    private float countdownTimer = 30f;
    private bool countdownActivated = false;
    private bool isCountingDown = true; // Nowa zmienna, aby �ledzi� kierunek odliczania

    [SerializeField] private bool isFull;

    private void Start()
    {
        countdownText.gameObject.SetActive(false);
        isFull = false;
    }

    void Update()
    {
        if (countdownTimer <= 1)
        {
            SceneManager.LoadScene("YOU LOST");
            Debug.Log("Dead");
        }

        // Sprawdzamy, czy przynajmniej jeden z warunk�w jest spe�niony, aby aktywowa� odliczanie
        if ((pointsManager.points < 0 || isFull) && !countdownActivated)
        {
            // Aktywujemy odliczanie
            countdownActivated = true;

            // Ustawiamy aktywno�� tekstu UI na true
            countdownText.gameObject.SetActive(true);

            // Ustawiamy kierunek odliczania
            isCountingDown = true;
        }

        // Sprawdzamy, czy oba warunki przestaj� by� spe�nione, aby zatrzyma� odliczanie
        if (countdownActivated && pointsManager.points >= 0 && !isFull)
        {
            // Zatrzymujemy odliczanie
            countdownActivated = false;

            // Wy��czamy tekst UI
            countdownText.gameObject.SetActive(false);

            // Resetujemy odliczanie
            countdownTimer = 30f;
        }

        // Sprawdzamy, czy odliczanie zosta�o aktywowane
        if (countdownActivated)
        {
            // Rozpoczynamy odliczanie w odpowiednim kierunku
            if (isCountingDown)
            {
                countdownTimer -= Time.deltaTime;
            }
            else
            {
                countdownTimer += Time.deltaTime;
            }

            // Aktualizujemy tekst w UI
            countdownText.text = Mathf.Round(countdownTimer).ToString();

            // Sprawdzamy, czy odliczanie osi�gn�o 0 lub 30 (w zale�no�ci od kierunku)
            if ((countdownTimer <= 0 && isCountingDown) || (countdownTimer >= 30 && !isCountingDown))
            {
                // Tutaj mo�esz doda� kod, kt�ry ma by� wykonany po osi�gni�ciu 0 lub 30
                // Na przyk�ad zresetowanie punkt�w, wywo�anie innej funkcji, itp.

                if (!isCountingDown)
                {
                    // Je�li osi�gn�o 0, to zmie� scen� na "YOU LOST"
                    SceneManager.LoadScene("YOU LOST");
                    Debug.Log("OnApplicationLostFocus");
                }

                // Zmieniamy kierunek odliczania
                isCountingDown = !isCountingDown;

                // Resetujemy odliczanie
                countdownTimer = isCountingDown ? 30f : 0f;

                // Je�li osi�gn�o 0, to dezaktywujemy odliczanie
                if (!isCountingDown)
                {
                    // Wy��czamy tekst UI
                    countdownText.gameObject.SetActive(false);

                    // Wy��czamy aktywacj� odliczania
                    countdownActivated = false;
                }
            }
        }

        Shelf[] wszystkieP�ki = GameObject.FindObjectsOfType<Shelf>();

        bool wszystkieZajete = true;

        foreach (Shelf p�lka in wszystkieP�ki)
        {
            if (!p�lka.CzyJestZajeta())
            {
                wszystkieZajete = false;
                break; // Przerwij p�tl�, je�li znaleziono chocia� jedn� niezaj�t� p�k�
            }
        }

        // Aktualizuj warto�� isFull na podstawie warunku
        isFull = wszystkieZajete;
    }
}