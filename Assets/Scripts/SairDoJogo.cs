using UnityEngine;

public class SairDoJogo : MonoBehaviour
{
    public void Sair()
    {
        // Isso só funciona em builds standalone (não no editor)
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        // Isso encerrará a execução no editor do Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
