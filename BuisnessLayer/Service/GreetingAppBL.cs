using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interface;
using ModelLayer.Model;
using RepositeryLayer.Interface;


namespace BuisnessLayer.Service
{
    public class GreetingAppBL:IGreetingAppBL
    {
        private readonly IGreetingAppRL _iGreetingAppRL;
        public GreetingAppBL(IGreetingAppRL greetingAppRL) {
            _iGreetingAppRL = greetingAppRL;
        }
        public string Greet()
        {
            return "HelloWorld";
        }
        public string getGreeting(DetailsModel detailsModel) {
            return _iGreetingAppRL.GetGreeting(detailsModel);
        }
        public bool GreetMethod(GreetingModel greetingModel) 
        { 
        return _iGreetingAppRL.GreetMethod(greetingModel);
        }
        public GreetingModel GreetingIDFind(int ID) 
        {
        return _iGreetingAppRL.GreetingIDFind(ID);
        }
    }
}
