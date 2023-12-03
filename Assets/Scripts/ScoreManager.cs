using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private List<int> allScores = new List<int>();

    private void Start()
    {
        // Carregar os scores salvos anteriormente
        LoadScores();
    }

    public void AddScore(float newScore)
    {
        // Adicionar a parte inteira do novo score à lista
        allScores.Add(Mathf.RoundToInt(newScore));

        // Salvar todos os scores
        SaveScores();
        Debug.Log("foi2");
    }

    public void SetPlayerScore(float playerScore)
    {
        // Define a parte inteira do score do jogador externamente
        AddScore(playerScore);
        Debug.Log("foi1");
    }

    public List<int> GetAllScores()
    {
        // Obter todos os scores
        return allScores;
    }

    private void SaveScores()
    {
        // Salvar os scores usando PlayerPrefs
        PlayerPrefs.SetString("AllScores", ListToString(allScores));
        PlayerPrefs.Save();
        Debug.Log("foi3");
    }

    private void LoadScores()
    {
        // Carregar os scores salvos anteriormente
        string loadedScores = PlayerPrefs.GetString("AllScores");
        allScores = StringToList(loadedScores);
    }

    private string ListToString(List<int> list)
    {
        // Converter a lista de inteiros em uma única string
        return string.Join(",", list.ConvertAll(i => i.ToString()).ToArray());
    }

    private List<int> StringToList(string str)
    {
        // Converter a string em uma lista de inteiros
        string[] strArray = str.Split(',');

        // Converter cada string para inteiro e adicionar à lista
        return new List<int>(System.Array.ConvertAll(strArray, int.Parse));
    }
}
