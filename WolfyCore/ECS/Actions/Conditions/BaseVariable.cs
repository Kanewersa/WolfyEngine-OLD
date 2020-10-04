using ProtoBuf;

namespace WolfyCore.ECS
{
    /// <summary>
    /// The base for all variables used in <see cref="Actions.WolfyAction"/>.
    /// </summary>
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
