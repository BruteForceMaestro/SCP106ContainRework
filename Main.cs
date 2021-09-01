using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using System;

namespace SCP106ContainRework
{
    public class Main : Plugin<Config>
    {
        EventHandlers EventHandler;

        public override Version Version => new Version(1, 0, 1);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public override void OnEnabled()
        {
            
            EventHandler = new EventHandlers();
            Server.RoundStarted += EventHandler.RoundStart;
            Player.Dying += EventHandler.SCP106Recontainment;
            Player.InteractingDoor += EventHandler.DoorInteract;
            base.OnEnabled();

        }

        public override void OnDisabled()
        {
            
            EventHandler = null;
            Server.RoundStarted -= EventHandler.RoundStart;
            Player.Dying -= EventHandler.SCP106Recontainment;
            Player.InteractingDoor -= EventHandler.DoorInteract;
            base.OnDisabled();

        }
    }
}
