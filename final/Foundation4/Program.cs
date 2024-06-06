using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        public DateTime Date { get; }
        public int LengthInMinutes { get; }

        protected Activity(DateTime date, int lengthInMinutes)
        {
            Date = date;
            LengthInMinutes = lengthInMinutes;
        }

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {GetType().Name} ({LengthInMinutes} min) - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
        }
    }

    // Running
    public class Running : Activity
    {
        public double DistanceInKm { get; }

        public Running(DateTime date, int lengthInMinutes, double distanceInKm)
            : base(date, lengthInMinutes)
        {
            DistanceInKm = distanceInKm;
        }

        public override double GetDistance()
        {
            return DistanceInKm;
        }

        public override double GetSpeed()
        {
            return (DistanceInKm / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / DistanceInKm;
        }
    }

    // Cycling
    public class Cycling : Activity
    {
        public double SpeedInKph { get; }

        public Cycling(DateTime date, int lengthInMinutes, double speedInKph)
            : base(date, lengthInMinutes)
        {
            SpeedInKph = speedInKph;
        }

        public override double GetDistance()
        {
            return (SpeedInKph * LengthInMinutes) / 60;
        }

        public override double GetSpeed()
        {
            return SpeedInKph;
        }

        public override double GetPace()
        {
            return 60 / SpeedInKph;
        }
    }

    // Swimming
    public class Swimming : Activity
    {
        public int Laps { get; }

        public Swimming(DateTime date, int lengthInMinutes, int laps)
            : base(date, lengthInMinutes)
        {
            Laps = laps;
        }

        public override double GetDistance()
        {
            return (Laps * 50) / 1000.0; // distance in km
        }

        public override double GetSpeed()
        {
            return (GetDistance() / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2023, 11, 3), 30, 5.0),
                new Cycling(new DateTime(2023, 11, 4), 45, 20.0),
                new Swimming(new DateTime(2023, 11, 5), 30, 20)
            };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}