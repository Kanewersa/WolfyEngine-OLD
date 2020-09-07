using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class DialogComponent : EntityComponent
    {
        [ProtoMember(1)] public string NpcName;
        [ProtoMember(2)] public string Content;
        [ProtoIgnore] public bool Displayed;

        public DialogComponent() { }

        public DialogComponent(string npcName, string content)
        {
            NpcName = npcName;
            Content = content;
        }
    }
}
