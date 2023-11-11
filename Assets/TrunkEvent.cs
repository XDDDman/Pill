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

    public GameObject[] objectsToSpawn; // Tablica obiektów do spawnowania, jeden dla ka¿dego miasta

    public GameObject[] landingSpots;

    void Start()
    {
        // Wywo³anie funkcji TriggerTrunk
        //TriggerTrunk();
    }

    GameObject FindCityObject(string cityName)
    {
        // Szukaj obiektu w landingSpots o nazwie odpowiadaj¹cej wylosowanemu miastu
        foreach (GameObject citySlot in landingSpots)
        {
            if (citySlot.name == cityName)
            {
                return citySlot;
            }
        }

        return null; // Zwróæ null, jeœli obiekt nie zostanie znaleziony
    }

    public void TriggerTrunk()
    {
        // Losowanie jednego z miast na pocz¹tku
        selectedCity = citySlots[Random.Range(0, citySlots.Length)].cityName;
        Debug.Log("Zdarzenie trunk zosta³o wywo³ane w " + selectedCity + "!");

        // Dezaktywuj wszystkie obiekty w landingSpots
        foreach (GameObject citySlot in landingSpots)
        {
            citySlot.SetActive(false);
            Debug.Log("Aktywacja");
        }

        // Aktywuj obiekt odpowiadaj¹cy wylosowanemu miastu
        GameObject selectedCityObject = FindCityObject(selectedCity);
        if (selectedCityObject != null)
        {
            selectedCityObject.SetActive(true);
            Debug.Log("Wybór:" + selectedCityObject);
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu odpowiadaj¹cego wylosowanemu miastu.");
        }

        int numberOfObjects = Random.Range(5, 11); // Losowa iloœæ obiektów do spawnowania

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Losowe wspó³rzêdne w promieniu ko³a w osiach poziomych
            float angle = Random.Range(0f, 360f);
            float x = Mathf.Sin(angle) * (float)2.25; // Promieñ spawnowania
            float z = Mathf.Cos(angle) * (float)2.25; // Promieñ spawnowania

            // Tworzenie nowego obiektu w losowej pozycji w obrêbie ko³a
            Vector3 spawnPosition = new Vector3(x, 0f, z) + transform.position;
            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Uzyskaj indeks obiektu do spawnowania w zale¿noœci od miasta
            int objectIndex = GetObjectIndexForCity(selectedCity);

            // SprawdŸ, czy indeks jest poprawny
            if (objectIndex >= 0 && objectIndex < objectsToSpawn.Length)
            {
                // Spawnuj odpowiedni obiekt dla danego miasta
                Instantiate(objectsToSpawn[objectIndex], spawnPosition, spawnRotation);
            }
            else
            {
                Debug.LogError("Nieprawid³owy indeks obiektu do spawnowania dla miasta: " + selectedCity);
            }
        }
    }

    int GetObjectIndexForCity(string cityName)
    {
        // ZnajdŸ indeks obiektu do spawnowania dla danego miasta
        for (int i = 0; i < citySlots.Length; i++)
        {
            if (citySlots[i].cityName == cityName)
            {
                return i;
            }
        }

        return -1; // Zwróæ -1, jeœli miasto nie zosta³o znalezione (b³¹d)
    }
}