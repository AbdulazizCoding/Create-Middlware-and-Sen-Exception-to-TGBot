using Microsoft.AspNetCore.Mvc;
using Middlware.Filters;

namespace Middlware.Controllers;

[Route("[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private List<string> _uzData = new List<string>() { "O'zbekcha ma'lumotlar", "Malumotlar" };
    private List<string> _enData = new List<string>() { "English language data", "Data" };


    [HttpGet]
    [LanguageFilter]
    public IActionResult GetDataList()
    {
        if(RequestCulture.RequestLanguage == "en")
        {
            return Ok(_enData);
        }

        if(RequestCulture.RequestLanguage == "uz")
        {
            return Ok(_uzData);
        }

        throw new InvalidOperationException();
    }
}