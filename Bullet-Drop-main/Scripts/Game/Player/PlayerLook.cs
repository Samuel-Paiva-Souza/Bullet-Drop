using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    void Update()
    {
        // Pega posi��o do mouse na tela
        Vector3 mouseScreenPos = Input.mousePosition;

        // Define a dist�ncia do personagem para a c�mera (eixo Z)
        mouseScreenPos.z = -Camera.main.transform.position.z;

        // Converte a posi��o do mouse para o mundo
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Calcula a dire��o do personagem at� o mouse
        Vector3 direction = mouseWorldPos - transform.position;

        // Calcula o �ngulo entre o eixo X e a dire��o, em graus
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica a rota��o no personagem no eixo Z (2D)
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
