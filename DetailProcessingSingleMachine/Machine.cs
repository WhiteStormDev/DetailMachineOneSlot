using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DetailProcessingSingleMachine
{
    public class Machine
    {
        private List<Detail> _details;

        public Machine(List<Detail> details)
        {
            _details = details;
        }
        
        public void SortDetails()
        {
            _details.Sort((a, b) => b.FineRatio.CompareTo(a.FineRatio));
        }

        public void PrintDetails()
        {
            Console.WriteLine("[ index | fineRatio | fineValue | processingTime ]");
            _details.ForEach(d => Console.WriteLine("[ " + d.Index + " | " + d.FineRatio + " | " + d.Fine + " | " + d.ProcessingTime + " ]"));
            Console.WriteLine("Summary Fine: " + SumFine());
        }

        private int DetailWaitTime(int detailIndex)
        {
            var sum = 0;
            for (int i = 0; i < detailIndex; i++)
            {
                sum += _details[i].ProcessingTime;
            }

            return sum;
        }

        private int DetailWaitFine(int detailIndex) => DetailWaitTime(detailIndex) * _details[detailIndex].Fine;

        private int SumFine()
        {
            var sumFine = 0;
            for (int i = 0; i < _details.Count; i++)
            {
                sumFine += DetailWaitFine(i);
            }

            return sumFine;
        }
    }
}