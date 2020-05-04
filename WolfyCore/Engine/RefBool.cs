using ProtoBuf;

namespace WolfyCore.Engine
{
    [ProtoContract] public class RefBool
    {
        [ProtoMember(1)]
        public bool Value { get; set; }

        public RefBool() { }

        public RefBool(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(RefBool wrapper)
        {
            return !(wrapper is null) && wrapper.Value;
        }

        public static implicit operator RefBool(bool wrapper)
        {
            return new RefBool(wrapper);
        }

        public static bool operator ==(RefBool a, RefBool b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null)
                return !b.Value;
            if (b is null)
                return !a.Value;
            return a.Value == b.Value;
        }

        public static bool operator !=(RefBool a, RefBool b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return !Value;
            
            var t = obj.GetType();
            if (t == typeof(RefBool))
                return Value == ((RefBool)obj).Value;
            
            if (t == typeof(bool))
                return Value == (bool)obj;
            
            return false;
        }

        public override int GetHashCode()
        {
            return Value ? 1 : 0;
        }
    }
}