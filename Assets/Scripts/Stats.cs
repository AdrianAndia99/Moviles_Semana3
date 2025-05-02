using UnityEngine;
using UnityEngine.UIElements;

public class Stats : MonoBehaviour
{
   
    void Start()
    {
        
    }
    private void Awake()
    {
        if (this != null)
        {
            this.gameObject.SetActive(false);
        }
       

    }
    public void ActivePanelColors()
    {
        this.gameObject.SetActive(true);

    }
    public void InactivePanelColors()
    {
        this.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
