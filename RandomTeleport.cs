using System.Collections.Generic;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{
    [Info("RandomTeleport", "Hani Xavi", "1.0.0")]
    [Description("Allows admins to teleport to a random player.")]
    public class RandomTeleport : RustPlugin
    {
        private void Init()
        {
            permission.RegisterPermission("randomteleport.use", this);
            AddCovalenceCommand("tr", nameof(RandomTeleportCommand));
        }

        private void RandomTeleportCommand(IPlayer player, string command, string[] args)
        {
            if (player.IsAdmin || permission.UserHasPermission(player.Id, "randomteleport.use"))
            {
                var targetPlayer = FindRandomPlayer();
                if (targetPlayer != null)
                {
                    TeleportPlayer(player, targetPlayer);
                    ShowTeleportNotification(player, targetPlayer.displayName);
                    RemoveNotificationAfterDelay(player);
                }
                else
                {
                    player.Message("No players found to teleport to.");
                    ShowNoPlayersNotification(player);
                    RemoveNotificationAfterDelay(player);
                }
            }
            else
            {
                player.Message("You don't have permission to use this command.");
            }
        }

        private BasePlayer FindRandomPlayer()
        {
            var activePlayers = BasePlayer.activePlayerList;
            if (activePlayers.Count > 1)
            {
                var randomPlayerIndex = UnityEngine.Random.Range(0, activePlayers.Count);
                return activePlayers[randomPlayerIndex];
            }
            return null;
        }

        private void TeleportPlayer(IPlayer player, BasePlayer targetPlayer)
        {
            var basePlayer = player.Object as BasePlayer;
            if (basePlayer != null && basePlayer != targetPlayer)
            {
                basePlayer.Teleport(targetPlayer.transform.position);
            }
        }

        private void ShowTeleportNotification(IPlayer player, string targetPlayerName)
        {
            var message = $"<color=#ff0000>You have teleported to</color>: <color=#00ff00>{targetPlayerName}</color>.";
            player.Command("gametip.hidegametip");
            player.Command($"gametip.showgametip \"{message}\"");
        }

        private void ShowNoPlayersNotification(IPlayer player)
        {
            var message = "<color=#ff0000>No players found to teleport to.</color>";
            player.Command("gametip.hidegametip");
            player.Command($"gametip.showgametip \"{message}\"");
        }

        private void RemoveNotificationAfterDelay(IPlayer player)
        {
            timer.Once(15f, () =>
            {
                player.Command("gametip.hidegametip");
            });
        }
    }
}
