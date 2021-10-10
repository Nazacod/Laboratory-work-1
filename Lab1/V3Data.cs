using System;

namespace Lab1
{
    abstract class V3Data
    {
        public string id { get; }
        public DateTime time { get; }
        public V3Data(string id, DateTime time)
        {
            this.id = id;
            this.time = time;
        }
        public abstract int Count { get; }
        public abstract double MaxDistance { get; }
        public abstract string ToLongString(string format);
        public override string ToString() { return $"id: {id}, time: {time}"; }
    }
}
