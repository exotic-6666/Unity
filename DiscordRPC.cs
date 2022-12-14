using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordRPC : MonoBehaviour
{
    public Discord.Discord discord;

    void Start()
    {
        discord = new Discord.Discord(clientID, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity {
            State = "Playing in Beta",
            Details = "In a Multiplayer Match!",
            Timestamps =
            {
                Start = 5,
            },
            Assets =
            {
                LargeImage = "logo",
                LargeText = "Hover Text",
                SmallImage = "logo",
                SmallText = "Hover Text",
            },
        };
        activityManager.UpdateActivity(activity, (res) => {
            if(res == Discord.Result.Ok)
                Debug.Log("Discord Status set!");
            else
                Debug.LogError("Discord Status failed!");
        });

        var overlayManager = discord.GetOverlayManager();
    }

    void Update()
    {
        discord.RunCallbacks();
    }

    void OnApplicationQuit()
    {
        discord.Dispose();
    }
}
