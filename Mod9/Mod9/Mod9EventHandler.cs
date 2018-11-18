using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBrightPlayz.SCPSL.Mod9
{
    internal class Mod9EventHandler : IEventHandlerFixedUpdate
    {
        private Plugin plugin;
        public static float pTime;

        public Mod9EventHandler(Plugin mod9)
        {
            this.plugin = mod9;
        }

        void IEventHandlerFixedUpdate.OnFixedUpdate(FixedUpdateEvent ev)
        {
            pTime -= Time.fixedDeltaTime;
            if (pTime < 0)
            {
                pTime = ConfigManager.Manager.Config.GetFloatValue("dscanner_time", 180f);
                var players = plugin.Server.GetPlayers();
                float mindist = 50;
                string msg = string.Empty;
                string msgelev = string.Empty;
                string msgchk = string.Empty;
                string msggate = string.Empty;
                string msgscp = string.Empty;
                string msgmisc = string.Empty;
                bool hasfound = false;
                bool lczfound = false;
                bool hczfound = false;
                bool ezfound = false;
                bool chkpt = false;
                bool elevsys = false;
                bool gate = false;
                bool scp = false;
                bool misc = false;
                List<string> roomlist = new List<string>();
                var lczobjs = GameObject.Find("LightRooms").transform;
                foreach (var player in players)
                {
                    if (player.TeamRole.Team != Smod2.API.Team.CLASSD) continue;
                    float dist = float.MaxValue;
                    string roomname = string.Empty;
                    for (int i = 0; i < lczobjs.childCount; i++)
                    {
                        Transform room = lczobjs.GetChild(i);
                        Vector3 roompos = new Vector3(room.position.x, room.position.y, room.position.z);
                        if (room.name.StartsWith("Root_ChkpA"))
                        {
                            //((GameObject)player.GetGameObject()).transform.position;
                            //Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, room.position);

                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_ChkpA";
                            }
                        }
                        if (room.name.StartsWith("Root_ChkpB"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_ChkpB";
                            }
                        }
                        if (room.name.StartsWith("Root_Checkpoint"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Checkpoint";
                            }
                        }
                        if (room.name.StartsWith("Root_372"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_372";
                            }
                        }
                        if (room.name.StartsWith("Root_173"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_173";
                            }
                        }
                        if (room.name.StartsWith("Root_914"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_914";
                            }
                        }
                        if (room.name.StartsWith("Root_012"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_012";
                            }
                        }
                    }
                    if (dist < mindist)
                    {
                        if (roomname.Equals("Root_ChkpA") && !roomlist.Contains("Root_ChkpA"))
                        {
                            roomlist.Add("Root_ChkpA");
                            if (!hasfound)
                            {
                                if (!chkpt)
                                    msgchk += " CLASSD NEARBY CHECKPOINT A ";
                                else
                                    msgchk += " and A ";
                                chkpt = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!chkpt)
                                    msgchk += " CHECKPOINT A ";
                                else
                                    msgchk += " and A ";
                                chkpt = true;
                                hasfound = true;
                            }
                        }
                        if (roomname.Equals("Root_ChkpB") && !roomlist.Contains("Root_ChkpB"))
                        {
                            roomlist.Add("Root_ChkpB");
                            if (!hasfound)
                            {
                                if (!chkpt)
                                    msgchk += " CLASSD NEARBY CHECKPOINT B ";
                                else
                                    msgchk += " and B ";
                                chkpt = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!chkpt)
                                    msgchk += " CHECKPOINT B ";
                                else
                                    msgchk += " and B ";
                                chkpt = true;
                                hasfound = true;
                            }
                        }
                        //012
                        if (roomname.Equals("Root_012") && !roomlist.Contains("Root_012"))
                        {
                            roomlist.Add("Root_012");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 0 1 2 ";
                                else
                                    msgscp += " and 0 1 2 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 0 1 2 ";
                                else
                                    msgscp += " and 0 1 2 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //914
                        if (roomname.Equals("Root_914") && !roomlist.Contains("Root_914"))
                        {
                            roomlist.Add("Root_914");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 9 1 4 ";
                                else
                                    msgscp += " and 9 1 4 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 9 1 4 ";
                                else
                                    msgscp += " and 9 1 4 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //173
                        if (roomname.Equals("Root_173") && !roomlist.Contains("Root_173"))
                        {
                            roomlist.Add("Root_173");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 1 7 3 ";
                                else
                                    msgscp += " and 1 7 3 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 1 7 3 ";
                                else
                                    msgscp += " and 1 7 3 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //372
                        if (roomname.Equals("Root_372") && !roomlist.Contains("Root_372"))
                        {
                            roomlist.Add("Root_372");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 3 7 2 ";
                                else
                                    msgscp += " and 3 7 2 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 3 7 2 ";
                                else
                                    msgscp += " and 3 7 2 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                    }
                    /*else if (((GameObject)player.GetGameObject()).transform.position.y < && !lczfound)
                    {
                        msg += " CLASSD IN LIGHT CONTAINMENT ZONE ";
                        hasfound = true;
                        lczfound = true;
                    }*/
                }

                var hczobjs = GameObject.Find("Heavy rooms").transform;
                foreach (var player in players)
                {
                    if (player.TeamRole.Team != Smod2.API.Team.CLASSD) continue;
                    float dist = float.MaxValue;
                    string roomname = string.Empty;
                    for (int i = 0; i < hczobjs.childCount; i++)
                    {
                        Transform room = hczobjs.GetChild(i);
                        Vector3 roompos = new Vector3(room.position.x, room.position.y, room.position.z);
                        if (room.name.StartsWith("Root_LiftA"))
                        {
                            //((GameObject)player.GetGameObject()).transform.position;
                            //Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, room.position);

                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_LiftA";
                            }
                        }
                        if (room.name.StartsWith("Root_LiftB"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_LiftB";
                            }
                        }
                        if (room.name.StartsWith("Root_Checkpoint"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Checkpoint";
                            }
                        }
                        if (room.name.StartsWith("Root_457"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_457";
                            }
                        }
                        if (room.name.StartsWith("Root_106"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_106";
                            }
                        }
                        if (room.name.StartsWith("Root_Testroom"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Testroom";
                            }
                        }
                        if (room.name.StartsWith("Root_079"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_079";
                            }
                        }
                        if (room.name.StartsWith("Root_049"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_049";
                            }
                        }
                        if (room.name.StartsWith("Root_Hid"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Hid";
                            }
                        }
                        if (room.name.StartsWith("Root_Nuke"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Nuke";
                            }
                        }
                        if (room.name.StartsWith("Root_Servers"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Servers";
                            }
                        }
                    }
                    if (dist < mindist)
                    {
                        if (roomname.Equals("Root_LiftA") && !roomlist.Contains("Root_LiftA"))
                        {
                            roomlist.Add("Root_LiftB");
                            if (!hasfound)
                            {
                                if (!elevsys)
                                    msgelev += " CLASSD NEARBY ELEVATOR SYSTEM A ";
                                else
                                    msgelev += " and A ";
                                elevsys = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!elevsys)
                                    msgelev += " ELEVATOR SYSTEM A ";
                                else
                                    msgelev += " and A ";
                                elevsys = true;
                                hasfound = true;
                            }
                        }
                        if (roomname.Equals("Root_LiftB") && !roomlist.Contains("Root_LiftB"))
                        {
                            roomlist.Add("Root_LiftB");
                            if (!hasfound)
                            {
                                if (!elevsys)
                                    msgelev += " CLASSD NEARBY ELEVATOR SYSTEM B ";
                                else
                                    msgelev += " and B ";
                                elevsys = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!elevsys)
                                    msgelev += " ELEVATOR SYSTEM B ";
                                else
                                    msgelev += " and B ";
                                elevsys = true;
                                hasfound = true;
                            }
                        }
                        if (roomname.Equals("Root_Checkpoint") && !roomlist.Contains("Root_Checkpoint"))
                        {
                            roomlist.Add("Root_Checkpoint");
                            if (!hasfound)
                            {
                                if (!chkpt)
                                    msgchk += " CLASSD NEARBY ENTRANCE ZONE CHECKPOINT ";
                                else
                                    msgchk += " and ENTRANCE ZONE ";
                                chkpt = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!chkpt)
                                    msgchk += " ENTRANCE ZONE CHECKPOINT ";
                                else
                                    msgchk += " and ENTRANCE ZONE ";
                                chkpt = true;
                                hasfound = true;
                            }
                        }
                        //096
                        if (roomname.Equals("Root_457") && !roomlist.Contains("Root_457"))
                        {
                            roomlist.Add("Root_457");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 0 9 6 ";
                                else
                                    msgscp += " and 0 9 6 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 0 9 6 ";
                                else
                                    msgscp += " and 0 9 6 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //939
                        if (roomname.Equals("Root_Testroom") && !roomlist.Contains("Root_Testroom"))
                        {
                            roomlist.Add("Root_Testroom");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 9 3 9 ";
                                else
                                    msgscp += " and 9 3 9 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 9 3 9 ";
                                else
                                    msgscp += " and 9 3 9 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //079
                        if (roomname.Equals("Root_079") && !roomlist.Contains("Root_079"))
                        {
                            roomlist.Add("Root_079");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 0 7 9 ";
                                else
                                    msgscp += " and 0 7 9 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 0 7 9 ";
                                else
                                    msgscp += " and 0 7 9 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //106
                        if (roomname.Equals("Root_106") && !roomlist.Contains("Root_106"))
                        {
                            roomlist.Add("Root_106");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 1 0 6 ";
                                else
                                    msgscp += " and 1 0 6 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 1 0 6 ";
                                else
                                    msgscp += " and 1 0 6 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //049
                        if (roomname.Equals("Root_049") && !roomlist.Contains("Root_049"))
                        {
                            roomlist.Add("Root_049");
                            if (!hasfound)
                            {
                                if (!scp)
                                    msgscp += " CLASSD NEARBY CONTAINMENT CHAMBER 0 4 9 ";
                                else
                                    msgscp += " and 0 4 9 ";
                                scp = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!scp)
                                    msgscp += " CONTAINMENT CHAMBER 0 4 9 ";
                                else
                                    msgscp += " and 0 4 9 ";
                                scp = true;
                                hasfound = true;
                            }
                        }
                        //MicroHID room
                        if (roomname.Equals("Root_Hid") && !roomlist.Contains("Root_Hid"))
                        {
                            roomlist.Add("Root_Hid");
                            if (!hasfound)
                            {
                                if (!misc)
                                    msgmisc += " CLASSD NEARBY MICRO H I D CHAMBER ";
                                else
                                    msgmisc += " and MICRO H I D CHAMBER ";
                                misc = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!misc)
                                    msgmisc += " MICRO H I D CHAMBER ";
                                else
                                    msgmisc += " and MICRO H I D CHAMBER ";
                                misc = true;
                                hasfound = true;
                            }
                        }
                        //Nuke room
                        if (roomname.Equals("Root_Nuke") && !roomlist.Contains("Root_Nuke"))
                        {
                            roomlist.Add("Root_Nuke");
                            if (!hasfound)
                            {
                                if (!misc)
                                    msgmisc += " CLASSD NEARBY ALPHA WARHEAD ";
                                else
                                    msgmisc += " and ALPHA WARHEAD ";
                                misc = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!misc)
                                    msgmisc += " ALPHA WARHEAD ";
                                else
                                    msgmisc += " and ALPHA WARHEAD ";
                                misc = true;
                                hasfound = true;
                            }
                        }
                        //Server room
                        if (roomname.Equals("Root_Servers") && !roomlist.Contains("Root_Servers"))
                        {
                            roomlist.Add("Root_Servers");
                            if (!hasfound)
                            {
                                if (!misc)
                                    msgmisc += " CLASSD NEARBY DATA CENTER ";
                                else
                                    msgmisc += " and MICRO DATA CENTER ";
                                misc = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!misc)
                                    msgmisc += " DATA CENTER ";
                                else
                                    msgmisc += " and DATA CENTER ";
                                misc = true;
                                hasfound = true;
                            }
                        }
                    }
                    /*else if (dist != float.MaxValue && !hczfound)
                    {
                        msg += " CLASSD IN HEAVY CONTAINMENT ZONE ";
                        hasfound = true;
                        hczfound = true;
                    }*/
                }


                var ezobjs = GameObject.Find("EntranceRooms").transform;
                foreach (var player in players)
                {
                    if (player.TeamRole.Team != Smod2.API.Team.CLASSD) continue;
                    float dist = float.MaxValue;
                    string roomname = string.Empty;
                    for (int i = 0; i < ezobjs.childCount; i++)
                    {
                        Transform room = ezobjs.GetChild(i);
                        Vector3 roompos = new Vector3(room.position.x, room.position.y, room.position.z);

                        if (room.name.StartsWith("Root_GateA"))
                        {
                            //((GameObject)player.GetGameObject()).transform.position;
                            //Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, room.position);

                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_GateA";
                            }
                        }
                        if (room.name.StartsWith("Root_GateB"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_GateB";
                            }
                        }
                        if (room.name.StartsWith("Root_Checkpoint"))
                        {
                            if (Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos) < dist)
                            {
                                dist = Vector3.Distance(((GameObject)player.GetGameObject()).transform.position, roompos);
                                roomname = "Root_Checkpoint";
                            }
                        }
                    }
                    if (dist < mindist)
                    {
                        if (roomname.Equals("Root_GateA") && !roomlist.Contains("Root_GateA"))
                        {
                            roomlist.Add("Root_GateA");
                            if (!hasfound)
                            {
                                if (!gate)
                                    msggate += " CLASSD NEARBY GATE A ";
                                else
                                    msggate += " and A ";
                                gate = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!gate)
                                    msggate += " GATE A ";
                                else
                                    msggate += " and A ";
                                gate = true;
                                hasfound = true;
                            }
                        }
                        if (roomname.Equals("Root_GateB") && !roomlist.Contains("Root_GateB"))
                        {
                            roomlist.Add("Root_GateB");
                            if (!hasfound)
                            {
                                if (!gate)
                                    msggate += " CLASSD NEARBY GATE B ";
                                else
                                    msggate += " and B ";
                                gate = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!gate)
                                    msggate += " GATE B ";
                                else
                                    msggate += " and B ";
                                gate = true;
                                hasfound = true;
                            }
                        }
                        if (roomname.Equals("Root_Checkpoint") && !roomlist.Contains("Root_Checkpoint"))
                        {
                            roomlist.Add("Root_Checkpoint");
                            if (!hasfound)
                            {
                                if (!chkpt)
                                    msgchk += " CLASSD NEARBY ENTRANCE ZONE CHECKPOINT ";
                                else
                                    msgchk += " and ENTRANCE ZONE ";
                                chkpt = true;
                                hasfound = true;
                            }
                            else
                            {
                                if (!chkpt)
                                    msgchk += " ENTRANCE ZONE CHECKPOINT ";
                                else
                                    msgchk += " and ENTRANCE ZONE ";
                                chkpt = true;
                                hasfound = true;
                            }
                        }
                    }
                    /*else if (dist != float.MaxValue && !ezfound)
                    {
                        msg += " CLASSD IN ENTRANCE ZONE ";
                        hasfound = true;
                        ezfound = true;
                    }*/
                }

                if (msgscp + msgchk + msgelev + msggate + msgmisc != string.Empty)
                    msg = "SCAN FOR CLASSD PERSONNEL . " + msgscp + msgchk + msgelev + msggate + msgmisc;
                else
                    msg = "SCAN FOR CLASSD PERSONNEL . NO CLASSD PERSONNEL FOUND . ";

                if (msg != string.Empty)
                {
                    plugin.Server.Map.AnnounceCustomMessage(msg);
                }
            }
        }

    }
}