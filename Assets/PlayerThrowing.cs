using UnityEngine;

public class RzutObiektem : MonoBehaviour
{
    public float silaRzutu = 10f;
    private Transform obiektDoRzucenia;
    public GameObject packHandling;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleChildObject();
        }
    }

    void ToggleChildObject()
    {
        if (obiektDoRzucenia == null)
        {
            // Jeœli obiekt do rzucenia nie istnieje, przypisz go jako dziecko
            if (transform.childCount > 0)
            {
                obiektDoRzucenia = transform.GetChild(0);
            }
            else
            {
                Debug.LogError("Brak dziecka do przypisania!");
                return;
            }
        }
        else
        {
            // Jeœli obiekt do rzucenia istnieje, usuñ go z rodzica
            obiektDoRzucenia.parent = null;

            // Dodaj si³ê do rzucanego obiektu
            Rigidbody rb = obiektDoRzucenia.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * silaRzutu, ForceMode.Impulse);
            }
            else
            {
                Debug.LogError("Obiekt do rzucenia nie ma komponentu Rigidbody!");
            }

            // Zresetuj referencjê do obiektu do rzucenia
            obiektDoRzucenia = null;
            packHandling.GetComponent<TeleportacjaPack>().czyNosziPack = false;
        }
    }
}