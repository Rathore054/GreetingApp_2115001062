using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Interface;
using ModelLayer.Model;
using BuisnessLayer.Service;
using RepositeryLayer.Interface;
using NLog;
using System.Reflection.Metadata.Ecma335;

namespace GreetingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingAppController : ControllerBase
    {
        private readonly IGreetingAppBL _greetingBL;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public GreetingAppController(IGreetingAppBL _greetingAppBL) {
            _greetingBL= _greetingAppBL;
            _logger.Info("logger started");
        }
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> response = new ResponseModel<string>();
            response.Success = true;
            response.Message = "Get message recieved";
            response.Data = "I am 007";
            return Ok(response);
        }
       
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            response.Success = true;
            response.Message = "Post message recieved";
            response.Data = $"Key:{requestModel.Key},Value:{requestModel.Value}";
            return Ok(response);
        }
        [HttpPut]
        public IActionResult Put(RequestModel requestModel) {
            ResponseModel<string> response = new ResponseModel<string>();
            response.Success = true;
            response.Message = "put message recieved";
            response.Data= $"Key:{requestModel.Key},Value:{requestModel.Value}";
            return Ok(response);
        }
        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel) {
            ResponseModel<string> response = new ResponseModel<string>();
            response.Success = true;
            response.Message = "put message recieved";
            response.Data = $"Key:{requestModel.Key},Value:{requestModel.Value}";
            return Ok(response);
        }
        [HttpDelete]
        public IActionResult Delete(RequestModel requestModel) {
            ResponseModel<string> response = new ResponseModel<string>();
            response.Success = true;
            response.Message = "delete message recieved";
            response.Data = $"Key:{requestModel.Key},Deleted Succesfully";
            return Ok(response);
        }
        [HttpGet]
        [Route("Hello!")]
        public string world() 
        {
            return _greetingBL.Greet();
        }
        /// <summary>
        /// used for displaying Firstname and Lastname with Hello[UC3]
        /// </summary>
        /// <param name="detailsModel"></param>
        /// <returns></returns>
        [HttpPost("Detail")]
        public IActionResult Detail(DetailsModel detailsModel) 
        {
            var result = _greetingBL.getGreeting(detailsModel);

            ResponseModel<string> response=new ResponseModel<string>();
            response.Success = true;
            response.Message = "Greeting with Firstname and Last";
            response.Data= result;
            return Ok(response);
        }
        /// <summary>
        /// UC5down
        /// </summary>
        /// <returns></returns>
        [HttpPost("displayGreet")]
        public IActionResult PostDisplay(GreetingModel greetingModel) 
        {
            var response=new ResponseModel<string>();
            bool isMessagegrret=_greetingBL.GreetMethod(greetingModel);
            if (isMessagegrret)
            {
                response.Success = true;
                response.Message = "Displayed Greet message";
                response.Data = greetingModel.ToString();
                return Ok(response);
            }
            response.Success = true;
            response.Message = "Displayed Greet message";
            return Conflict(response);
        }


        [HttpGet("IDFind{ID}")]
        public IActionResult IDFind(int ID)
        {
            var response = new ResponseModel<GreetingModel>();
            var find = _greetingBL.GreetingIDFind(ID);
            if (find!=null)
            {
                response.Success = true;
                response.Message = "ID found";
                response.Data = find;
                return Ok(response);
            }
            response.Success = true;
            response.Message = "not found";
            return NotFound(response);
        }
        [HttpGet("AllIdShow")]
        public IActionResult AIdShow() 
        {
            ResponseModel<List<GreetingModel>> response = new ResponseModel<List<GreetingModel>>();
            var result= _greetingBL.GetAllGreetings();
            if (result != null)
            { 
            response.Success = true;
            response.Message = "All ID Display";
            response.Data = result;
            return Ok(response);
            }
            response.Success = false;
            response.Message = "No ID to Display";
            return NotFound(response);
        }
        [HttpPut("UpdateGreet")]
        public IActionResult UpdatePut(int ID, GreetingModel greetingModel) 
        {

            ResponseModel<GreetingModel> response = new ResponseModel<GreetingModel>();
            var result = _greetingBL.UpdateGreeting(ID,greetingModel);
            if (result != null)
            {
                response.Success = true;
                response.Message = "Updated message";
                response.Data = result;
                return Ok(response);
            }
            response.Success = false;
            response.Message = "Nothing to update";
            return NotFound(response);
        }

    }
}
