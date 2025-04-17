using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void OnSelectButton()
    {
        SceneGlobalManager.Instance.LoadSelector();
    }
    public void OnPlayButton()
    {
        SceneGlobalManager.Instance.LoadGameWithResults();
    }

    public void OnBackToMenu()
    {
        SceneGlobalManager.Instance.UnloadGameAndResults();
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);

    }
    public void OnQuitButton()
    {
        SceneGlobalManager.Instance.QuitGame();
    }
}