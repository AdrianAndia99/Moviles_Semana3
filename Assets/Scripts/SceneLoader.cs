using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string[] randomScenes;



    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadRandomScene()
    {
        int randomIndex = Random.Range(0, randomScenes.Length);
        SceneManager.LoadScene(randomScenes[randomIndex]);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        
        #else
                                        Application.Quit();
        #endif
    }
}