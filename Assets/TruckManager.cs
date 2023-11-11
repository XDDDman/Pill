using UnityEngine;

public class TruckManager : MonoBehaviour
{
    public TrunkEvent trunkEventScript;
    public float initialDelay = 5f;
    public float exponentialFactor = 0.9f;

    public float currentDelay;

    void Start()
    {
        currentDelay = initialDelay; // Ustawienie pocz¹tkowego opóŸnienia

        // Rozpocznij odliczanie z opóŸnieniem
        InvokeRepeating("TriggerTrunkEvent", initialDelay, currentDelay);
    }

    void TriggerTrunkEvent()
    {
        // Informacja w konsoli o czasie trwania odliczania
        Debug.Log("Odliczanie: " + currentDelay + " sekundy.");

        trunkEventScript.TriggerTrunk();

        // Zmniejsz czas opóŸnienia wyk³adniczo
        currentDelay *= exponentialFactor;

        // Jeœli czas opóŸnienia jest zbyt krótki, zatrzymaj odliczanie
        if (currentDelay < 0.1f)
        {
            CancelInvoke("TriggerTrunkEvent");
            Debug.Log("Odliczanie zatrzymane.");
        }
    }
}