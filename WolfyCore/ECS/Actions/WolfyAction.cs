using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.Actions
{
    /// <summary>
    /// Action performed on certain entity.
    /// </summary>
    [ProtoContract] public abstract class WolfyAction
    {
        /// <summary>
        /// The target entity on which action should be executed.
        /// </summary>
        [ProtoMember(501)] public Entity Target;

        /// <summary>
        /// Determines if action should wait for another action to complete before its execution.
        /// </summary>
        [ProtoMember(502)] public bool Asynchronous;

        /// <summary>
        /// Determines if action was completed.
        /// </summary>
        [ProtoMember(503)] public bool Completed;

        /// <summary>
        /// Executes the action.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Checks if action is completed.
        /// </summary>
        public abstract void Validate(GameTime gameTime);

        /// <summary>
        /// Gets the description of <see cref="WolfyAction"/> based on type and parameters.
        /// </summary>
        /// <returns></returns>
        public abstract string GetDescription();

        /// <summary>
        /// Completes the action.
        /// </summary>
        public void Complete()
        {
            Completed = true;
        }
    }
}
