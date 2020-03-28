using Microsoft.Xna.Framework;
using WolfyECS;

namespace WolfyShared.ECS
{
    public class InputComponent : EntityComponent
    {
        public bool ArrowUp { get; set; }
        public bool ArrowDown { get; set; }
        public bool ArrowLeft { get; set; }
        public bool ArrowRight { get; set; }
        public bool LeftShift { get; set; }
    }
}
