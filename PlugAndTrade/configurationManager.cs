using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugAndTrade
{
    internal class configurationManager
    {
        public static IConfigurationRoot GetConfiguration()
        {
            
            //string fileName = "appsettings.json";
            //string fullpath = Path.GetFullPath(fileName);
            return new ConfigurationBuilder()
                .AddJsonFile("C:\\Users\\pontande123\\source\\repos\\plugAndTrade\\PlugAndTrade\\PlugAndTrade\\appsettings.json")
                .Build();
        }
    }
}
