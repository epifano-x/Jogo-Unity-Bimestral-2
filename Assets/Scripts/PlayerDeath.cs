using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float deathHeight = 0f;
    public Canvas deathCanvas;

    private bool isDead = false;

    void Update()
    {
        if (transform.position.y < deathHeight && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Time.timeScale = 0;
        deathCanvas.gameObject.SetActive(true);

        // Obter o score com base na posição X do jogador
        int score = Mathf.RoundToInt(transform.position.x);

        // Obter uma referência ao ScoreManager
        ScoreManager scoreManager = GetComponent<ScoreManager>();

        // Definir o score do jogador no ScoreManager
        scoreManager.SetPlayerScore(score);
    }
}
