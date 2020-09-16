using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    [ProtoContract]
    [ProtoInclude(100, typeof(TileLayer))]
    [ProtoInclude(101, typeof(EntityLayer))]
    public abstract class BaseLayer
    {
        /// <summary>
        /// Name of the layer.
        /// </summary>
        [ProtoMember(1)] public string Name { get; set; }

        /// <summary>
        /// Size of the layer.
        /// </summary>
        [ProtoMember(2)] public Vector2D Size { get; set; }

        /// <summary>
        /// Draw order of the layer.
        /// </summary>
        [ProtoMember(3)] public int Order { get; set; }

        /// <summary>
        /// TileSize of the game.
        /// </summary>
        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;

        /// <summary>
        /// Initializes the layer.
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Initialize(GraphicsDevice graphics)
        { }

        /// <summary>
        /// Loads content of the layer.
        /// </summary>
        /// <param name="content"></param>
        public virtual void LoadContent(ContentManager content)
        { }

        /// <summary>
        /// Draws the layer.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        /// <param name="visibleArea"></param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        { }

        /// <summary>
        /// Disposes the layer.
        /// </summary>
        public virtual void Unload()
        { }

        /// <summary>
        /// Updates the content of the layer.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        { }

        /// <summary>
        /// Checks if tile at given position is occupied.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public abstract bool? TileOccupied(Vector2 position);

    }
}
