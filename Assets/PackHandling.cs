using UnityEngine;

public class TeleportacjaPack : MonoBehaviour
{
    public string tagObiektuPack = "pack";
    public string tagPólki = "shelf";
    public float odlegloscTeleportacjiPack = 2f;
    public float odlegloscWkladaniaNaPolke = 3f; // Dodatkowa odleg³oœæ miêdzy graczem a pó³k¹ do umieszczania paczki
    public Vector3 offsetTeleportacji = new Vector3(0f, 1f, 0f);

    public bool czyNosziPack = false;
    private Transform aktualnaPaczka = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray promienMyszy = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit trafienie;

            if (Physics.Raycast(promienMyszy, out trafienie))
            {
                if (trafienie.collider.CompareTag(tagObiektuPack))
                {
                    if (!czyNosziPack)
                    {
                        float odleglosc = Vector3.Distance(transform.position, trafienie.collider.transform.position);

                        if (odleglosc < odlegloscTeleportacjiPack + 3)
                        {
                            trafienie.collider.transform.position = transform.position + offsetTeleportacji;
                            trafienie.collider.transform.SetParent(transform);

                            czyNosziPack = true;
                            aktualnaPaczka = trafienie.collider.transform;

                            // Oznacz pó³kê jako zajêt¹
                            trafienie.collider.transform.GetComponent<Shelf>().UstawWolna();
                        }
                    }
                    else
                    {
                        //aktualnaPaczka.SetParent(null);
                        //czyNosziPack = false;
                    }
                }
                else if (czyNosziPack && trafienie.collider.CompareTag(tagPólki))
                {
                    float odlegloscDoPolki = Vector3.Distance(transform.position, trafienie.collider.transform.position);

                    if (odlegloscDoPolki < (odlegloscTeleportacjiPack + 3))
                    {
                        if (!trafienie.collider.transform.GetComponent<Shelf>().CzyJestZajeta())
                        {
                            aktualnaPaczka.SetParent(trafienie.collider.transform);
                            aktualnaPaczka.position = trafienie.collider.transform.position;

                            // Oznacz pó³kê jako zajêt¹
                            trafienie.collider.transform.GetComponent<Shelf>().UstawZajeta();

                            czyNosziPack = false;
                        }
                    }
                }
            }
        }
    }
}