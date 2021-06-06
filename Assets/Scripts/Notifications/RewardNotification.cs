using System;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine;

public class RewardNotification
{
    private const string ANDROID_NOTIFIER_ID = "reward_notifier";

    public void CreateNotification()
    {
#if UNITY_ANDROID
        var androidSettingsChanel = new AndroidNotificationChannel
        {
            Id = ANDROID_NOTIFIER_ID,
            Name = "Reward Notifier",
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            Description = "Enter the game and get you day reward",
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);

        var androidSettingsNotification = new AndroidNotification
        {
            Title = androidSettingsChanel.Description,
            FireTime = DateTime.Now,
            Color = Color.black,
        };
        AndroidNotificationCenter.SendNotification(androidSettingsNotification, ANDROID_NOTIFIER_ID);
        var iosSettingsNotification = new iOSNotification
        {
            Data = DateTime.Now.ToString(),
        };

#elif UNITY_IOS
       var iosSettingsNotification = new iOSNotification
       {
           Identifier = "reward_notifier",
           Title = "Reward Notifier",
           Subtitle = "Subtitle notifier",
           Body = "Enter the game and get you day reward",
           Badge = 1,
           Data = DateTime.Now.ToString(),
           ForegroundPresentationOption = PresentationOption.Alert,
           ShowInForeground = false
       };
      
       iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
    }
}
