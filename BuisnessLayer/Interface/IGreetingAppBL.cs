using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace BuisnessLayer.Interface
{
    public interface IGreetingAppBL
    {
        public string Greet();
        public string getGreeting(DetailsModel user);
        public bool GreetMethod(GreetingModel greetingModel);
        public GreetingModel GreetingIDFind(int ID);

        public List<GreetingModel> GetAllGreetings();
    }
}
