using System;

namespace Rocket
{

    class Rocket
    {
        public RocketHeader Header { get; set; }
        public IEngine Engine { get; set; }

        public int Weight 
        {
            get 
            {
                return Header.GetWeight() + Engine.Weight;
            }
        }
    }

    class RocketHeader
    {
        public int Cosmonauts { get; private set; }
        public int MassShell { get; private set; }

        public RocketHeader()
        {
            Cosmonauts = 3;
            MassShell = 5000;
        }
        public int GetWeight()
        {
            return (Cosmonauts * 80) + MassShell;
        }
        public void SendMassage(string Massage)
        {
            Console.WriteLine($"Massage: {Massage} has been delivered!");
        }
    }

    public interface IEngine
    {
        int Weight { get; set; }
        int Power { get; set; }
        void Start();
        void Stop();    
    }

    class RevoEngine : IEngine
    {
        public int Weight { get; set; }
        public int Power { get; set; }

        public RevoEngine() 
        {
            Weight = 322;
            Power = 228;
        }
  
        public void Start()
        {
            Console.WriteLine("Sound of opening bottle*");
        }

        public void Stop()
        {
            Console.WriteLine("Sound of throwing a bottle to the trash*");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rocket = new Rocket();

            rocket.Header = new RocketHeader();
            rocket.Engine = new RevoEngine();

            int result = NasaOperatingMethod(rocket.Engine.Power, rocket.Weight);
            Console.WriteLine("Let`s go boiz!");
            Console.WriteLine($"We r haveing {result} speed!");
            if (result > 200)
            {
                Console.WriteLine("We r close to the Andromeda!");
            }
            else
            {
                Console.WriteLine("Revo does not work well!");
            }

        }
        public static int NasaOperatingMethod(int power, int mass) 
        {
            return (mass / power * 10) + 82;
        }
    }
}
