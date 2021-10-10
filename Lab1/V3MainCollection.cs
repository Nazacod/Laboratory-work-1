using System;
using System.Collections.Generic;

namespace Lab1
{
    class V3MainCollection
    {
        private List<V3Data> mainList = new List<V3Data>();
        public int Count { get { return mainList.Count; } }
        public V3Data this[int index]
        {
            get { return mainList[index]; }
        }
        public bool Contains(string ID)
        {
            foreach (V3Data el in mainList)
            {
                if (el.id == ID)
                    return true;
            }
            return false;
        }
        public bool Add(V3Data v3Data)
        {
            if (!Contains(v3Data.id))
            {
                mainList.Add(v3Data);
                return true;
            }
            else 
                return false;            
        }
        public string ToLongString(string format)
        {
            string str = "";
            int i = 1;
            foreach (V3Data el in mainList)
            {
                str += $"Element {i++}: " + el.ToLongString(format) + "\n";
            }
            return str;
        }
        public override string ToString()
        {
            string str = "";
            int i = 1;
            foreach (V3Data el in mainList)
            {
                str += $"Element {i++}: " + el.ToString() + "\n";
            }
            return str;
        }
    }
}
