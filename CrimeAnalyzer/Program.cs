using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CrimeAnalyzer
{
    class Year
    {
        public int year;
        public int population;
        public int violentCrime;
        public int murder;
        public int rape;
        public int robbery;
        public int aggravatedAssault;
        public int propertyCrime;
        public int burglary;
        public int theft;
        public int motorVehicleTheft;

        public Year(int year, int population, int violentCrime, int murder, int rape, int robbery, int aggravatedAssault, int propertyCrime, int burglary, int theft, int motorVehicleTheft)
        {
            this.year = year;
            this.population = population;
            this.violentCrime = violentCrime;
            this.murder = murder;
            this.rape = rape;
            this.robbery = robbery;
            this.aggravatedAssault = aggravatedAssault;
            this.propertyCrime = propertyCrime;
            this.burglary = burglary;
            this.theft = theft;
            this.motorVehicleTheft = motorVehicleTheft;
        }
    }

    class Program

    {
        static void Main(string[] args)

        {
            using (var reader = new StreamReader(@"CrimeData.csv"))

            {
                List<Year> listA = new List<Year>();
                bool isFirst = true;
                while (!reader.EndOfStream)

                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (isFirst)

                    {
                        isFirst = false;
                        continue;
                    }

                    if (isFirst == false)

                    {
                        var stats = new Year(Int32.Parse(values[0]), Int32.Parse(values[1]), Int32.Parse(values[2]), Int32.Parse(values[3]), Int32.Parse(values[4]), Int32.Parse(values[5]), Int32.Parse(values[6]), Int32.Parse(values[7]), Int32.Parse(values[8]), Int32.Parse(values[9]), Int32.Parse(values[10]));


                        listA.Add(stats);
                    }

                }

                foreach (var item in listA)

                {

                }

                //#1

                var firstyear = listA.First<Year>().year;
                var lastyear = listA.Last<Year>().year;
                int range = lastyear - firstyear;
                Console.WriteLine("Period: 1994–2013: " + (range + 1) + " years.");

                //#2

                var murders = from crimeStats in listA where crimeStats.murder < 15000 select crimeStats.year;
                List<string> question2 = new List<string>();
                foreach (var murderyears in murders)

                {
                    question2.Add(Convert.ToString(murderyears));
                }

                Console.WriteLine("Years murders per year < 15000: " + question2[0] + "," + question2[1] + "," + question2[2] + "," + question2[3]);

                //#3

                var robberieOfYears = from crimeStats in listA where crimeStats.robbery > 500000 select crimeStats.year;
                List<string> question3 = new List<string>();
                foreach (var greaterYears in robberieOfYears)

                {

                    question3.Add(Convert.ToString(greaterYears));
                }

                var robbery = from crimeStats in listA where crimeStats.robbery > 500000 select crimeStats.robbery;
                List<string> rob = new List<string>();
                foreach (var murderAmount in robbery)

                {

                    rob.Add(Convert.ToString(murderAmount));
                }

                Console.WriteLine("Robberies per year > 500000: " + question3[0] + " = " + rob[0] + "," + question3[1] + " = " + rob[1] + ", " + question3[2] + " = " + rob[2]);

                //#4

                string population = null;

                var capita = from crimeStats in listA where crimeStats.year == 2010 select crimeStats.population;
                foreach (var pop in capita)

                {
                    population = Convert.ToString(pop);
                }

                string violentC = null;
                var crimeInYear = from crimeStats in listA where crimeStats.year == 2010 select crimeStats.violentCrime;
                foreach (var violentCrime in crimeInYear)

                {
                    violentC = Convert.ToString(violentCrime);
                }
                double crimePerCapita = double.Parse(violentC) / double.Parse(population);

                Console.WriteLine("Violent crime per capita rate (2010): " + crimePerCapita);

                //#5

                int firstCount = 0;
                double firstTotalMurder = 0;
                var murderAverage = from crimeStats in listA select crimeStats.murder;
                foreach (var murder in murderAverage)

                {
                    firstTotalMurder += murder;
                    firstCount++;
                }

                double firstMurderAverage = firstTotalMurder / firstCount;

                Console.WriteLine("Average murder per year (all years): " + firstMurderAverage);

                //#6 & #7

                int secondCount = 0;
                double secondTotalMurder = 0;
                var secondAverageMurders = from crimeStats in listA where crimeStats.year > 1993 && crimeStats.year < 1998 select crimeStats.murder;
                foreach (var secondMurder in secondAverageMurders)

                {
                    secondTotalMurder += secondMurder;
                    secondCount++;
                }

                double secondMurderAverage = secondTotalMurder / secondCount;

                int thirdcount = 0;
                double thirdTotalMurder = 0;
                var thirdAverageMurders = from crimeStats in listA where crimeStats.year > 2009 && crimeStats.year < 2015 select crimeStats.murder;
                foreach (var thirdMurder in thirdAverageMurders)

                {
                    thirdTotalMurder += thirdMurder;
                    thirdcount++;
                }

                double thirdMurderAverage = thirdTotalMurder / thirdcount;

                Console.WriteLine("Average murder per year (1994–1997): " + secondMurderAverage);

                Console.WriteLine("Average murder per year (2010–2014): " + thirdMurderAverage);

                //#8

                double minTheftAmount = 0;
                var minThefts = from crimeStats in listA where crimeStats.year > 1998 && crimeStats.year < 2005 select crimeStats.theft;
                foreach (var minTheft in minThefts)

                {

                    if (minTheftAmount == 0)

                    {
                        minTheftAmount = minTheft;
                    }

                    else if (minTheft < minTheftAmount)

                    {
                        minTheftAmount = minTheft;
                    }



                   
                }
                Console.WriteLine("Minimum thefts per year (1999–2004): " + minTheftAmount);
                //#9

                double maxTheftAmount = 0;
                var maxThefts = from crimeStats in listA where crimeStats.year > 1998 && crimeStats.year < 2005 select crimeStats.theft;
                foreach (var maxTheft in maxThefts)

                {
                    if (maxTheftAmount == 0)

                    {
                        maxTheftAmount = maxTheft;
                    }

                    else if (maxTheft > maxTheftAmount)

                    {
                        maxTheftAmount = maxTheft;
                    }

                }

                Console.WriteLine("Maximum thefts per year (1999–2004): " + maxTheftAmount);

                //#10

                int mostMVT = 0;
                var highestMVT = from crimeStats in listA select crimeStats.motorVehicleTheft;
                foreach (var theft in highestMVT)

                {
                    if (mostMVT == 0)

                    {
                        mostMVT = theft;
                    }

                    else if (theft > mostMVT)

                    {
                        mostMVT = theft;
                    }

                }

                int mvtYear = 0;
                var highestMvtYear = from crimeStats in listA where crimeStats.motorVehicleTheft == mostMVT select crimeStats.year;
                foreach (var year in highestMvtYear)

                {
                    mvtYear = year;
                }

                Console.WriteLine("Year of highest number of motor vehicle thefts: " + mvtYear);

            }
        }
    }
}
