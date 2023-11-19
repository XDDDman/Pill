using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public TruckManager truckManager;
    public PointsManager pointsManager;

    public List<GameObject> DestroyedPacks = new List<GameObject>();
    //public float triggerPercentage = 20f;

    //private bool hasDestroyedPacks = false;

    public void Start()
    {
        // Pobierz czas do koñca obecnej przerwy z TruckManager
        //float remainingBreakTime = truckManager.currentDelay;

        // Oblicz czas do dezaktywacji windy na podstawie procentu
        //float deactivateTime = remainingBreakTime - (float)(remainingBreakTime / 5);

        // Uruchom funkcjê dezaktywacji windy z opóŸnieniem
        //Invoke("DeactivateElevator", deactivateTime);
    }

    private void OnEnable()
    {
        // Pobierz czas do koñca obecnej przerwy z TruckManager
        float remainingBreakTime = truckManager.currentDelay;

        // Oblicz czas do dezaktywacji windy na podstawie procentu
        float deactivateTime = remainingBreakTime - (float)(remainingBreakTime / 5);

        // Uruchom funkcjê dezaktywacji windy z opóŸnieniem
        Invoke("DeactivateElevator", deactivateTime);
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("pack") && !hasDestroyedPacks)
        //   {
        //Destroy(other.gameObject); // Usuñ paczkê, jeœli jeszcze nie zniszczono
        //    }
    }

    private void DeactivateElevator()
    {
        //    if (!hasDestroyedPacks)
        //      {

        //     }
        DestroyPacks(); // Usuñ paczki, jeœli jeszcze nie zniszczono
        gameObject.SetActive(false); // Dezaktywuj windê

        // Dodaj kod tutaj, jeœli istnieje potrzeba wykonania dodatkowych dzia³añ przed dezaktywacj¹ windy
    }

    void DestroyPacks()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4.0f); // Dostosuj promieñ wed³ug potrzeb
        pointsManager.Pacs = DestroyedPacks;
        //pointsManager.CountPoints();

        foreach (Collider collider in colliders)
        {
            // Sprawdzamy, czy obiekt ma odpowiedni tag i nie jest dzieckiem ¿adnego obiektu
            if (collider.CompareTag("pack") && collider.transform.parent == null)
            {
                // Dodajemy obiekt do listy zamiast go niszczyæ
                DestroyedPacks.Add(collider.gameObject);

                // Mo¿esz opcjonalnie wywo³aæ Destroy, jeœli chcesz go równie¿ usun¹æ z gry
                //Destroy(collider.gameObject);
            }
        }
        pointsManager.Count();
    }
}