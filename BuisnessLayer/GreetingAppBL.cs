using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interface;

namespace BuisnessLayer.Service
{
    public class GreetingAppBL:IGreetingAppBL
    {
        public string Greet()
        {
            return "HelloWorld";
        }
    }
}
