using System;
using System.Collections.Generic;

namespace Lab3.SortingAlgorithms
{
    public interface ISortable<T> where T : IComparable<T>
    {
        void Sort(ref List<T> items);
    }

    public interface ISortableInt
    {
        int[] Sort(int[] array);
    }
    public interface ISortableDouble
    {
        double[] Sort(double[] array);
    }
}
