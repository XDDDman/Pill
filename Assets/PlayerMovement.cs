using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Sta³a prêdkoœæ ruchu

    void Update()
    {
        // Pobierz wejœcie gracza
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Oblicz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Uaktualnij pozycjê gracza natychmiastowo
        transform.position += movement * speed * Time.deltaTime;
    }
}