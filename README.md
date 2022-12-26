# About!
This allows you to find and hook the events so you dont need to patch OnPlayerJoin/leave. 

###### Example / Useage:
```cs
using VRC;
using VRC.Core;
using System;
using UnityEngine;
using MelonLoader;

[assembly: MelonInfo(typeof(YourClient.Main), "HooksExample", "1.0.0", "UrFingPoor")]
[assembly: MelonColor(ConsoleColor.Magenta)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace YourClient
{
    class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            YourClient.Hooks.NetworkManagerHook.Initialize();
            YourClient.Hooks.NetworkManagerHook.OnJoin += OnPlayerJoined;
            YourClient.Hooks.NetworkManagerHook.OnLeave += OnPlayerLeft;  
        }
		
        public void OnPlayerJoined(Player player)
	{         
            if (player.prop_APIUser_0 == null) return;
            LoggerInstance.Msg($"Player \"{apiUser.displayName}\" joined.");
        }

        public void OnPlayerLeft(Player player)
        {
           if (player.prop_APIUser_0 == null) return;
           LoggerInstance.Msg($"Player \"{apiUser.displayName}\" left.");
        }
    }
}

```


