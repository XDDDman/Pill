using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public TruckManager truckManager;
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

        foreach (Collider collider in colliders)
        {
            // Sprawdzamy, czy obiekt ma odpowiedni tag
            if (collider.CompareTag("pack"))
            {
                // Usuwamy obiekt
                Destroy(collider.gameObject);
            }
        }
    }
}