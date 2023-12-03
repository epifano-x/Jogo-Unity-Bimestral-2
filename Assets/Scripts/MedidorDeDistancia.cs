using UnityEngine;
using UnityEngine.UI;

public class MedidorDeDistancia : MonoBehaviour
{
    private float pontoInicialX;  // A posição inicial da esfera no eixo X
    private float distanciaPercorrida;  // A distância total percorrida pela esfera
    public Text textoDistancia;  // Referência ao objeto Text no Canvas

    void Start()
    {
        // Armazena a posição inicial da esfera no eixo X no início do jogo
        pontoInicialX = transform.position.x;

        // Inicializa a distância percorrida como zero no início do jogo
        distanciaPercorrida = 0f;
    }

    void Update()
    {
        // Calcula a distância percorrida apenas no eixo X
        float distanciaX = transform.position.x - pontoInicialX;

        // Verifica se a esfera está se movendo para a direita (X maior que zero)
        if (distanciaX > 0)
        {
            // Atualiza a distância percorrida a cada frame
            distanciaPercorrida = distanciaX;

            // Atualiza o texto no Canvas com a distância percorrida formatada
            if (textoDistancia != null)
            {
                textoDistancia.text = "Distância Percorrida: " + distanciaPercorrida.ToString("F2") + " metros";
            }
        }
    }
}
