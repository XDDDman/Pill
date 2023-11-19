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
    private bool isCountingDown = true; // Nowa zmienna, aby œledziæ kierunek odliczania

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

        // Sprawdzamy, czy przynajmniej jeden z warunków jest spe³niony, aby aktywowaæ odliczanie
        if ((pointsManager.points < 0 || isFull) && !countdownActivated)
        {
            // Aktywujemy odliczanie
            countdownActivated = true;

            // Ustawiamy aktywnoœæ tekstu UI na true
            countdownText.gameObject.SetActive(true);

            // Ustawiamy kierunek odliczania
            isCountingDown = true;
        }

        // Sprawdzamy, czy oba warunki przestaj¹ byæ spe³nione, aby zatrzymaæ odliczanie
        if (countdownActivated && pointsManager.points >= 0 && !isFull)
        {
            // Zatrzymujemy odliczanie
            countdownActivated = false;

            // Wy³¹czamy tekst UI
            countdownText.gameObject.SetActive(false);

            // Resetujemy odliczanie
            countdownTimer = 30f;
        }

        // Sprawdzamy, czy odliczanie zosta³o aktywowane
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

            // Sprawdzamy, czy odliczanie osi¹gnê³o 0 lub 30 (w zale¿noœci od kierunku)
            if ((countdownTimer <= 0 && isCountingDown) || (countdownTimer >= 30 && !isCountingDown))
            {
                // Tutaj mo¿esz dodaæ kod, który ma byæ wykonany po osi¹gniêciu 0 lub 30
                // Na przyk³ad zresetowanie punktów, wywo³anie innej funkcji, itp.

                if (!isCountingDown)
                {
                    // Jeœli osi¹gnê³o 0, to zmieñ scenê na "YOU LOST"
                    SceneManager.LoadScene("YOU LOST");
                    Debug.Log("OnApplicationLostFocus");
                }

                // Zmieniamy kierunek odliczania
                isCountingDown = !isCountingDown;

                // Resetujemy odliczanie
                countdownTimer = isCountingDown ? 30f : 0f;

                // Jeœli osi¹gnê³o 0, to dezaktywujemy odliczanie
                if (!isCountingDown)
                {
                    // Wy³¹czamy tekst UI
                    countdownText.gameObject.SetActive(false);

                    // Wy³¹czamy aktywacjê odliczania
                    countdownActivated = false;
                }
            }
        }

        Shelf[] wszystkiePó³ki = GameObject.FindObjectsOfType<Shelf>();

        bool wszystkieZajete = true;

        foreach (Shelf pólka in wszystkiePó³ki)
        {
            if (!pólka.CzyJestZajeta())
            {
                wszystkieZajete = false;
                break; // Przerwij pêtlê, jeœli znaleziono chocia¿ jedn¹ niezajêt¹ pó³kê
            }
        }

        // Aktualizuj wartoœæ isFull na podstawie warunku
        isFull = wszystkieZajete;
    }
}