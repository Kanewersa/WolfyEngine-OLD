using WolfyECS;

namespace WolfyCore.ECS
{
    public struct Entities
    {
        public static Entity Empty => new Entity(0);
        public static Entity Player => new Entity(1);
        public static Entity LUTTime => new Entity(2);
    }
}
