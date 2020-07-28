using ProtoBuf;

namespace WolfyCore.Engine
{
    [ProtoContract] public class RefFloat
    {
        [ProtoMember(1)]
        public float Value { get; set; }

        public RefFloat() { }

        public RefFloat(float value)
        {
            Value = value;
        }

        public static implicit operator float(RefFloat wrapper)
        {
            if (wrapper is null)
                return 0;
            return wrapper.Value;
        }

        public static implicit operator RefFloat(float wrapper)
        {
            return new RefFloat(wrapper);
        }

        public static bool operator ==(RefFloat a, RefFloat b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null)
                return false;
            if (b is null)
                return false;

            return a.Value == b.Value;
        }

        public static bool operator !=(RefFloat a, RefFloat b)
        {
            return !(a == b);
        }

        public static bool operator >(RefFloat a, RefFloat b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(RefFloat a, RefFloat b)
        {
            return a.Value < b.Value;
        }

        protected bool Equals(RefFloat other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RefFloat)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
