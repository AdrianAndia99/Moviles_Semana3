using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //SceneManager.
    }
    public void ExitGame()
    {
       #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
       
       #else
                                Application.Quit();
       #endif
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
