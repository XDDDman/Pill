using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public GameObject[] obiektyDoSprawdzenia;
    public List<GameObject> Pacs = new List<GameObject>();

    public string tokyoObjectName = "Tokyo";
    public string londonObjectName = "London";
    public string parisObjectName = "Paris";

    public int points;

    void Update()
    {
        // Iteruj przez wszystkie obiekty
        foreach (var obiekt in obiektyDoSprawdzenia)
        {
            // SprawdŸ, czy obiekt jest aktywny
            if (obiekt.activeSelf)
            {
                // Debug.Log(obiekt.name + " jest aktywny!");
                // Tutaj mo¿esz dodaæ dodatkowe dzia³ania dla aktywnego obiektu
            }
        }
    }

    public void Count()
    {
        int tokyoCount = 0;
        int londonCount = 0;
        int parisCount = 0;

        // Iteruj przez listê Pacs
        foreach (var pac in Pacs)
        {
            // SprawdŸ, który typ obiektu jest tokyo, london, czy paris na podstawie nazwy
            if (pac.name == tokyoObjectName)
            {
                tokyoCount++;
            }
            else if (pac.name == londonObjectName)
            {
                londonCount++;
            }
            else if (pac.name == parisObjectName)
            {
                parisCount++;
            }
            else Debug.Log(pac.name);
        }

        // Usuñ obiekty z listy Pacs
        foreach (var pac in Pacs)
        {
            Destroy(pac);
        }
        Pacs.Clear(); // Wyczyœæ listê po usuniêciu obiektów

        // Wyœwietl liczby obiektów dla ka¿dego typu
        Debug.Log("Tokyo Count: " + tokyoCount);
        Debug.Log("London Count: " + londonCount);
        Debug.Log("Paris Count: " + parisCount);

        // SprawdŸ, który obiekt jest aktywny i wykonaj odpowiedni¹ akcjê
        if (obiektyDoSprawdzenia[0].activeSelf)
        {
            Debug.Log("Obiekt o indeksie 0 jest aktywny!");
            // Tutaj mo¿esz dodaæ kod dla tego przypadku

            points =+ tokyoCount * 25;
            points =- londonCount * 5;
            points =- parisCount * 5;
        }
        else if (obiektyDoSprawdzenia[1].activeSelf)
        {
            Debug.Log("Obiekt o indeksie 1 jest aktywny!");
            // Tutaj mo¿esz dodaæ kod dla tego przypadku

            points =+ londonCount * 25;
            points =- parisCount * 5;
            points =- tokyoCount * 5;
        }
        else if (obiektyDoSprawdzenia[2].activeSelf)
        {
            Debug.Log("Obiekt o indeksie 2 jest aktywny!");
            // Tutaj mo¿esz dodaæ kod dla tego przypadku

            points =+ parisCount * 25;
            points =- londonCount *5;
            points =- tokyoCount *5;
        }
        else
        {
            Debug.Log("¯aden z obiektów nie jest aktywny!");
            // Tutaj mo¿esz dodaæ kod dla tego przypadku
        }
    }
}