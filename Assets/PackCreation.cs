using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackCreation : MonoBehaviour
{
    public List<string> adresaci;
    public List<string> typy;

    public List<GameObject> prefabrykaty;
    public PointsManager pointsManager;

    void Start()
    {
        // Losowanie adresata, opakowania i typu
        string wybranyAdresat = LosujElement(adresaci);
        string wybranyTyp = LosujElement(typy);

        // Tworzenie nazwy prefabu na podstawie wylosowanych parametrów
        string nazwaPrefabu = $"{wybranyAdresat}-{wybranyTyp}";
        //Debug.Log("Nazwa prefabu: " + nazwaPrefabu);

        // Przypisanie odpowiedniego prefabu na podstawie nazwy
        GameObject prefab = prefabrykaty.Find(p => p.name == nazwaPrefabu);

        // Utwórz instancjê prefabu
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    string LosujElement(List<string> lista)
    {
        int indeks = Random.Range(0, lista.Count);
        return lista[indeks];
    }
}