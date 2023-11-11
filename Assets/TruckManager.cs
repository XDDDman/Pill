using UnityEngine;

public class TruckManager : MonoBehaviour
{
    public TrunkEvent trunkEventScript;
    public float initialDelay = 5f;
    public float exponentialFactor = 0.9f;

    public float currentDelay;

    void Start()
    {
        currentDelay = initialDelay; // Ustawienie pocz�tkowego op�nienia

        // Rozpocznij odliczanie z op�nieniem
        InvokeRepeating("TriggerTrunkEvent", initialDelay, currentDelay);
    }

    void TriggerTrunkEvent()
    {
        // Informacja w konsoli o czasie trwania odliczania
        Debug.Log("Odliczanie: " + currentDelay + " sekundy.");

        trunkEventScript.TriggerTrunk();

        // Zmniejsz czas op�nienia wyk�adniczo
        currentDelay *= exponentialFactor;

        // Je�li czas op�nienia jest zbyt kr�tki, zatrzymaj odliczanie
        if (currentDelay < 0.1f)
        {
            CancelInvoke("TriggerTrunkEvent");
            Debug.Log("Odliczanie zatrzymane.");
        }
    }
}