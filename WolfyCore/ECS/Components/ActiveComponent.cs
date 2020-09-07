using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Only entities with <see cref="ActiveComponent"/>
    /// are being updated in systems.
    /// </summary>
    [ProtoContract] public class ActiveComponent : EntityComponent
    {

    }
}
