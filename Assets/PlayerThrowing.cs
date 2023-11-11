using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    private Transform childTransform;
    public TeleportacjaPack teleportacjaPack;

    void Start()
    {

    }

    void Update()
    {
        // Zak³adamy, ¿e dziecko jest pierwszym dzieckiem obiektu gracza
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(0);
        }
        else
        {
            childTransform = null;
        }

        // Sprawdzamy, czy istnieje dziecko i czy wciœniêto prawy przycisk myszy (PPM)
        if (childTransform != null && Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.collider.CompareTag("wind"))
                {
                    // Teleportujemy dziecko o 2 jednostki przed obiektem gracza
                    Vector3 offset = transform.forward * 4f;
                    childTransform.position = transform.position + offset;

                    // "Odczepiamy" dziecko, przestaje byæ childem obiektu gracza
                    childTransform.parent = null;

                    teleportacjaPack.czyNosziPack = false;
                }
                else
                {
                    Debug.Log("Gracz nie jest na obiekcie z tagiem 'wind'.");
                }
            }
        }
    }
}