﻿using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facepunch.Steamworks;
using Il2CppSystem.Xml;

namespace MultiplayerMod
{
    public partial class MultiplayerMod : MelonMod
    {
        private void ServerSendToAll(INetworkMessage msg, P2PSend send)
        {
            P2PMessage pMsg = msg.MakeMsg();
            byte[] bytes = pMsg.GetBytes();
            foreach (SteamId p in players)
            {
                SteamNetworking.SendP2PPacket(p, bytes, bytes.Length, 0, send);
            }
        }

        private void ServerSendToAllExcept(INetworkMessage msg, P2PSend send, SteamId except)
        {
            P2PMessage pMsg = msg.MakeMsg();
            byte[] bytes = pMsg.GetBytes();
            foreach (SteamId p in players)
            {
                if (p != except)
                    SteamNetworking.SendP2PPacket(p, bytes, bytes.Length, 0, send);
            }
        }
    }
}