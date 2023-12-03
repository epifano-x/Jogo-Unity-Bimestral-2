using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public ScoreManager scoreManager;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        List<int> allScores = scoreManager.GetAllScores();
        allScores.Sort((a, b) => b.CompareTo(a)); // Ordena do maior para o menor

        int numberOfScoresToShow = Mathf.Min(10, allScores.Count); // Mostra no máximo os 10 primeiros

        string scoreString = "Top 10 Scores:\n";

        for (int i = 0; i < numberOfScoresToShow; i++)
        {
            scoreString += $"{i + 1}. {allScores[i]}\n";
        }

        scoreText.text = scoreString;
    }
}
