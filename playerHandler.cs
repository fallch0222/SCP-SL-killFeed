using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.Collections.Generic;



namespace fallchKillFeed
{
    internal sealed class playerHandler
    {
        public List<string> playersWithKills = new List<string>();
        public List<int> playerKillNumber = new List<int>();

        public void deadInfo(DiedEventArgs ev)
        {





           
            // =>
            //ev.Killer.Broadcast(7,@$"<align=center><size=5>{ev2.Player.Nickname} was killed by You with {ev3.Shooter.CurrentItem.Type}");
            // =>

            /*align=center 기본적으로 브로드캐스트는 중앙 정렬이라 안써도 되요 아 브로드캐스트로는 거기까지 안가져요 많이 해도 4줄정도...
                가능한게 있긴 있어요 Hint
                위치를 \n으로 조금 조절하셔야 원하는 위치에 있을꺼에요
                End.
            */
            //ev.Killer.Broadcast(7, $"<size=25>{ev.Target.Nickname} was killed by You with {ev.HitInformations.Tool.Weapon}</size>");



            if (ev.HitInformations.IsPlayer == false)
            {
                foreach (var player in Exiled.API.Features.Player.List)
                {

                    if (player.Role == RoleType.Spectator)
                    {


                        Map.ShowHint($"<align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {ev.HitInformations.Tool.Name} <color=blue>{ev.Target.Nickname}</color></size></align>", 5);
                    }
                }
                Log.Debug($"{ev.Target.Nickname} has killed by {ev.Killer.Nickname}");
                return;
            }

            var weapon = ev.HitInformations.Tool.Weapon;
            string weaponString = "none";
            switch (weapon)
            {
                case ItemType.GunAK:
                    weaponString = "AK";
                    break;

                case ItemType.GunCOM15:
                    weaponString = "COM15";
                    break;

                case ItemType.GunCOM18:
                    weaponString = "COM18";
                    break;

                case ItemType.GunCrossvec:
                    weaponString = "CrossVector";
                    break;

                case ItemType.GunE11SR:
                    weaponString = "Epsilon 11 Sniper Rifle";
                    break;

                case ItemType.GunFSP9:
                    weaponString = "MP7";
                    break;

                case ItemType.GunLogicer:
                    weaponString = "Logicer HMG";
                    break;

                case ItemType.GunRevolver:
                    weaponString = "Revolver";
                    break;

                case ItemType.GunShotgun:
                    weaponString = "Shotgun Rifle";
                    break;

                case ItemType.GrenadeHE:
                    weaponString = "HE Grenade";
                    break;

                case ItemType.MicroHID:
                    weaponString = "Micro H.I.D";
                    break;


                    






            }


            if (ev.Target.Team == ev.Killer.Team)
            {
                ev.Killer.ShowHint($"<size=30>{ev.Target.Nickname} was <color=red>killed</color> by you with {weaponString}</size><\n><size=50><color=blue>Don't kill your team mate!</color></size><align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {weaponString} <color=blue>{ev.Target.Nickname}</color></size></align>", 7);
                foreach (var player in Exiled.API.Features.Player.List)
                {

                    if (player.Role == RoleType.Spectator)
                    {

                        Map.ShowHint($"<align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {weaponString} <color=blue>{ev.Target.Nickname}</color></size></align>", 5);
                       
                    }
                }


                Map.ShowHint($"<align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {weaponString} <color=blue>{ev.Target.Nickname}</color></size></align>", 5);
                Log.Debug($"{ev.Target.Nickname} has killed by {ev.Killer.Nickname}");
                return;
            }

            
                
            

            
                



            string killer = ev.Killer.Nickname;
            if (!playersWithKills.Contains(killer))
            {
                playersWithKills.Add(killer);
                playerKillNumber.Add(0);
            }
            playerKillNumber[playersWithKills.IndexOf(killer)] += 1;
            
            if (ev.Killer.IsScp == true)
            {
                ev.Killer.ShowHint($"<size=30>{ev.Target.Nickname} was <color=red>killed</color> by you with {weaponString}</size>\n<size=50><color=red>{playerKillNumber[playersWithKills.IndexOf(killer)].ToString()}kill</color></size><align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {ev.HitInformations.Tool.Scp} <color=red>{ev.Target.Nickname}</color></size></align>", 7);

                foreach (var player in Exiled.API.Features.Player.List)
                {

                    if (player.Role == RoleType.Spectator)
                    {
                        Map.ShowHint($"<align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {ev.HitInformations.Tool.Scp} <color=red>{ev.Target.Nickname}</color></size></align>", 5);
                       

                    }
                }

                
                Log.Debug($"{ev.Target.Nickname} has killed by {ev.Killer.Nickname}");
                return;
            }

            else
            {
                
                ev.Killer.ShowHint($"<size=30>{ev.Target.Nickname} was <color=red>killed</color> by you with {weaponString}</size>\n<size=50><color=red>{playerKillNumber[playersWithKills.IndexOf(killer)].ToString()}kill</color></size><align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {weaponString} <color=red>{ev.Target.Nickname}</color></size></align>", 7);

                foreach (var player in Exiled.API.Features.Player.List)
                {    if (player.Role == RoleType.Spectator)
                    
                        {

                            Map.ShowHint($"<align=right><size=25><color=blue>{ev.Killer.Nickname}</color> {weaponString} <color=red>{ev.Target.Nickname}</color></size></align>", 5);


                        }
                }



                
                Log.Debug($"{ev.Target.Nickname} has killed by {ev.Killer.Nickname}");
                return;
            }



           





            
            
        }



    }

       






    
}