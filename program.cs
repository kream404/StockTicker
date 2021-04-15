//Kiram Rahim
//Stock Ticker program to track various properties of a Stock
//This class is for testing purposes only


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTicker
{
    class program
    {
        static void Main(string[] args)
        {
            StockTicker s = new StockTicker();

            //s.parseStockInformation("MSFT, Microsoft Corporation, {11/02/2021 14:39:33}, 244.17");
            //s.parseStockInformation("MSFT, Microsoft Corporation, {11/02/2021 14:39:33}, 230.17;MSFT, Microsoft Corporation, {11/02/2021 14:39:33}, 244.17;");
            //s.parseStockInformation("MSFT, Microsoft Corporation, {11/02/2021 14:39:33}, 241.17;MSFT, Microsoft Corporation, {11/02/2021 15:39:33}, 242.17;MSFT, Microsoft Corporation, {11/02/2021 16:39:33}, 243.17;MSFT, Microsoft Corporation, {11/02/2021 18:39:33}, 244.17;TSLA, Tesla Inc., {01/02/2021 14:46:23}, 589.34;TSLA, Tesla Inc., {02/01/2021 17:46:23}, 781.34;TSLA, Tesla Inc., {05/11/2021 15:46:23}, 832.123;TSLA, Tesla Inc., {21/09/2021 14:46:23}, 238.12");
            //s.parseStockInformation("TSLA, Tesla Inc., {11/02/2021 14:46:23}, 822.34;TSLA, Tesla Inc., {11/02/2021 17:46:23}, 256.34;TSLA, Tesla Inc., {11/02/2021 15:46:23}, 822.34;TSLA, Tesla Inc., {09/02/2021 14:46:23}, 432.34");
            //s.parseStockInformation("MSFT, Microsoft Corporation, {01/02/2021 14:39:33}, 241.17;MSFT, Microsoft Corporation, {02/02/2021 15:39:33}, 242.17;MSFT, Microsoft Corporation, {03/02/2021 16:39:33}, 243.17");
            //s.parseStockInformation("MSFT, Microsoft Corporation, {04/02/2021 14:39:33}, 220.17;MSFT, Microsoft Corporation, {05/02/2021 15:39:33}, 232.17;MSFT, Microsoft Corporation, {06/02/2021 16:39:33}, 233.17");
            //Console.WriteLine(s.printStockInformation("MSFT"));
            //Console.WriteLine(s.printStockInformation("TSLA"));
            s.parseStockInformation("MSFT, Microsoft Corporation, {06/02/2021 14:39:33}, 250.54;MSFT, Microsoft Corporation, {06/02/2021 15:39:33}, 251.45;MSFT, Microsoft Corporation, {06/02/2021 16:39:33}, 252.11");
            s.parseStockInformation("TSLA, Tesla Inc., {11/02/2021 14:46:23}, 822.34;TSLA, Tesla Inc., {11/02/2021 17:46:25}, 821.42;TSLA, Tesla Inc., {11/02/2021 15:46:26}, 821.40");
            s.parseStockInformation("MSFT, Microsoft Corporation, {05/02/2021 14:39:33}, 252.00;MSFT, Microsoft Corporation, {05/02/2021 15:39:34}, 252.12;MSFT, Microsoft Corporation, {05/02/2021 16:39:35}, 253.18");
            s.parseStockInformation("TSLA, Tesla Inc., {11/02/2021 14:46:27}, 821.78;TSLA, Tesla Inc., {11/02/2021 17:46:29}, 821.94;TSLA, Tesla Inc., {11/02/2021 15:46:30}, 822.34");
            s.parseStockInformation("MSFT, Microsoft Corporation, {06/02/2021 14:39:37}, 253.31;MSFT, Microsoft Corporation, {06/02/2021 15:39:38}, 252.12;MSFT, Microsoft Corporation, {06/02/2021 16:39:39}, 253.19");
            s.parseStockInformation("TSLA, Tesla Inc., {11/02/2021 14:46:27}, 822.68;TSLA, Tesla Inc., {11/02/2021 17:46:29}, 822.74;TSLA, Tesla Inc., {11/02/2021 15:46:30}, 822.34");
            s.parseStockInformation("MSFT, Microsoft Corporation, {05/02/2021 14:39:40}, 252.13;MSFT, Microsoft Corporation, {05/02/2021 15:39:42}, 251.12;MSFT, Microsoft Corporation, {05/02/2021 16:39:47}, 249.78");
            s.parseStockInformation("TSLA, Tesla Inc., {11/02/2021 14:46:27}, 821.69;TSLA, Tesla Inc., {11/02/2021 17:46:29}, 821.54;TSLA, Tesla Inc., {11/02/2021 15:46:30}, 821.34");
            s.parseStockInformation("MSFT, Microsoft Corporation, {03/02/2021 14:39:49}, 247.90;MSFT, Microsoft Corporation, {03/02/2021 15:39:50}, 246.52;MSFT, Microsoft Corporation, {03/02/2021 16:39:52}, 245.98");
            s.parseStockInformation("TSLA, Tesla Inc., {11/02/2021 14:46:27}, 820.82;TSLA, Tesla Inc., {11/02/2021 17:46:29}, 821.23;TSLA, Tesla Inc., {11/02/2021 15:46:30}, 821.34");
            s.parseStockInformation("MSFT, Microsoft Corporation, {04/02/2021 14:39:57}, 244.83;MSFT, Microsoft Corporation, {04/02/2021 15:40:03}, 245.32;MSFT, Microsoft Corporation, {04/02/2021 16:40:07}, 246.18");
            s.parseStockInformation("MSFT, Microsoft Corporation, {05/02/2021 14:40:10}, 246.55;MSFT, Microsoft Corporation, {05/02/2021 15:40:13}, 246.12;MSFT, Microsoft Corporation, {05/02/2021 16:40:23}, 246.98");

            s.printStockSummary_v2("MSFT");
            Console.ReadKey();

            double biggestGain = s.biggestGain("MSFT");
            Console.WriteLine();
            Console.WriteLine();
            double biggestLoss = s.biggestLoss("MSFT");
            Console.WriteLine("Biggest Gain: " + biggestGain);
            Console.ReadKey();
            Console.WriteLine("Biggest Loss: " + biggestLoss);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            s.biggestGain("TSLA");
            Console.ReadKey();
            s.printStockSummary("TSLA");
            Console.ReadKey();
        }
    }
}
