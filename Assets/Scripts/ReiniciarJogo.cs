using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJogo : MonoBehaviour
{
    // Este método será chamado quando o botão for clicado
    public void ReiniciarCena()
    {
        // Verifica se o jogo está pausado e, se estiver, despausa
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        // Obtém o número da cena atual
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;

        // Recarrega a cena atual
        SceneManager.LoadScene(cenaAtual);
    }
}
