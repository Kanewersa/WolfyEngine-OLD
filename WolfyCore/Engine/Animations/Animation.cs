using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyCore.Engine
{
    [ProtoContract] public class Animation
    {
        [ProtoMember(1)] public int CurrentFrame { get; set; }
        [ProtoMember(2)] public int FrameCount { get; private set; }
        
        [ProtoMember(3)] public int CurrentDirection { get; set; }
        [ProtoMember(4)] public int DirectionsCount { get; private set; }
        
        [ProtoIgnore] public int FrameHeight => Texture.Height / DirectionsCount;
        [ProtoIgnore] public int FrameWidth => Texture.Width / FrameCount;

        [ProtoMember(5)] public float FrameSpeed { get; set; }

        [ProtoMember(6)] public bool IsLooping { get; set; }

        [ProtoMember(7)] public Image Image { get; set; }

        [ProtoIgnore] public Texture2D Texture => Image.Texture;

        public Animation() { }

        public Animation(string texture, int frameCount, int directionsCount)
        {
            Image = new Image(texture);
            CurrentDirection = 0;
            FrameCount = frameCount;
            DirectionsCount = directionsCount;

            IsLooping = true;
            FrameSpeed = .5f;
        }

        public void LoadContent(ContentManager content)
        {
            Console.WriteLine("Loading content...");
            Image.LoadContent(content);
        }
        
    }
}
