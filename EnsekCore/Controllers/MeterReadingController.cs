

using EnsekCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnsekCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingController : ControllerBase
    {
        private IRepository _repository;

        public MeterReadingController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            using(var context = new EnsekModel())
            {
                return context.Users.ToList();
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> PostAsync()
        {
            var request = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                request =  await reader.ReadToEndAsync();
            }
            var meterReadingEngine = new MeterReadingEngine(_repository);
         
            return Ok(meterReadingEngine.Parse(request)); 
        }
    }
}
