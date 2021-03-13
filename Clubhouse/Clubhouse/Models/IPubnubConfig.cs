using System;

namespace ClubhouseDotNet
{
    public interface IPubnubConfig
    {
        string PubnubToken { get; }
        string PubnubOrigin { get; }
        int PubnubHeartbeatValue { get; }
        int PubnubHeartbeatInterval { get; }
    }
}