using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EncounterGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncounterController : Controller
    {
        public string Index()
        {
            return "Welcome to the encounter generator.";
        }
    }
}
