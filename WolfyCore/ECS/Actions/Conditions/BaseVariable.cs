using ProtoBuf;
using WolfyCore.Actions;

namespace WolfyCore.ECS
{
    /// <summary>
    /// The base for all variables used in <see cref="Actions.WolfyAction"/>.
    /// </summary>
    [ProtoInclude(20, typeof(WolfyBool))]
    [ProtoInclude(21, typeof(WolfyVariable))]
    [ProtoContract]
    public class BaseVariable
    {
        [ProtoMember(100)] public uint Id { get; set; }
        [ProtoMember(101)] public string Name { get; set; }


        public string FormattedName()
        {
            return Id + ": " + Name;
        }
    }
}
