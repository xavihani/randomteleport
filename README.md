RandomTeleport Rust Plugin
The RandomTeleport plugin allows admins on a Rust server to teleport to a random player. It provides a simple command that can be used by admins to teleport to a random player's location.

Features
Teleport admins to a random player on the server.
Permission system to control who can use the teleport command.
Notifications displayed to the admin about the teleportation process.
Installation
Make sure you have the Oxide framework installed on your Rust server. If not, follow the instructions provided by Oxide to set it up.
Download the RandomTeleport.cs file from this repository.
Place the RandomTeleport.cs file into the server's oxide/plugins directory.
Restart the Rust server or use the Oxide command to load the plugin (oxide.load RandomTeleport).
Usage
Only admins or players with the randomteleport.use permission can use the teleport command.
To teleport to a random player, use the command /tr in the game chat.
After executing the command, you will be teleported to a random player's location.
A notification will be displayed indicating the teleportation and the target player's name.
If no players are found on the server, a notification will be displayed indicating that no players are available to teleport to.
Permissions
randomteleport.use - Allows players to use the teleport command.
Configuration (Optional)
The RandomTeleport plugin does not have any configuration options.

Support
If you encounter any issues or have any questions or suggestions regarding the RandomTeleport plugin, you can:
Contact the plugin author: Hani Xavi
License
The RandomTeleport plugin is licensed under the MIT License. See the LICENSE file for more information.

