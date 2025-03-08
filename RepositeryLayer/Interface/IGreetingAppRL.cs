using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositeryLayer.Entity;

namespace RepositeryLayer.Interface
{
    public interface IGreetingAppRL
    {
        public string GetGreeting(DetailsModel detailsModel);
        public bool GreetMethod(GreetingModel greetingModel);
        public GreetingModel GreetingIDFind(int ID);
        public List<AppEntity> GetAllGreetings();//All ID Show

        public AppEntity UpdateGreeting(int ID,GreetingModel greetingModel);//Edit Greeting Message UC7

        public bool DeleteGreeting(int ID);
    }
}
