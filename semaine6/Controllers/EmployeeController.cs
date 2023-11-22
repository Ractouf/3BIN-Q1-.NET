using Microsoft.AspNetCore.Mvc;
using semaine6.DTO;
using semaine6.Models;
using semaine6.UnitOfWork;

namespace semaine6.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly NorthwindContext _dbcontext;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;

            _dbcontext = new NorthwindContext();
            _unitOfWork = new UnitOfWorkSQLServer(_dbcontext);
        }

        [HttpPost]
        public async Task CreateOneAsync(EmployeeDTO employeeDTO)
        {
            employeeDTO.EmployeeId = 0;
            Employee employee = DTOToEmployee(employeeDTO);
            await _unitOfWork.EmployeeRepository.InsertAsync(employee);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            IList<Employee> lst = await _unitOfWork.EmployeeRepository.GetAllAsync();

            return lst.Select(e => EmployeeToDTO(e)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            Employee? emp = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(EmployeeToDTO(emp));
            }
        }

        [HttpPut]
        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee e = DTOToEmployee(employeeDTO);
            await _unitOfWork.EmployeeRepository.SaveAsync(e);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            Employee? emp = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.EmployeeRepository.DeleteAsync(emp);
                return Ok();
            }
        }

        private static EmployeeDTO EmployeeToDTO(Employee emp) =>
            new EmployeeDTO
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy

            };

        private static Employee DTOToEmployee(EmployeeDTO emp) =>
            new Employee
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };

    }
}
