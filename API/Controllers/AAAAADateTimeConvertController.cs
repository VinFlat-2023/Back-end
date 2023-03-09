using System.Globalization;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AAAAADateTimeConvertController : ControllerBase
{
    // POST api/<AAAAADateTimeConvertController>
    [HttpPost]
    public IActionResult Post([FromBody] string dateString)
    {
        try
        {
            //  2009-05-08 14:40:52,531
            //  5/8/2009 14:40:52
            //  yyyy-MM-dd HH:mm:ss,fff
            string[] formats = { "d/M/yyyy HH:mm:ss", "d/M/yyyy" };
            var myDate = DateTime.ParseExact(dateString, formats,
                CultureInfo.InvariantCulture);
            return Ok(new
            {
                Class = myDate.GetType(), Value = myDate.ToString("d MMM yyyy HH:mm:ss"),
                NewVal = dateString.ConvertToDateTime()
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}