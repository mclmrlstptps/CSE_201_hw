using System;

namespace EventPlanning
{
    // Address Details
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {State}, {Country}";
        }
    }

    // Event
    public abstract class Event
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public TimeSpan Time { get; }
        public Address EventAddress { get; }

        protected Event(string title, string description, DateTime date, TimeSpan time, Address address)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
            EventAddress = address;
        }

        public virtual string GetStandardDetails()
        {
            return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {EventAddress}";
        }

        public abstract string GetFullDetails();

        public virtual string GetShortDescription()
        {
            return $"Type: {GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    // Lecture
    public class Lecture : Event
    {
        public string Speaker { get; }
        public int Capacity { get; }

        public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            Speaker = speaker;
            Capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
        }
    }

    // Reception
    public class Reception : Event
    {
        public string RsvpEmail { get; }

        public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            RsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {RsvpEmail}";
        }
    }

    // OutdoorGathering 
    public class OutdoorGathering : Event
    {
        public string WeatherForecast { get; }

        public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            WeatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Salt Lake City", "Utah", "USA");
            Address address2 = new Address("456 Elm St", "Provo", "Utah", "USA");
            Address address3 = new Address("789 Oak St", "Rexburg", "Idaho", "USA");

            Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in technology.", new DateTime(2023, 6, 15), new TimeSpan(14, 0, 0), address1, "Dr. Smith", 100);
            Reception reception = new Reception("Company Gala", "Annual company celebration.", new DateTime(2023, 6, 20), new TimeSpan(19, 0, 0), address2, "rsvp@company.com");
            OutdoorGathering gathering = new OutdoorGathering("Community Picnic", "An outdoor picnic for the community.", new DateTime(2023, 7, 4), new TimeSpan(11, 0, 0), address3, "Sunny with a chance of rain");

            Event[] events = { lecture, reception, gathering };

            foreach (Event ev in events)
            {
                Console.WriteLine("Standard Details:");
                Console.WriteLine(ev.GetStandardDetails());
                Console.WriteLine("\nFull Details:");
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine("\nShort Description:");
                Console.WriteLine(ev.GetShortDescription());
                Console.WriteLine("\n-----------------------------------------\n");
            }
        }
    }
}