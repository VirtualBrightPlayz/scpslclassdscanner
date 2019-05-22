using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBrightPlayz.SCPSL.ClassDScanner
{
    internal class ClassDScannerEventHandler : IEventHandlerFixedUpdate, IEventHandlerSetNTFUnitName
    {
        private Plugin plugin;
        public static float pTime;

        public ClassDScannerEventHandler(Plugin mod9)
        {
            this.plugin = mod9;
        }

        void IEventHandlerFixedUpdate.OnFixedUpdate(FixedUpdateEvent ev)
        {
            pTime -= Time.fixedDeltaTime;
            if (pTime < 0)
            {
                pTime = ConfigManager.Manager.Config.GetFloatValue("dscanner_time", 180f);
                Scan();
            }
        }

        Room GreatestRoom(List<Room> list, List<Player> players)
        {
            Room greatest = null;
            Room close = null;
            int num = 0;
            int num3 = 0;
            float dist = 50.000001f;

            foreach (Room room in list)
            {
                if (room.RoomType == RoomType.CURVE || room.RoomType == RoomType.STRAIGHT || room.RoomType == RoomType.CUBICLES || room.RoomType == RoomType.UNDEFINED || room.RoomType == RoomType.X_INTERSECTION || room.RoomType == RoomType.TESLA_GATE || room.RoomType == RoomType.T_INTERSECTION) { }
                else
                {
                    float dist2 = 50f + 9999f;
                    int num2 = 0;
                    //var plrs = players.FindAll(p => Vector.Distance(room.Position, p.GetPosition()) <= 50f);
                    foreach (Player plr in players)
                    {
                        if (Vector.Distance(room.Position, plr.GetPosition()) > 50f || plr.TeamRole.Role != Role.CLASSD) { }
                        else
                        {
                            num2++;
                            if (Vector.Distance(room.Position, plr.GetPosition()) < dist2)
                            {
                                dist2 = Vector.Distance(room.Position, plr.GetPosition());
                            }
                        }
                    }

                    /*plugin.Info((dist2 < dist).ToString());
                    if (dist2 < dist || num2 >= num)
                        plugin.Info(room.RoomType.ToString());
                    plugin.Info((num2 >= num3).ToString());*/

                    if (dist2 < dist && num2 >= num)
                    {
                        dist = dist2;
                        num = num2;
                        close = room;
                        greatest = room;
                    }
                    if (num2 >= num3)
                    {
                        num3 = num2;
                        greatest = room;
                    }
                }
            }

            //plugin.Info(close.ToString());

            if (close == null || true)
                return greatest;
            else
                return close;

            List<RoomType> list2 = new List<RoomType>();
            foreach (Room type3 in list)
            {
                var type = type3.RoomType;
                if (list2.Contains(type)) continue;
                list2.Add(type);
                var list3 = list.FindAll(s => s.RoomType.Equals(type));
                int c = list3.Count;
                foreach (Room room in list3)
                {
                    if (c > num && Vector.Distance(room.Position, null) < dist)
                    {
                        num = c;
                        greatest = type3;
                    }
                }
            }
            return greatest;
        }

        void Scan()
        {
            List<Room> rooms = new List<Room>(plugin.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA));
            List<Player> players = plugin.Server.GetPlayers();
            string msg = " SCANNING FOR CLASSD PERSONNEL . CLASSD FOUND NEARBY ";
            string miscmsg = string.Empty;
            string scpmsg = string.Empty;
            string chkpmsg = string.Empty;
            List<RoomType> prooms2 = new List<RoomType>();
            List<Room> prooms = new List<Room>();
            Dictionary<Role, List<Vector>> scps = new Dictionary<Role, List<Vector>>();
            foreach (Player player in players)
            {
                if (player.TeamRole.Role == Role.CLASSD)
                {
                    //prooms.AddRange(rooms.FindAll(s => Vector.Distance(player.GetPosition(), s.Position) <= 50f));
                }
                else if (player.TeamRole.Team == Smod2.API.Team.SCP)
                {
                    if (scps.ContainsKey(player.TeamRole.Role))
                    {
                        scps[player.TeamRole.Role].Add(player.GetPosition());
                    }
                    else
                    {
                        scps.Add(player.TeamRole.Role, new List<Vector>() { player.GetPosition() });
                    }
                }
                else continue;
            }

            msg = " SCANNING FOR CLASSD PERSONNEL . CLASSD FOUND NEARBY ";

            Room greatroom = GreatestRoom(rooms, players.FindAll(p => p.TeamRole.Role.Equals(Role.CLASSD)));
            RoomType great = greatroom != null ? greatroom.RoomType : RoomType.UNDEFINED;
            //plugin.Info(great.ToString());
            ZoneType greatzone = greatroom != null ? greatroom.ZoneType : ZoneType.UNDEFINED;

            bool found = true;

            if (great == RoomType.SCP_914)
            {
                msg += " SCP 9 1 4 . ";
            }
            else if (great == RoomType.SCP_372)
            {
                msg += " CONTAINMENT CHAMBER FOR SCP 3 7 2 . ";
            }
            else if (great == RoomType.SCP_012)
            {
                msg += " SCP 0 1 2 . ";
            }
            else if (great == RoomType.SCP_049)
            {
                msg += " CONTAINMENT CHAMBER FOR SCP 0 4 9 . ";
            }
            else if (great == RoomType.SCP_079)
            {
                msg += " SCP 0 7 9 . ";
            }
            else if (great == RoomType.SCP_096)
            {
                msg += " CONTAINMENT CHAMBER FOR SCP 0 9 6 . ";
            }
            else if (great == RoomType.SCP_106)
            {
                msg += " CONTAINMENT CHAMBER FOR SCP 1 0 6 . ";
            }
            else if (great == RoomType.SCP_173)
            {
                msg += " CONTAINMENT CHAMBER FOR SCP 1 7 3 . ";
            }
            else if (great == RoomType.SCP_939)
            {
                msg += " CONTAINMENT CHAMBER FOR SCP 9 3 9 . ";
            }
            else if (great == RoomType.CLASS_D_CELLS)
            {
                msg += " CLASSD CONTAINMENT CHAMBER NATO_" + (char)Random.Range((int)'A', (int)'Z' + 1) + " . ";
            }
            else if (great == RoomType.AIRLOCK_00 || great == RoomType.AIRLOCK_01)
            {
                msg += " AIRLOCK NATO_" + (char)Random.Range((int)'A', (int)'Z' + 1) + " . ";
            }
            else if (great == RoomType.CHECKPOINT_A && greatzone == ZoneType.LCZ)
            {
                msg += " LIGHT CONTAINMENT ZONE CHECKPOINT NATO_A . ";
            }
            else if (great == RoomType.CHECKPOINT_B && greatzone == ZoneType.LCZ)
            {
                msg += " LIGHT CONTAINMENT ZONE CHECKPOINT NATO_B . ";
            }
            else if (great == RoomType.CHECKPOINT_A && greatzone == ZoneType.HCZ)
            {
                msg += " HEAVY CONTAINMENT ZONE CHECKPOINT NATO_A . ";
            }
            else if (great == RoomType.CHECKPOINT_B && greatzone == ZoneType.HCZ)
            {
                msg += " HEAVY CONTAINMENT ZONE CHECKPOINT NATO_B . ";
            }
            else if (great == RoomType.ENTRANCE_CHECKPOINT)
            {
                msg += " ENTRANCE ZONE CHECKPOINT . ";
            }
            else if (great == RoomType.MICROHID)
            {
                msg += " MICRO H I D WEAPON CHAMBER . ";
            }
            else if (great == RoomType.LCZ_ARMORY)
            {
                msg += " LIGHT CONTAINMENT ZONE WEAPONS CHAMBER . ";
            }
            else if (great == RoomType.HCZ_ARMORY)
            {
                msg += " HEAVY CONTAINMENT ZONE WEAPONS CHAMBER . ";
            }
            else if (great == RoomType.GATE_A)
            {
                msg += " GATE NATO_A . ";
            }
            else if (great == RoomType.GATE_B)
            {
                msg += " GATE NATO_B . ";
            }
            else if (great == RoomType.SERVER_ROOM)
            {
                msg += " DATA PROCESS CENTER . ";
            }
            else if (great == RoomType.WC00)
            {
                msg += " W C . ";
            }
            else
            {
                //plugin.Info(msg);
                plugin.Server.Map.AnnounceCustomMessage(" SCAN FOR CLASSD PERSONNEL WAS UNABLE TO BE COMPLETED . ");
                found = false;
            }

            if (found && greatroom != null)
            {
                Player plr = players.Find(p => Vector.Distance(p.GetPosition(), greatroom.Position) <= 50f && p.TeamRole.Team.Equals(Smod2.API.Team.SCP));
                if (plr != null)
                {
                    if (plr.TeamRole.Role == Role.SCP_173)
                    {
                        msg += " WARNING , SCPSUBJECT 1 7 3 HAS BEEN SPOTTED NEARBY THE LOCATION OF THE CLASSD . PROGRESS WITH CAUTION ";
                    }
                    if (plr.TeamRole.Role == Role.SCP_106)
                    {
                        msg += " WARNING , SCPSUBJECT 1 0 6 HAS BEEN SPOTTED NEARBY THE LOCATION OF THE CLASSD . PROGRESS WITH CAUTION ";
                    }
                    if (plr.TeamRole.Role == Role.SCP_939_53 || plr.TeamRole.Role == Role.SCP_939_89)
                    {
                        msg += " WARNING , SCPSUBJECT 9 3 9 HAS BEEN SPOTTED NEARBY THE LOCATION OF THE CLASSD . PROGRESS WITH CAUTION ";
                    }
                    if (plr.TeamRole.Role == Role.SCP_096)
                    {
                        msg += " WARNING , SCPSUBJECT 0 9 6 HAS BEEN SPOTTED NEARBY THE LOCATION OF THE CLASSD . PROGRESS WITH CAUTION . ";
                    }
                    if (plr.TeamRole.Role == Role.SCP_049)
                    {
                        msg += " WARNING , SCPSUBJECT 0 4 9 HAS BEEN SPOTTED NEARBY THE LOCATION OF THE CLASSD . PROGRESS WITH CAUTION . ";
                    }
                }
            }

            msg += " SCAN COMPLETE . ";

            if (found)
            {
                plugin.Info(msg);
                plugin.Server.Map.AnnounceCustomMessage(msg);
            }
        }

        void IEventHandlerSetNTFUnitName.OnSetNTFUnitName(SetNTFUnitNameEvent ev)
        {
            //Scan();
        }
    }
}