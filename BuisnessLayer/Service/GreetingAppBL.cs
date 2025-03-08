using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interface;
using ModelLayer.Model;
using RepositeryLayer.Entity;
using RepositeryLayer.Interface;


namespace BuisnessLayer.Service
{
    public class GreetingAppBL : IGreetingAppBL
    {
        private readonly IGreetingAppRL _iGreetingAppRL;
        public GreetingAppBL(IGreetingAppRL greetingAppRL)
        {
            _iGreetingAppRL = greetingAppRL;
        }
        public string Greet()
        {
            return "HelloWorld";
        }
        public string getGreeting(DetailsModel detailsModel)
        {
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

        /// <summary>
        /// UC5
        /// </summary>
        /// <returns></returns>
        public List<GreetingModel> GetAllGreetings()
        {

            var list = _iGreetingAppRL.GetAllGreetings();
            if (list != null)
            {
                return list.Select(g => new GreetingModel
                {
                    ID = g.Id,
                    GreetMessage = g.Greet,
                }).ToList();
            }
            return null;


        }
        public GreetingModel UpdateGreeting(int ID, GreetingModel greetingModel)
        {
            var result = _iGreetingAppRL.UpdateGreeting(ID,greetingModel);
            if (result != null)
            {
                return new GreetingModel
                {
                    ID = result.Id,
                    GreetMessage = result.Greet,
                };


            }
            return null;

        }
    }
}
