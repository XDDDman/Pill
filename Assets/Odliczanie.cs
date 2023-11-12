using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Odliczanie : MonoBehaviour
{
    PointsManager pointsManager;
    bool isCountingDown = false;
    float countdownTimer = 30f;

    public TextMeshProUGUI countdownText; // Dodaj to pole, aby przypisaæ tekst TMP w Unity Inspector

    // Start is called before the first frame update
    void Start()
    {
        pointsManager = GetComponent<PointsManager>();
        countdownText.text = ""; // Pocz¹tkowo tekst bêdzie pusty
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0)
            {
                KoniecGry();
            }

            // Aktualizuj tekst TMP z odliczaniem
            UpdateCountdownText();
        }
        else if (pointsManager.points < 0)
        {
            StartCountdown();
        }
        if (pointsManager.points >= 0 && countdownTimer < 30f)
        {
            StopCountdown();
        }

        if (countdownTimer == 30)
        {

        }
    }

    void StartCountdown()
    {
        isCountingDown = true;
        Debug.Log("Rozpoczêto odliczanie!");
    }

    void StopCountdown()
    {
        isCountingDown = false;
        countdownTimer = 30f;
        Debug.Log("Zatrzymano odliczanie!");
        UpdateCountdownText(); // Aktualizuj tekst, aby by³ widoczny
    }

    void KoniecGry()
    {
        // Tutaj mo¿esz umieœciæ kod, który ma byæ wywo³any po zakoñczeniu odliczania.
        // Na przyk³ad mo¿esz dodaæ kod zakoñczenia gry, ponownego za³adowania sceny itp.
        Debug.Log("Koniec gry!");
        UpdateCountdownText(); // Aktualizuj tekst, aby by³ widoczny na zakoñczenie gry
    }

    void UpdateCountdownText()
    {
        // Aktualizuj tekst TMP z pozosta³ym czasem
        countdownText.text = $"Czas: {Mathf.Ceil(countdownTimer)}s";
    }
}