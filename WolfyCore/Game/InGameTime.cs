using System;
using ProtoBuf;

namespace WolfyCore.Game
{
    [ProtoContract] public struct InGameTime
    {
        [ProtoMember(1)] public int Day;
        [ProtoMember(2)] public byte Hour;
        [ProtoMember(3)] public byte Minute;

        public InGameTime(int day, byte hour, byte minute)
        {
            Day = day;
            Hour = hour;
            Minute = minute;
        }

        public InGameTime AddMinute()
        {
            if (Minute++ != 60) return this;
            Minute = 0;
            if (Hour++ != 24) return this;
            Hour = 0;
            Day++;

            return this;
        }

        /// <summary>
        /// Returns formatted time as string.
        /// </summary>
        /// <param name="withDay">Determines if Day should be included</param>
        /// <returns></returns>
        public string AsString(bool withDay = true)
        {
            return withDay
                ? string.Concat(Day, ", ", Hour, ":", Minute)
                : string.Concat(Hour, ":", Minute);
        }
    }
}
