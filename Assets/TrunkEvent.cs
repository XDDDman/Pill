using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CitySlot
{
    public string cityName;
    public GameObject cityObjectPrefab;
}

public class TrunkEvent : MonoBehaviour
{
    public CitySlot[] citySlots;

    private string selectedCity;

    public GameObject[] objectsToSpawn; // Tablica obiekt�w do spawnowania, jeden dla ka�dego miasta

    public GameObject[] landingSpots;

    void Start()
    {
        // Wywo�anie funkcji TriggerTrunk
        //TriggerTrunk();
    }

    GameObject FindCityObject(string cityName)
    {
        // Szukaj obiektu w landingSpots o nazwie odpowiadaj�cej wylosowanemu miastu
        foreach (GameObject citySlot in landingSpots)
        {
            if (citySlot.name == cityName)
            {
                return citySlot;
            }
        }

        return null; // Zwr�� null, je�li obiekt nie zostanie znaleziony
    }

    public void TriggerTrunk()
    {
        // Losowanie jednego z miast na pocz�tku
        selectedCity = citySlots[Random.Range(0, citySlots.Length)].cityName;
        Debug.Log("Zdarzenie trunk zosta�o wywo�ane w " + selectedCity + "!");

        // Dezaktywuj wszystkie obiekty w landingSpots
        foreach (GameObject citySlot in landingSpots)
        {
            citySlot.SetActive(false);
            Debug.Log("Aktywacja");
        }

        // Aktywuj obiekt odpowiadaj�cy wylosowanemu miastu
        GameObject selectedCityObject = FindCityObject(selectedCity);
        if (selectedCityObject != null)
        {
            selectedCityObject.SetActive(true);
            Debug.Log("Wyb�r:" + selectedCityObject);
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu odpowiadaj�cego wylosowanemu miastu.");
        }

        int numberOfObjects = Random.Range(5, 11); // Losowa ilo�� obiekt�w do spawnowania

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Losowe wsp�rz�dne w promieniu ko�a w osiach poziomych
            float angle = Random.Range(0f, 360f);
            float x = Mathf.Sin(angle) * (float)2.25; // Promie� spawnowania
            float z = Mathf.Cos(angle) * (float)2.25; // Promie� spawnowania

            // Tworzenie nowego obiektu w losowej pozycji w obr�bie ko�a
            Vector3 spawnPosition = new Vector3(x, 0f, z) + transform.position;
            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Uzyskaj indeks obiektu do spawnowania w zale�no�ci od miasta
            int objectIndex = GetObjectIndexForCity(selectedCity);

            // Sprawd�, czy indeks jest poprawny
            if (objectIndex >= 0 && objectIndex < objectsToSpawn.Length)
            {
                // Spawnuj odpowiedni obiekt dla danego miasta
                Instantiate(objectsToSpawn[objectIndex], spawnPosition, spawnRotation);
            }
            else
            {
                Debug.LogError("Nieprawid�owy indeks obiektu do spawnowania dla miasta: " + selectedCity);
            }
        }
    }

    int GetObjectIndexForCity(string cityName)
    {
        // Znajd� indeks obiektu do spawnowania dla danego miasta
        for (int i = 0; i < citySlots.Length; i++)
        {
            if (citySlots[i].cityName == cityName)
            {
                return i;
            }
        }

        return -1; // Zwr�� -1, je�li miasto nie zosta�o znalezione (b��d)
    }
}