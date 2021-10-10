using System;
using System.Numerics;
using System.Collections.Generic;

namespace Lab1
{
    class V3DataList : V3Data
    {
        public List<DataItem> DataList { get; }
        public V3DataList(string id, DateTime time) : base(id, time)
        {
            DataList = new List<DataItem>(100);
        }
        public bool Add(DataItem newItem)
        {
            foreach (DataItem el in DataList)
            {
                if ((el.x == newItem.x) && (el.y == newItem.y))
                    return false;
            }
            DataList.Add(newItem);
            return true;
        }
        public int AddDefaults(int nItems, FdblVector2 F)
        {
            int result = 0;
            double tmp_x, tmp_y;
            //Vector2 tmp_value = new Vector2(); ??
            Vector2 tmp_value;
            DataItem tmp_item;

            for (int i = 0; i < nItems; i++)
            {
                tmp_x = Count * Math.Cos(2.0 * Math.PI * i / nItems);
                tmp_y = Count * Math.Sin(2.0 * Math.PI * i / nItems);
                tmp_value = F(Convert.ToSingle(tmp_x), Convert.ToSingle(tmp_y));
                tmp_item = new DataItem(tmp_x, tmp_y, tmp_value);
                result += Convert.ToInt32(Add(tmp_item));
            }
            return result;
        }
        public override int Count
        {
            get { return DataList.Count; }
        }
        public override double MaxDistance
        {
            // O(n^2) :(
            get {
                if (Count < 2) return -1.0;
                Vector2 tmpVec2 = new Vector2(Convert.ToSingle(DataList[0].x - DataList[1].x), Convert.ToSingle(DataList[0].y - DataList[1].y));
                double curDistance, maxDistance = tmpVec2.Length();
                for (int i = 0; i < Count - 1; i++)
                {
                    for (int j = i+1; j < Count; j++)
                    {
                        tmpVec2.X = Convert.ToSingle(DataList[i].x - DataList[j].x);
                        tmpVec2.Y = Convert.ToSingle(DataList[i].y - DataList[j].y);
                        curDistance = tmpVec2.Length();
                        if (curDistance > maxDistance) 
                            maxDistance = curDistance;
                    }
                }
                return maxDistance;
            }
        }
        public override string ToString()
        {
            return $"V3DataList: ({base.ToString()})\n" +
                $"Number of elements: {Count}";
        }
        public override string ToLongString(string format)
        {
            string res = ToString() + "\n";
            foreach (DataItem el in DataList)
            {
                res += el.ToLongString(format) + "\n";
            }
            return res;
        }
    }
}
