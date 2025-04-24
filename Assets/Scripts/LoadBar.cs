using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadBar : MonoBehaviour
{
    [Header("UI de carga")]
    [SerializeField] private Image loadingBarFill;
    private string initialScene = "MainMenu";

    private void Start()
    {
        if (SceneGlobalManager.Instance != null)
        {
            AssignLoadingBar(loadingBarFill);

            if (SceneManager.GetActiveScene().name == "LoadScene")
            {
                StartCoroutine(LoadInitialSceneAsync());
            }
        }
        else
        {
            Debug.LogWarning("SceneGlobalManager no está en la escena.");
        }
    }
    public void LoadMenuAgain()
    {
        StartCoroutine(ReturnToMenuCoroutine());
    }

    private IEnumerator ReturnToMenuCoroutine()
    {
        yield return SceneGlobalManager.Instance.StartCoroutine(LoadInitialSceneAsync());
    }
    private IEnumerator LoadInitialSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(initialScene);
        operation.allowSceneActivation = false;

        float targetProgress = 0f;

        while (!operation.isDone)
        {
            float actualProgress = Mathf.Clamp01(operation.progress / 0.9f);

            targetProgress = Mathf.MoveTowards(targetProgress, actualProgress, Time.deltaTime * 0.5f);

            if (loadingBarFill != null)
                loadingBarFill.fillAmount = targetProgress;

            if (targetProgress >= 0.9f)
            {
                yield return new WaitForSeconds(1f);

                while (loadingBarFill.fillAmount < 1f)
                {
                    loadingBarFill.fillAmount += Time.deltaTime;
                    yield return null;
                }

                operation.allowSceneActivation = true;
                yield return null;
            }

            yield return null;
        }
    }
    public void AssignLoadingBar(Image bar)
    {
        loadingBarFill = bar;
    }
}
