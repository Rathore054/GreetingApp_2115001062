using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Interface;
using ModelLayer.Model;

namespace GreetingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingAppController : ControllerBase
    {
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

    }
}
