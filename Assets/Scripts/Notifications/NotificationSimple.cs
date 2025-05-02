using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSimple : MonoBehaviour
{
    private const string idCanal = "canalNotificacion";
    [SerializeField] ScoreManager scoreText;

    // Guardan el ID de la última notificación enviada por tipo
    //int normalScoreNotificationId = -1;
    //int highScoreNotificationId = -1;

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuthorization();
        RegisterNotificationChannel();
        RegisterAnotherChannel();
#endif
    }

#if UNITY_ANDROID
    public void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel();
        channel.Id = "normal_score";
        channel.Name = "Normal";
        channel.Importance = Importance.Default;
        channel.Description = "Notifications";

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void RegisterAnotherChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel();
        channel.Id = "high_score";
        channel.Name = "High";
        channel.Importance = Importance.Default;
        channel.Description = "Notifications";

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNewScore(string title, string text, int fireTimeInHours)
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();
        AndroidNotification scoreNotification = new AndroidNotification();
        scoreNotification.Title = title;
        scoreNotification.Text = text;
        scoreNotification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        scoreNotification.SmallIcon = "bbokarismall";
        scoreNotification.LargeIcon = "largenormal";

        /*if (normalScoreNotificationId != -1)
        {
            AndroidNotificationCenter.CancelNotification(normalScoreNotificationId);
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.CancelAllScheduledNotifications();
        }

        // Envía una nueva notificación y guarda el nuevo ID
        normalScoreNotificationId =*/
        AndroidNotificationCenter.SendNotification(scoreNotification, "normal_score");
    }

    public void SendNewHighScore(string title, string text, int fireTimeInHours)
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();
        AndroidNotification scoreNotification = new AndroidNotification();
        scoreNotification.Title = title;
        scoreNotification.Text = text;
        scoreNotification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        scoreNotification.SmallIcon = "wolfsmall";
        scoreNotification.LargeIcon = "largehigh";

        /*if (highScoreNotificationId != -1)
        {
            AndroidNotificationCenter.CancelNotification(highScoreNotificationId);
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.CancelAllScheduledNotifications();
        }

        highScoreNotificationId = */
        AndroidNotificationCenter.SendNotification(scoreNotification, "high_score");
    }

    public void ShowNewScore()
    {
        int score = Mathf.FloorToInt(scoreText.currentScore);
        SendNewScore("Round finished!", "New score registered: " + score, 0);
        Debug.Log("Notificación normal enviada.");
    }

    public void ShowNewHighScore()
    {
        int score = Mathf.FloorToInt(scoreText.currentScore);
        SendNewHighScore("New Maximum Score", "New record registered: " + score, 0);
        Debug.Log("Notificación de high score enviada.");
    }

    public void ButtonFunction()
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Dummy Notification";
        notification.Text = "This is a sample Notification";
        notification.FireTime = DateTime.Now;
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, "normal_score");
    }
#endif
}
