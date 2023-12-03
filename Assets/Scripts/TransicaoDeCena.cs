using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoDeCena : MonoBehaviour
{
    public string nomeDaCenaJogo;  // Nome da cena que você deseja carregar

    public void CarregarCenaDoJogo()
    {
                // Verifica se o jogo está pausado e, se estiver, despausa
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        // Carrega a cena com o nome fornecido
        SceneManager.LoadScene(nomeDaCenaJogo);
    }
}
