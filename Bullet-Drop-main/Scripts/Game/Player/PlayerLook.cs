using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    void Update()
    {
        // Pega posição do mouse na tela
        Vector3 mouseScreenPos = Input.mousePosition;

        // Define a distância do personagem para a câmera (eixo Z)
        mouseScreenPos.z = -Camera.main.transform.position.z;

        // Converte a posição do mouse para o mundo
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Calcula a direção do personagem até o mouse
        Vector3 direction = mouseWorldPos - transform.position;

        // Calcula o ângulo entre o eixo X e a direção, em graus
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica a rotação no personagem no eixo Z (2D)
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
