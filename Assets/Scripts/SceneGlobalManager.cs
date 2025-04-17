using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneGlobalManager : MonoBehaviour
{
    public static SceneGlobalManager Instance;

    [Header("Carga de Escena")]
    [SerializeField] private Image loadingBarFill;
    private string initialScene = "MainMenu";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;    
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoadScene")
        {
            StartCoroutine(LoadInitialSceneAsync());
        }
    }

    public void LoadSelector()
    {
        SceneManager.LoadSceneAsync("CharacterSelection", LoadSceneMode.Single);
    }
    public void LoadGameWithResults()
    {
        SceneManager.UnloadSceneAsync("CharacterSelection");
        StartCoroutine(LoadGameAndResultsAsync());
    }

    public void UnloadGameAndResults()
    {
        SceneManager.UnloadSceneAsync("MainGameGyroscope");
        SceneManager.UnloadSceneAsync("Results");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
                                        Application.Quit();
#endif
    }

    private IEnumerator LoadInitialSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(initialScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (loadingBarFill != null)
                loadingBarFill.fillAmount = progress;

            if (progress >= 1f)
            {
                yield return new WaitForSeconds(0.5f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    public void AssignLoadingBar(Image bar)
    {
        loadingBarFill = bar;
    }

    private IEnumerator LoadGameAndResultsAsync()
    {
        AsyncOperation gameLoad = SceneManager.LoadSceneAsync("MainGameGyroscope", LoadSceneMode.Additive);
        yield return gameLoad;

        AsyncOperation resultsLoad = SceneManager.LoadSceneAsync("Results", LoadSceneMode.Additive);
        yield return resultsLoad;

        Scene resultsScene = SceneManager.GetSceneByName("Results");
        if (resultsScene.isLoaded)
        {
            GameObject[] rootObjects = resultsScene.GetRootGameObjects();
            for (int i = 0; i < rootObjects.Length; i++)
            {
                rootObjects[i].SetActive(false);
            }
        }

        Scene currentScene = SceneManager.GetSceneByName("CharacterSelection");
        if (currentScene.IsValid())
        {
            yield return SceneManager.UnloadSceneAsync(currentScene);
        }
    }
    public void ShowResults()
    {
        Scene gameScene = SceneManager.GetSceneByName("MainGameGyroscope");
        if (gameScene.IsValid())
        {
            GameObject[] rootObjects = gameScene.GetRootGameObjects();
            for (int i = 0; i < rootObjects.Length; i++)
            {
                rootObjects[i].SetActive(false);
            }
        }
        Scene resultsScene = SceneManager.GetSceneByName("Results");
        if (resultsScene.IsValid())
        {
            GameObject[] rootObjects = resultsScene.GetRootGameObjects();
            for (int i = 0; i < rootObjects.Length; i++)
            {
                rootObjects[i].SetActive(true);
            }
        }
    }
}