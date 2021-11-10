namespace fallchKillFeed
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    public sealed class config : IConfig
    {
        [Description("Indicates whether tje plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;



    }
}