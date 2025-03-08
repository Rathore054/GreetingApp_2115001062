using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using RepositeryLayer.Interface;
using ModelLayer.Model;
using NLog;
using RepositeryLayer.Context;
using RepositeryLayer.Entity;

namespace RepositeryLayer.Service
{
    public class GreetingAppRL : IGreetingAppRL
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly AppDbContext _context;
        public GreetingAppRL(AppDbContext context)
        {
            _context = context;
        }

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
        /// <summary>
        /// UC4
        /// </summary>
        /// <param name="greetingModel"></param>
        /// <returns></returns>
        public bool GreetMethod(GreetingModel greetingModel)
        {
            if (_context.Users.Any(greet => greet.Greet == greetingModel.GreetMessage))
            {
                return false;
            }
            var appEntity = new AppEntity
            {
                Greet = greetingModel.GreetMessage,
            };
            // Save to database
            _context.Users.Add(appEntity);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// UC5
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public GreetingModel GreetingIDFind(int ID)
        {
            var IDFind = _context.Users.FirstOrDefault(g => g.Id == ID);
            if (IDFind != null)
            {
                return new GreetingModel()
                {
                    ID = IDFind.Id,
                    GreetMessage = IDFind.Greet
                };
            }
            return null;

        }
        public List<AppEntity> GetAllGreetings()
        {
            return _context.Users.ToList();
        }
    
        /// <summary>
        /// UC6
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newMessage"></param>
        /// <returns></returns>
        /// 

     public AppEntity UpdateGreeting(int ID, GreetingModel greetingModel)
        {
            var MSGupdate = _context.Users.FirstOrDefault(g => g.Id == ID);
            if (MSGupdate != null)
            {
                MSGupdate.Greet = greetingModel.GreetMessage;
                _context.Users.Update(MSGupdate);
                _context.SaveChanges();
                return MSGupdate;
            }
            return null;
        }
    }
    }
