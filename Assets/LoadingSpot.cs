using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSpot : MonoBehaviour
{
    public GameObject destroyedPrefab;  // Przechowuje informacje o zniszczonym prefabie
    public List<GameObject> destroyedPacs;  // Przechowuje informacje o zniszczonych paczkach prefabów

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy obiekt wchodz¹cy do obszaru jest paczk¹
        if (other.CompareTag("pack"))
        {
            // Zniszcz paczkê
            Destroy(other.gameObject);

            // Dodaj zniszczon¹ paczkê do listy zniszczonych paczek
            destroyedPacs.Add(other.gameObject);

            // Pobierz informacje o zniszczonym prefabie z paczki
            PackCreation packCreationScript = other.gameObject.GetComponent<PackCreation>();
            if (packCreationScript != null)
            {
                destroyedPrefab = packCreationScript.prefabrykaty[0];  // Zak³adam, ¿e interesuje ciê tylko pierwszy prefab z listy paczki
            }
            else
            {
                Debug.LogError("Brak skryptu PackCreation na zniszczonej paczce!");
            }

            // Wywo³aj metodê z PointsManager (mo¿esz przekazaæ tê informacjê, aby obliczyæ punkty)
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