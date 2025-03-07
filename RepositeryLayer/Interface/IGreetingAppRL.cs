using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace RepositeryLayer.Interface
{
    public interface IGreetingAppRL
    {
        public string GetGreeting(DetailsModel detailsModel);
        public bool GreetMethod(GreetingModel greetingModel);
        public GreetingModel GreetingIDFind(int ID);
    }
}
