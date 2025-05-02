using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private PlayerController player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private NotificationSimple notificationAdd;
    private void Start()
    {
       
        ShipData selectedShip = gameData.selectedShip;

        if (selectedShip != null)
        {
            player.SetShip(selectedShip);
            scoreManager.SetScoreRate(selectedShip.scoreRate);
            healthManager.SetMaxHealth(selectedShip.life);
            healthManager.InitializeHealth();
            scoreManager.ResetScore();

            //Debug.Log("Ship loaded from GameData: " + selectedShip.shipName);
        }
        else
        {
            Debug.LogWarning("No ship selected in GameData!");
        }
        healthManager.OnHealthDepleted += ShowNotification;
        Debug.Log("GameManager enabled");
    }
    private void Awake()
    {
       // notificationAdd = GetComponent<NotificationSimple>();
    }
    
    private void OnEnable()
    {
        // ShowNotification();
        healthManager.OnHealthDepleted += ShowNotification;
        Debug.Log("GameManager enabled");
    }
    private void OnDisable()
    {
        // ShowNotification();
        healthManager.OnHealthDepleted -= ShowNotification;
        Debug.Log("GameManager disabled");
    }
    void ShowNotification()
    {
        if(healthManager.currentHealth <= 0)
        {
            if (scoreManager.GetHighScoreTest() == true)
            {
                notificationAdd.ShowNewHighScore();
                Debug.Log("notificacion alta");
            }
            else
            {
                notificationAdd.ShowNewScore();
                Debug.Log("notificacion normalita");
            }
                
        }
       
       // notificationAdd.ShowNewScore();//llamar a mostrar nueva noti
    }
    private void Update()
    {
        scoreManager.UpdateScore();
    }
}