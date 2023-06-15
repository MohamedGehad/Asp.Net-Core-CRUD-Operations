using AutoMapper;
using BussnisLogicLayer.interfaces;
using BussnisLogicLayer.Repos;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrestionLayer.Helper;
using PrestionLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace PrestionLayer.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //private IEmployeeReposatory _employeeReposatory;
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public EmployeeController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            //_employeeReposatory = employeeReposatory;
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		}

        public IActionResult Index(string Searchvalue)

        {

            IEnumerable<EmployeeViewModel> mappedEmps;
            if (string.IsNullOrEmpty(Searchvalue))
            {

                mappedEmps = _mapper.Map<IEnumerable<Employee>,
                    IEnumerable<EmployeeViewModel>>(_unitOfWork.EmployeeReposatory.GetAll());
            }
            else
            {
                mappedEmps = _mapper.Map<IEnumerable<Employee>,
                    IEnumerable<EmployeeViewModel>>(_unitOfWork.EmployeeReposatory.GetAll());

            }
            //var mappedEmps = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
				return View(mappedEmps);

			

		}
        [HttpGet]
        public IActionResult Create()
        {

			ViewData["Departments"] = _unitOfWork.DepartmentRepository.GetAll();

			return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel EmployeeVM )
        {
            if (ModelState.IsValid)
            {

                //Employee employee =  (Employee) EmployeeVM
                ///var emolyee = new Employee()
                ///{   
                ///    //Name = EmployeeVM.Name,
                ///    //Address = EmployeeVM.Address,
                ///    //Email = EmployeeVM.Email,
                ///    //Salary = EmployeeVM.Salary,
                ///    //Age = EmployeeVM.Age,
                ///    //IsActive = EmployeeVM.IsActive,
                ///    //HairDate = EmployeeVM.HairDate,
                ///    //Phone = EmployeeVM.Phone 
                ///}
                ///

                EmployeeVM.imageName = DocumentSettings.UploadFile(EmployeeVM.Image, "imges");


                var MapEmployee = _mapper.Map<EmployeeViewModel , Employee>(EmployeeVM);

                _unitOfWork.EmployeeReposatory.add(MapEmployee);


                _unitOfWork.complete();//SAVE CHANGES
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(EmployeeVM);
        }


        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            
			if (id is null)
				return BadRequest();
			var Emp =  _unitOfWork.EmployeeReposatory.Get(id.Value);
			if (Emp is null)
				return NotFound();

            var mappedEmp = _mapper.Map<Employee , EmployeeViewModel>(Emp);
			return View(viewName, mappedEmp);


		}


		[HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// to edit in website only
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM   )
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel , Employee>(employeeVM);
                   _unitOfWork.EmployeeReposatory.Update(mappedEmp);

                    _unitOfWork.complete();//SAVE CHANGES

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1- LOG Exxeption
                    //2- frindy Massge
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(employeeVM);

        }


        //departmet/delete

        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");

        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try{


                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM); 
                _unitOfWork.EmployeeReposatory.delete(mappedEmp);
                _unitOfWork.complete();//SAVE CHANGES

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(employeeVM);
            }
        }
    }
}
