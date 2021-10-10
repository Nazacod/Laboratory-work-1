using System;
using System.Numerics;
using System.Collections.Generic;

namespace Lab1
{
    class V3DataArray : V3Data
    {
        public int cntNodesX { get; }
        public int cntNodesY { get; }
        public double stepX { get; }
        public double stepY { get; }
        public Vector2[,] DataArray { get; }
        public V3DataArray(string id, DateTime time) : base(id, time)
        {
            DataArray = new Vector2[,] { };
        }
        public V3DataArray(string id, DateTime time, int cntNodesX, int cntNodesY, double stepX, double stepY, FdblVector2 F) 
            : base(id, time)
        {
            this.cntNodesX = cntNodesX;
            this.cntNodesY = cntNodesY;
            this.stepX = stepX;
            this.stepY = stepY;
            DataArray = new Vector2[this.cntNodesY, this.cntNodesX];
            for (int i = 0; i < this.cntNodesY; i++)
            {
                for (int j = 0; j < this.cntNodesX; j++)
                {
                    DataArray[i, j] = F(0.0 + j * stepX, 0.0 + i * stepY);
                }
            }
        }
        public override int Count
        {
            get { return cntNodesX * cntNodesY; }
        }
        public override double MaxDistance
        {
            get {
                return Math.Sqrt(Math.Pow(stepX * (cntNodesX - 1), 2) + Math.Pow(stepY * (cntNodesY - 1), 2));
            }
        }
        public override string ToString()
        {
            return $"V3DataArray: ({base.ToString()})\n" +
                $"Number of nodes by X: {cntNodesX}, number of nodes by Y: {cntNodesY}\n" + 
                $"Step by x: {stepX}, step by y: {stepY}";
        }
        public override string ToLongString(string format)
        {
            string res = ToString() + "\n";
            double x, y;
            for (int i = 0; i < cntNodesY; i++)
            {
                for (int j = 0; j < cntNodesX; j++)
                {
                    x = 0.0 + j * stepX;
                    y = 0.0 + i * stepY;
                    res += $"В точке ({ x.ToString(format)}, { y.ToString(format)}) модуль переменной равен: { DataArray[i, j].Length().ToString(format)}, " +
                        $"компонента по X равна: {DataArray[i, j].X.ToString(format)}, " +
                        $"компонента по Y равна: {DataArray[i, j].Y.ToString(format)}\n";
                }
            }
            return res;
        }
        public static explicit operator V3DataList(V3DataArray param)
        {
            V3DataList obj = new V3DataList(param.id, param.time);
            for (int i = 0; i < param.cntNodesY; i++)
            {
                for (int j = 0; j < param.cntNodesX; j++)
                {
                    obj.Add(new DataItem(j * param.stepX, i * param.stepY, param.DataArray[i, j]));
                    //Console.WriteLine($"{i}, {j}");
                    //Console.WriteLine(obj.Add(new DataItem(j * param.stepX, i * param.stepY, param.DataArray[i, j])));
                }
            }
            return obj;
        }
    }
}
