

//3.BikeRaceTrack
//        { Distance: int }
//-bool IsGt(BikeRaceTrack other)
//    TestBikeRaceTrack



using BikeRaceTrackProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRaceTrackProject
{

    class BikeRaceTrack
    {
        public int Distance { get; set; }

        public BikeRaceTrack(int _distance)
        {
            this.Distance = _distance;
        }

        public bool IsTrackGt(BikeRaceTrack other)
        {
            return this.Distance > other.Distance;
        }

        public bool IsTrackEqual(BikeRaceTrack other)
        {
            return this.Distance == other.Distance;
        }

        public override string ToString()
        {
            return $"[Distance={this.Distance}]";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BikeRaceTrack firstTrack = new BikeRaceTrack(20);
            BikeRaceTrack secondTrack = new BikeRaceTrack(500);
            if (firstTrack.IsTrackGt(secondTrack))
            {
                Console.WriteLine($"First track {firstTrack} is greater than Second  track {secondTrack}");
            }
            else if (firstTrack.IsTrackEqual(secondTrack))
            {
                Console.WriteLine($"First  track {firstTrack} equals Second track {secondTrack}");
            }
            else
            {
                Console.WriteLine($"First track {firstTrack} is less than Second track {secondTrack}");
            }
            Console.ReadKey();

        }
    }
}

//op:First track [Distance=20] is less than Second track [Distance=500]
