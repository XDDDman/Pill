using UnityEngine;
using UnityEngine.SceneManagement;

public class PrzejscieDoSceny : MonoBehaviour
{
    // Nazwa docelowej sceny
    public string nazwaDocelowejSceny;

    // Metoda do przeniesienia siê do innej sceny
    public void PrzeniesDoSceny()
    {
        SceneManager.LoadScene(nazwaDocelowejSceny);
    }
}