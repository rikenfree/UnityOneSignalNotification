using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;
//using Unity.Notifications;
using UnityEngine.Networking;

public class OneSignalNotification : MonoBehaviour
{
    public static OneSignalNotification instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string appID = "";

    void Start()
    {
        OneSignal.Initialize(appID);
    }

    // On Level Complete
    public void OnLevelComplete(int level)
    {
        Debug.Log("Level " + level + " Completed!");
        OneSignal.User.AddTag("level_completed", level.ToString());

        if (level == 5 || level == 10 || level == 15 || level == 20 || level == 25) // Key milestone levels
        {
            SendAchievementNotification("You’re on a Roll! 🌟", $"Congrats on completing Level {level}! Keep going to unlock new themes and rewards.");
        }
    }

    // On Level Complete
    public void OnPlayerWin()
    {
        OneSignal.User.AddTag("first_win", "1");
        if (!PlayerPrefs.HasKey("FirstWin"))
        {
            PlayerPrefs.SetInt("FirstWin", 1);
            PlayerPrefs.Save();

            SendAchievementNotification("Victory is Yours! 🏆", "Congratulations on your first win! More challenges await.");
        }
    }


    public void SendAchievementNotification(string message, string playerId)
    {
        Debug.Log("Messages : " + message);
        StartCoroutine(SendPushNotification(message, playerId));
    }

    private IEnumerator SendPushNotification(string message, string playerId)
    {
        string url = "https://onesignal.com/api/v1/notifications";
        string json = "{\"app_id\": \"" + appID + "\", \"contents\": {\"en\": \"" + message + "\"}, \"include_player_ids\": [\"" + playerId + "\"]}";

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            //www.SetRequestHeader("Authorization", "Basic " + restApiKey);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Notification sent successfully!");
            }
            else
            {
                Debug.LogError("Error sending notification: " + www.error);
            }
        }
    }

    //private void SendAchievementNotification(string title, string message)
    //{
    //    var notificationData = new Dictionary<string, object>
    //    {
    //        { "headings", new Dictionary<string, string> { { "en", title } } },
    //        { "contents", new Dictionary<string, string> { { "en", message } } },
    //        { "include_player_ids", new List<string> { OneSignal.User.PushSubscription.Id } } // Send to specific user
    //    };

    //}


}