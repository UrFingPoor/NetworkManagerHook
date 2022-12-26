using System;
using VRC;
using VRC.Core;

namespace YourClient.Hooks
{
    public static class NetworkManagerHook
    {
        public static event Action<Player> OnJoin, OnLeave;
        private static bool isInitialized, EventDetected, EventFound;
        public static void OnPlayerEvent1(Player player)
        {
            if (!EventDetected) EventFound = true; EventDetected = true;
            if (player == null) return;        
            (EventFound ? OnJoin : OnLeave)?.Invoke(player);
        }

        public static void OnPlayerEvent2(Player player)
        {
            if (!EventDetected) EventFound = true; EventDetected = true;
            if (player == null) return;       
            (EventFound ? OnLeave : OnJoin)?.Invoke(player);
        }

        public static void Initialize()
        {
            if (isInitialized || NetworkManager.field_Internal_Static_NetworkManager_0 is null) return;      
            var Player_0 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
            var Player_1 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;
            OnPlayerEventAdd(Player_0, OnPlayerEvent1);
            OnPlayerEventAdd(Player_1, OnPlayerEvent2);
            isInitialized = true;
        }

        private static void OnPlayerEventAdd(VRCEventDelegate<Player> field, Action<Player> eventHandler)
        {
            field.field_Private_HashSet_1_UnityAction_1_T_0.Add(eventHandler);
        }
    }
}
