using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Test 1");
            FdblVector2 f = FdblVector2Types.f2;
            V3DataArray array = new V3DataArray("Velocity", DateTime.Now, 3, 4, 1.0f, 1.0f, f);
            Console.WriteLine(array.ToLongString("N1"));
            V3DataList arrayConverted = (V3DataList) array;
            Console.WriteLine(arrayConverted.ToLongString("N1"));
            Console.WriteLine($"Array: Count - {array.Count}, MaxDistance - {array.MaxDistance:N2}");
            Console.WriteLine($"List: Count - {arrayConverted.Count}, MaxDistance - {arrayConverted.MaxDistance:N2}\n");

            //2
            Console.WriteLine("Test 2");
            f = FdblVector2Types.f3;
            V3MainCollection mainCollection = new V3MainCollection();
            V3DataArray array1 = new V3DataArray("Electricity", DateTime.Now, 2, 2, 1.0f, 1.0f, f);
            V3DataList array2 = new V3DataList("Density", DateTime.MinValue);
            array2.Add(new DataItem(0.0f, 1.2f, f(0.0f, 1.2f)));
            array2.Add(new DataItem(2.0f, 3.2f, f(2.0f, 3.2f)));
            array2.Add(new DataItem(2.5f, 3.7f, f(2.5f, 3.7f)));
            mainCollection.Add(array);
            mainCollection.Add(array1);
            mainCollection.Add(array2);
            mainCollection.Add(arrayConverted);
            Console.WriteLine(mainCollection.ToLongString("N2"));

            //3
            Console.WriteLine("Test 3");
            for (int i = 0; i < mainCollection.Count; i++)
            {
                Console.WriteLine($"Element {i}: Count - {mainCollection[i].Count}, MaxDistance - {mainCollection[i].MaxDistance}");
            }
        }
    }
}
