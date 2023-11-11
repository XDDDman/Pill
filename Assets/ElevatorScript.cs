using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public TruckManager truckManager;
    //public float triggerPercentage = 20f;

    //private bool hasDestroyedPacks = false;

    public void Start()
    {
        // Pobierz czas do ko�ca obecnej przerwy z TruckManager
        //float remainingBreakTime = truckManager.currentDelay;

        // Oblicz czas do dezaktywacji windy na podstawie procentu
        //float deactivateTime = remainingBreakTime - (float)(remainingBreakTime / 5);

        // Uruchom funkcj� dezaktywacji windy z op�nieniem
        //Invoke("DeactivateElevator", deactivateTime);
    }

    private void OnEnable()
    {
        // Pobierz czas do ko�ca obecnej przerwy z TruckManager
        float remainingBreakTime = truckManager.currentDelay;

        // Oblicz czas do dezaktywacji windy na podstawie procentu
        float deactivateTime = remainingBreakTime - (float)(remainingBreakTime / 5);

        // Uruchom funkcj� dezaktywacji windy z op�nieniem
        Invoke("DeactivateElevator", deactivateTime);
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("pack") && !hasDestroyedPacks)
     //   {
            //Destroy(other.gameObject); // Usu� paczk�, je�li jeszcze nie zniszczono
    //    }
    }

    private void DeactivateElevator()
    {
    //    if (!hasDestroyedPacks)
  //      {

   //     }
        DestroyPacks(); // Usu� paczki, je�li jeszcze nie zniszczono
        gameObject.SetActive(false); // Dezaktywuj wind�

        // Dodaj kod tutaj, je�li istnieje potrzeba wykonania dodatkowych dzia�a� przed dezaktywacj� windy
    }

    void DestroyPacks()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4.0f); // Dostosuj promie� wed�ug potrzeb

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