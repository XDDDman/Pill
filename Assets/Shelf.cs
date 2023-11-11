using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private bool czyZajeta = false;

    public void UstawZajeta()
    {
        //this.czyZajeta = czyZajeta;
        czyZajeta = true;
        //Debug.Log("Zaj�cie");
    }

    public void UstawWolna()
    {
        czyZajeta=false;
        Debug.Log("Uwolniona");
    }

    public bool CzyJestZajeta()
    {
        return czyZajeta;
    }

    void Update()
    {
        // Sprawd�, czy p�ka nie ma ju� dziecka z tagiem "pack" i ustaw czyZajeta na false
        if (transform.childCount > 1)
        {
            czyZajeta = true;
            //Debug.Log("trueee");
        }
        else
        {
            czyZajeta = false;
            //Debug.Log("falseee");
        }
    }
}