using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTicker
{
    class StockTicker
    {
        List<Stock> Stocks = new List<Stock>();

        public StockTicker()
        { 
        }

        public void parseStockInformation(string stockInfo)
        {
            //create list for multiple stockInfos being passed in
            var CollectionOfStockInfo = new List<string>();

            //check if it is more than one stock being added
            if (stockInfo.Contains(';'))
            {
                CollectionOfStockInfo = stockInfo.Split(';').ToList();  //split the stock info by ';'
            }

            else
            {
                CollectionOfStockInfo.Add(stockInfo);                   //if only on stocks information is being added, just add it to the list
            }

            assignVariables(CollectionOfStockInfo);
        }

        public string printStockInformation(string stockSymbolIn)
        {
            foreach (Stock s in Stocks)
            {
                if (s.StockSymbol == stockSymbolIn)
                {
                    return $"{s.StockSymbol}, {s.StockName}, {s.Timestamp}, {s.StockValue}";
                }
            }

            return "Stock not found";
        }

        public void printStockInformationList(List<Stock> list)
        {
            int i = 1;
            foreach (Stock s in list)
            {
                Console.WriteLine($"Point {i}: {s.StockSymbol}, {s.StockName}, [{s.Timestamp}], {s.StockValue}");
                i++;
            }
        }

        //this needs to check for dateTime - get end of day and beggining of day
        //not entirely sure how to extract this
        public void printStockSummary(string stockSymbolIn)
        {
            List<Stock> instances = new List<Stock>();
            //get instances of searched stock into temp list
            getInstances(stockSymbolIn, instances);

            Stock min, max;
            findMaxMin(instances, out min, out max);

            string format = "{0:+0.0##;-0.0##;0.0}";                            //formatting strings to include '+' and '-'

            Console.WriteLine($"Stock: {max.StockName} ({max.StockSymbol})");
            Console.WriteLine($"Current Value: {max.StockValue}");
            Console.WriteLine($"Difference: {string.Format(format, max.StockValue - min.StockValue)} ({string.Format(format, (min.StockValue / max.StockValue))})");
        }

        public void printStockSummary_v2(string stockSymbolIn)
        {
            List<Stock> instances = new List<Stock>();
            //get instances of searched stock into temp list
            getInstances(stockSymbolIn, instances);

            //generates list of keys by day, not sure how to access this list of keys
            //would then be used to create lists of each date, find first and last on each day, and print difference between them
            //LINQ is tough
            instances.GroupBy(x => x.Timestamp.Day).ToList();

        }

        private static void findMaxMin(List<Stock> instances, out Stock min, out Stock max)
        {
            //initialise min & max for comparisons
            min = instances[0];
            max = instances[0];
            //find max and min
            foreach (Stock i in instances)
            {
                if (i.StockValue < min.StockValue)
                {
                    min = i;
                }

                if (i.StockValue > max.StockValue)
                {
                    max = i;
                }
            }
        }

        public double biggestGain(string stockSymbolIn)
        {
            List<Stock> instances = new List<Stock>();
            getInstances(stockSymbolIn, instances);

            instances.Sort((x, y) => x.Timestamp.CompareTo(y.Timestamp));         //order list in place, by timestamp
            printStockInformationList(instances);                                  //need separate print function for temp 


            List<List<Stock>> sublists = new List<List<Stock>>();
            getIncreasingElements(instances, sublists);

            List<double> differences = new List<double>();

            //retrieve list of stocks
            //iterate through, find difference, store, repeat
            getDifferences(sublists, differences);

            double biggest = findHighestValue(differences);
            return biggest;
        }

        public double biggestLoss(string stockSymbolIn)
        {
            List<Stock> instances = new List<Stock>();
            getInstances(stockSymbolIn, instances);

            instances.Sort((x, y) => x.Timestamp.CompareTo(y.Timestamp));         //order list in place, by timestamp
            printStockInformationList(instances);


            List<List<Stock>> sublists = new List<List<Stock>>();
            getDecreasingElements(instances, sublists);

            List<double> differences = new List<double>();

            //retrieve list of stocks
            //iterate through, find difference, store, repeat
            getDifferences(sublists, differences);

            double biggest = findHighestValue(differences);

            return biggest;
        }

        private static double findHighestValue(List<double> differences)
        {
            double biggest = 0;
            //print highest difference
            foreach (double d in differences)
            {
                if (d > biggest)
                {
                    biggest = d;
                }
            }

            return biggest;
        }

        private void getInstances(string stockSymbolIn, List<Stock> instances)
        {
            //get instances of searched stock into temp list
            foreach (Stock s in Stocks)
            {
                if (s.StockSymbol == stockSymbolIn)
                {
                    instances.Add(s);
                }
            }
        }

        //for each sublist in sublists, iterate through and compare max and min, store results
        private static void getDifferences(List<List<Stock>> sublists, List<double> differences)
        {
            var min = sublists[0][0];
            var max = sublists[0][0];

            foreach (List<Stock> s in sublists)
            {
                foreach (Stock x in s)
                {
                    findMaxMin(s, out min, out max);
                }
                //find max and min, add to list for comparison
                differences.Add(max.StockValue - min.StockValue);
            }
        }

        private static void getIncreasingElements(List<Stock> instances, List<List<Stock>> sublists)
        {
            List<Stock> temp = new List<Stock>();
            int index = 0;
            do
            {
                for (int i = index; i < instances.Count; i++)
                {
                    if ((index + 1) == instances.Count)
                    {
                        temp.Add(instances[i]);
                        sublists.Add(temp);
                        index++;
                        break;
                    }

                    else if (instances[index + 1].StockValue > instances[i].StockValue)          //go through list, break into sub lists where subsequent elements are 
                    {
                        temp.Add(instances[i]);
                        index++;
                    }
                    //for each sublist in sublists, iterate through and compare max and min, store results
                    else
                    {
                        temp.Add(instances[i]);

                        i++;
                        index = i;

                        sublists.Add(temp);
                        temp = new List<Stock>();
                        break;
                    }
                }
            } while (index < instances.Count);
        }

        private static void getDecreasingElements(List<Stock> instances, List<List<Stock>> sublists)
        {
            List<Stock> temp = new List<Stock>();
            int index = 0;
            do
            {
                for (int i = index; i < instances.Count; i++)                               //when adding second list to list of lists, 1st list is overwritten?? This was to do with the reference
                {
                    if ((index + 1) == instances.Count)
                    {
                        temp.Add(instances[i]);
                        sublists.Add(temp);
                        index++;
                        break;
                    }

                    else if (instances[index + 1].StockValue < instances[i].StockValue)          //go through list, break into sub lists where subsequent elements are decreasing
                    {
                        temp.Add(instances[i]);
                        index++;
                    }

                    else
                    {
                        temp.Add(instances[i]);

                        i++;
                        index = i;

                        sublists.Add(temp);
                        temp = new List<Stock>();                                       //creating new object to overwrite reference
                        break;
                    }
                }
            } while (index < instances.Count);
        }

        static string formatDateTime(string s)
        {
            string datetime = s;
            datetime = datetime.Replace("{", "");       //This is definitely longwinded and ugly but spent too much time on it
            datetime = datetime.Replace("}", "");       //For some reason this adds white space at the beginning of string
            datetime = datetime.Remove(0, 1);            //which is removed here. shouldve used StringBuilder 
            return datetime;
        }

        public void assignVariables(List<String> CollectionOfStockInfo)
        {
            int item = 0;                                               //item tracker to track which stock we are currently parsing
            foreach (string s in CollectionOfStockInfo)                  //iterate through the list of stockInfo, parsing it for information
            {
                var temp = new Stock();                                 //temp obj that the parsed information is added to

                var parsed = new List<string>();
                parsed = CollectionOfStockInfo[item].Split(',').ToList();

                temp.StockSymbol = parsed[0];
                temp.StockName = parsed[1];

                string datetime = formatDateTime(parsed[2]);
                Convert.ToDateTime(datetime);

                IFormatProvider culture = new CultureInfo("en-EN", true);
                temp.Timestamp = DateTime.ParseExact(datetime, "dd/MM/yyyy HH:mm:ss", culture);

                if (Double.TryParse(parsed[3], out double y))
                {
                    temp.StockValue = y;
                }

                parsed.Clear();                                         //clear the parsing array
                Stocks.Add(temp);                                      //add the new stock to the global list of stocks
                item++;
            }
        }
    }
}


