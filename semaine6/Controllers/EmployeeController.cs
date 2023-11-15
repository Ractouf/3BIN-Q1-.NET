using Microsoft.AspNetCore.Mvc;
using semaine6.Models;
using semaine6.UnitOfWork;

namespace semaine6.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        NorthwindContext context = new NorthwindContext();
        IUnitOfWork unitOfWork = new UnitOfWorkSQLServer(context);

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
    }
}
