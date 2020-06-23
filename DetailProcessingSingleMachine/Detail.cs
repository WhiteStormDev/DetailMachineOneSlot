using System;

namespace DetailProcessingSingleMachine
{
    public class Detail
    {
        private static int _currentIndex;

        public int Fine { get; private set; }
        public int ProcessingTime { get; private set; }

        public int Index { get; private set; }
        public float FineRatio { get; private set; }
        
        public Detail(int minTime, int maxTime, int minFine, int maxFine)
        {
            Index = _currentIndex++;
            
            var rnd = new Random();
            ProcessingTime = rnd.Next(minTime, maxTime);
            Fine = rnd.Next(minFine, maxFine);
            CalculateFine();
        }
        
        public Detail(int processingTime, int fine)
        {
            Index = _currentIndex++;
            
            ProcessingTime = processingTime;
            Fine = fine;
            CalculateFine();
        }

        private void CalculateFine() => FineRatio = (float) Fine / ProcessingTime;
    }
}