using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Sta�a pr�dko�� ruchu

    void Update()
    {
        // Pobierz wej�cie gracza
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Oblicz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Uaktualnij pozycj� gracza natychmiastowo
        transform.position += movement * speed * Time.deltaTime;
    }
}