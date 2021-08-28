using Exiled.API.Interfaces;

namespace SCP106ContainRework
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int RecontainmentChance { get; set; } = 25;

        public int SCP106DoorOpenMinutes { get; set; } = 15;
    }
}
