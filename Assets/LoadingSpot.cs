using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSpot : MonoBehaviour
{
    public GameObject destroyedPrefab;  // Przechowuje informacje o zniszczonym prefabie
    public List<GameObject> destroyedPacs;  // Przechowuje informacje o zniszczonych paczkach prefab�w

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy obiekt wchodz�cy do obszaru jest paczk�
        if (other.CompareTag("pack"))
        {
            // Zniszcz paczk�
            Destroy(other.gameObject);

            // Dodaj zniszczon� paczk� do listy zniszczonych paczek
            destroyedPacs.Add(other.gameObject);

            // Pobierz informacje o zniszczonym prefabie z paczki
            PackCreation packCreationScript = other.gameObject.GetComponent<PackCreation>();
            if (packCreationScript != null)
            {
                destroyedPrefab = packCreationScript.prefabrykaty[0];  // Zak�adam, �e interesuje ci� tylko pierwszy prefab z listy paczki
            }
            else
            {
                Debug.LogError("Brak skryptu PackCreation na zniszczonej paczce!");
            }

            // Wywo�aj metod� z PointsManager (mo�esz przekaza� t� informacj�, aby obliczy� punkty)
            PointsManager pointsManager = FindObjectOfType<PointsManager>();
            if (pointsManager != null)
            {
                //pointsManager.CalculatePoints();
            }
            else
            {
                Debug.LogError("Nie znaleziono obiektu z PointsManager!");
            }
        }
    }
}