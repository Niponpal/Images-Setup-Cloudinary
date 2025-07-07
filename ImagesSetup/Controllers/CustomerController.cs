using ImagesSetup.Models;
using ImagesSetup.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ImagesSetup.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var data = _customerRepository.GatAllData();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var data = _customerRepository.AddData(customer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _customerRepository.GetById(id);
            if (data == null) 
            {
                return null;
            }
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(Customer customer) 
        {
            var data = _customerRepository.GetById(customer.Id);
            if (data == null)
            {
                return NotFound();
            }
            data.Address = customer.Address;
            data.CustomerUrl = customer.CustomerUrl;
            data.CustomerImages = customer.CustomerImages;  
            data.Name = customer.Name;
            data.Description = customer.Description;
            _customerRepository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
            var data = _customerRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _customerRepository.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
