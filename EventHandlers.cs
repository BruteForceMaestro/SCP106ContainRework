using Exiled.API.Features;
using MEC;
using Exiled.API.Enums;
using Exiled.Events.EventArgs;
using System;

namespace SCP106ContainRework
{
    class EventHandlers
    {
        Config config = new Config();
        public bool called_method = false;
        Random random = new Random();
        public void RoundStart()
        {
            foreach (Door door in Map.Doors)
            {
                if (door.Type == DoorType.Scp106Primary || door.Type == DoorType.Scp106Secondary || door.Type == DoorType.Scp106Bottom)
                {
                    Door work = door;
                    float wait_time_sec = config.SCP106DoorOpenMinutes * 60f;
                    void showMethod() => onDelay(ref work);
                    Timing.CallDelayed(wait_time_sec, showMethod);

                }
            }
        }


        public void SCP106Recontainment(DyingEventArgs ev)
        {
            if (ev.Target.Role == RoleType.Scp106 && ev.HitInformation.Tool == DamageTypes.Recontainment)
            {
                if (random.Next(100) <= config.RecontainmentChance) {
                    Log.Info("SCP 106 Recontainment Failure");
                    ev.IsAllowed = false;
                    Cassie.Message("Attention all personnel . SCP 1 0 6 Recontainment Protocol Failure Detected");
                }
            }
        }

        public void DoorInteract(InteractingDoorEventArgs ev)
        {
            if (ev.Door.Type == DoorType.Scp106Primary || ev.Door.Type == DoorType.Scp106Secondary || ev.Door.Type == DoorType.Scp106Bottom && ev.Door.DoorLockType == DoorLockType.None)
            {
                if (!called_method)
                {
                    ev.Player.ShowHint("SCP-106's chamber isn't ready for the initiation\nof the recall protocol.");
                    ev.IsAllowed = false;
                }
            }
        }

        public void onDelay(ref Door door)
        {
            if (!called_method)
            {
                Cassie.Message("SCP 1 0 6 ready for recontainment protocol");
                called_method = true;
                
            }
            door.DoorLockType = DoorLockType.None;
        }

    }
}
