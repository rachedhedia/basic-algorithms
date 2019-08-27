using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace implementations
{
    public class Sort
    {
        public static IEnumerable<int> InsertionSort(IEnumerable<int> values)
        {
            var entries = values.ToList();
            var sortedEntries = new List<int>();

            for (var i = 0; i < entries.Count; ++i)
            {
                if (!sortedEntries.Any())
                {
                    sortedEntries.Add(entries[i]);
                }
                else
                {
                    var index = 0;
                    while (index < sortedEntries.Count && sortedEntries[index] < entries[i])
                    {
                        ++index;
                    }
                    
                    sortedEntries.Insert(index, entries[i]);
                }
            }

            return sortedEntries;
        }
        
        public static IEnumerable<int> SelectionSort(IEnumerable<int> values)
        {
            var entries = values.ToList();

            for (var i = 0; i < entries.Count; ++i)
            {
                var minValueIndex = i;
                for (var j = i; j < entries.Count; ++j)
                {
                    if (entries[j] < entries[minValueIndex])
                        minValueIndex = j;
                }

                var backup = entries[i];
                entries[i] = entries[minValueIndex];
                entries[minValueIndex] = backup;
            }

            return entries;
        }

        public static IEnumerable<int> BubbleSort(IEnumerable<int> values)
        {
            var entries = values.ToList();
            bool? swapped = null;

            while (!swapped.HasValue || swapped.Value)
            {
                swapped = false;
                
                for (var i = 0; i < entries.Count - 1; ++i)
                {
                    if (entries[i] > entries[i + 1])
                    {
                        var backup = entries[i];
                        entries[i] = entries[i + 1];
                        entries[i + 1] = backup;
                        swapped = true;
                    }
                }
            }

            return entries;
        }

        public static IEnumerable<int> HeapSort(IEnumerable<int> values)
        {
            var heap = new Heap(Heap.HeapType.Min);
            foreach(var value in values)
                heap.Insert(value);
            var sortedEntries = new List<int>();

            var minValue = heap.ExtractDominant();

            while (minValue.HasValue)
            {
                sortedEntries.Add(minValue.Value);
                minValue = heap.ExtractDominant();
            }

            return sortedEntries;
        }

        public static IEnumerable<int> MergeSort(IEnumerable<int> values)
        {
            if (values.Count() == 1)
                return values;

            List<int> mergedLeft = null;
            List<int> mergedRight = null;
            List<int> mergedValues = new List<int>();
            
            if (values.Count() % 2 == 0)
            {
                mergedLeft = MergeSort(values.Take(values.Count() / 2)).ToList();
                mergedRight = MergeSort(values.Skip(values.Count() / 2)).ToList();
            }
            else
            {
                mergedLeft = MergeSort(values.Take((values.Count() / 2) + 1)).ToList();
                mergedRight = MergeSort(values.Skip((values.Count() / 2) + 1)).ToList();
            }

            while (mergedLeft.Any() || mergedRight.Any())
            {
                if (mergedLeft.Any() && mergedRight.Any())
                {
                    if (mergedLeft[0] < mergedRight[0])
                    {
                        mergedValues.Add(mergedLeft[0]);
                        mergedLeft = mergedLeft.Skip(1).ToList();
                    }
                    else
                    {
                        mergedValues.Add(mergedRight[0]);
                        mergedRight = mergedRight.Skip(1).ToList();
                    }
                }
                else if (mergedLeft.Any())
                {
                    mergedValues.AddRange(mergedLeft);
                    mergedLeft.Clear();
                }
                else
                {
                    mergedValues.AddRange(mergedRight);
                    mergedRight.Clear();
                }
            }

            return mergedValues;
        }

        public static IEnumerable<int> QuickSort(IEnumerable<int> values)
        {
            if (!values.Any())
                return Enumerable.Empty<int>();
            
            var entries = values.ToList();

            var pivotValue = entries.Last();
            var firstHigh = 0;

            for (var i = 0; i < entries.Count - 1; ++i)
            {
                if (entries[i] < pivotValue)
                {
                    var backupValue = entries[i];
                    entries[i] = entries[firstHigh];
                    entries[firstHigh] = backupValue;
                    firstHigh++;
                }
            }

            return QuickSort(entries.Take(firstHigh)).
                Concat(new []{pivotValue}).
                Concat(QuickSort(entries.Skip(firstHigh).Take(entries.Count() - firstHigh - 1)));
            
        }
    }
}