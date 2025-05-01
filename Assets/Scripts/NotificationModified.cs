using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationModified : MonoBehaviour
{
    //public static NotificationModified Instance { get; private set; }

    private const string defaultChannelId = "default_channel";
    private const string highScoreChannelId = "highscore_channel";

    //private void Awake()
    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    [Header("Referencias")]
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuthorization();
        RegisterNotificationChannels();
#endif
    }

#if UNITY_ANDROID
    private void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    private void RegisterNotificationChannels()
    {
        AndroidNotificationChannel defaultChannel = new AndroidNotificationChannel()
        {
            Id = defaultChannelId,
            Name = "Rondas",
            Importance = Importance.Default,
            Description = "Notificaciones de fin de ronda"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);

        // Canal para nuevo récord (Nuevo Puntaje Máximo)
        AndroidNotificationChannel highScoreChannel = new AndroidNotificationChannel()
        {
            Id = highScoreChannelId,
            Name = "Récord",
            Importance = Importance.High,
            Description = "Notificaciones de nuevo puntaje máximo"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(highScoreChannel);
    }

    /// <summary>
    /// Notificación al terminar la ronda, muestra el puntaje actual.
    /// </summary>
    public void SendRoundEndedNotification()
    {
        float score = scoreManager.currentScore;
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Ronda Terminada";
        notification.Text = "Puntaje conseguido: " + Mathf.FloorToInt(score);
        notification.FireTime = DateTime.Now.AddSeconds(1);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_0";

        AndroidNotificationCenter.SendNotification(notification, defaultChannelId);
    }

    /// <summary>
    /// Notificación al superar el récord, muestra el nuevo puntaje máximo.
    /// </summary>
    public void SendNewHighScoreNotification()
    {
        float score = scoreManager.currentScore;
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Nuevo Puntaje Máximo";
        notification.Text = "Lograste: " + Mathf.FloorToInt(score);
        notification.FireTime = DateTime.Now.AddSeconds(1);
        notification.SmallIcon = "icon_1";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, highScoreChannelId);
    }
#endif
}
