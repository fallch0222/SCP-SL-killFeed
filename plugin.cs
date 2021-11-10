using Exiled.API.Features;

namespace fallchKillFeed
{

    public class Plugin : Plugin<config>
    {
        private playerHandler PlayerHandler;

        public override void OnEnabled()
        {
            registerEvents();
            Log.Debug("플러그인 활성화");
            base.OnEnabled();

        }

        public void Ondisabled()
        {
            base.OnDisabled();
            UnRegisterEvents();
        }

        public void registerEvents()
        {
            PlayerHandler = new playerHandler();

            Exiled.Events.Handlers.Player.Died += PlayerHandler.deadInfo;
        }

        public void UnRegisterEvents()
        {
            PlayerHandler = new playerHandler();
            Exiled.Events.Handlers.Player.Died -= PlayerHandler.deadInfo;


            PlayerHandler = null;

            //Severity	Code	Description	Project	File	Line	Suppression State
            //Error CS0118  'playerHandler' is a type but is used like a variable   fallchDoorPen D:\fallch SCPSL Plugin Dev\fallchDoorPen\fallchDoorPen\Plugin.cs    39  Active

        }


    }


}