using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace SCP106ContainRework
{
    public class Main : Plugin<Config>
    {
        EventHandlers EventHandler;

        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandler = new EventHandlers();
            Server.RoundStarted += EventHandler.RoundStart;
            Player.Dying += EventHandler.SCP106Recontainment;
            Player.InteractingDoor += EventHandler.DoorInteract;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            EventHandler = null;
            Server.RoundStarted -= EventHandler.RoundStart;
            Player.Dying -= EventHandler.SCP106Recontainment;
            Player.InteractingDoor -= EventHandler.DoorInteract;
        }
    }
}
