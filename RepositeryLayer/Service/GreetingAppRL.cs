using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using RepositeryLayer.Interface;
using ModelLayer.Model;

namespace RepositeryLayer.Service
{
    public class GreetingAppRL : IGreetingAppRL
    {
        public string GetGreeting(DetailsModel detailsModel)
        {
            if (!string.IsNullOrWhiteSpace(detailsModel.FirstName) && !string.IsNullOrWhiteSpace(detailsModel.LastName))
            {
                return $"Hello, {detailsModel.FirstName} {detailsModel.LastName}!";
            }
            else if (!string.IsNullOrWhiteSpace(detailsModel.FirstName))
            {
                return $"Hello, {detailsModel.FirstName}!";
            }
            else if (!string.IsNullOrWhiteSpace(detailsModel.LastName))
            {
                return $"Hello, {detailsModel.LastName}!";
            }
            else
            {
                return "Hello, World!";
            }
        }
    }
}
