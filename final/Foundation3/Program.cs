using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("100 University Blvd", "Rexburg", "ID", "USA");
        Lecture lecture = new Lecture(
            "Tech Innovations 2026",
            "A lecture about the future of technology.",
            "April 15, 2026",
            "6:00 PM",
            lectureAddress,
            "Dr. Sarah Johnson",
            150
        );

        Address receptionAddress = new Address("250 Grand Hall", "Salt Lake City", "UT", "USA");
        Reception reception = new Reception(
            "Networking Night",
            "An evening for professionals to connect and network.",
            "May 3, 2026",
            "7:30 PM",
            receptionAddress,
            "rsvp@networkingnight.com"
        );

        Address outdoorAddress = new Address("500 Central Park", "Denver", "CO", "USA");
        OutdoorGathering outdoor = new OutdoorGathering(
            "Summer Community Picnic",
            "A fun outdoor gathering for families and friends.",
            "June 20, 2026",
            "1:00 PM",
            outdoorAddress,
            "Sunny with light breeze"
        );

        List<Event> events = new List<Event>();
        events.Add(lecture);
        events.Add(reception);
        events.Add(outdoor);

        foreach (Event ev in events)
        {
            Console.WriteLine("STANDARD DETAILS");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("FULL DETAILS");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("SHORT DESCRIPTION");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine("--------------------------------------------------");
        }
    }
}