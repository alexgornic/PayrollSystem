using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Entity;
using PayrollSystem.Models;
using PayrollSystem.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            var models =  employees.Select(e => new EmployeeIndexViewModel()
            {
                Id= e.Id,
                EmployeeNo = e.EmployeeNo,
                FullName= e.FullName,
                Role = e.Role,
                DateJoined= e.DateJoined,
                Gender=e.Gender,
                City =e.City,
            }).ToList();
            return View(models);
        }

        //Create employee
        [HttpGet]
        public IActionResult Create() 
        {
            var employee = new EmployeeCreateViewModel();
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model) 
        {
            var employee = new Employee()
            {
                Address = model.Address,
                City = model.City,
                DateJoined = model.DateJoined,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeNo = model.EmployeeNo,
                FullName = model.FullName,
                Role = model.Role,
                Id = model.Id,
                MiddleName = model.MiddleName,
                NationalInsuranceNo = model.NationalInsuranceNo,
                PaymentMethod = model.PaymentMethod,
                PostCode = model.PostCode,
            };
            await _employeeService.CreateAsync(employee);
            return  RedirectToAction("Index");  
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var employee = _employeeService.GetById(id);
            if(employee == null) 
                return NotFound();
            var employeeViewModel = new EmployeeEditViewModel()
            {
                Address = employee.Address,
                City = employee.City,
                DateJoined = employee.DateJoined,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmployeeNo = employee.EmployeeNo,
                Role = employee.Role,
                Id = employee.Id,
                MiddleName = employee.MiddleName,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                PostCode = employee.PostCode,
            };
            return View(employeeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            var employee = _employeeService.GetById(model.Id);
            if (employee == null)
                return NotFound();
            employee.NationalInsuranceNo = model.NationalInsuranceNo;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Gender = model.Gender;
            employee.DateJoined = model.DateJoined;
            employee.Email = model.Email;
            employee.City = model.City;
            employee.Role = model.Role;
            employee.PaymentMethod = model.PaymentMethod;
            employee.Address = model.Address;
            employee.DateOfBirth = model.DateOfBirth;
            employee.EmployeeNo = model.EmployeeNo;
            employee.MiddleName = model.MiddleName;
            employee.PostCode = model.PostCode;
            
            await _employeeService.UpdateAsync(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if(employee == null)
                return NotFound();
            var model = new EmployeeDetailViewModel()
            {
                Address = employee.Address,
                City = employee.City,
                DateJoined = employee.DateJoined,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                FullName = employee.FullName,
                EmployeeNo = employee.EmployeeNo,
                Role = employee.Role,
                Id = employee.Id,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                PostCode = employee.PostCode,

            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var model = new EmployeeDeleteViewModel()
            {
                Id = id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employeeService.DeleteAsync(model.Id);
            return RedirectToAction("Index");
            
        }
    }
}
