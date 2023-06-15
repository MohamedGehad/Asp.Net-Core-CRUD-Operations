using BussnisLogicLayer.interfaces;
using BussnisLogicLayer.Repos;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace PrestionLayer.Controllers
{
	public class DepartmentController : Controller
	{
		//private IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork) // Ask clr to creating from class implmenting InterFace IdepartmentRepo
        {
			//_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
		{
			var departments = _unitOfWork.DepartmentRepository.GetAll();

			return View(departments); 
		}

		[HttpGet]
		public IActionResult Create()
		 {
			return View();
		}

		[HttpPost]

		
		public IActionResult Create(department Department)
		{
			if(ModelState.IsValid) //SERVER SIDE VALDITION
			{
				  _unitOfWork.DepartmentRepository.add(Department);
				var count = _unitOfWork.complete();   
                // 3- TempDate
                if (count > 0) 
				TempData["Message"] = "Dept is create successfuly";
				return RedirectToAction(nameof(Index));
			}
			return View(Department);
		}

		//department/Details/1


		[HttpGet]
         public IActionResult Details(int? id , string viewName = "Details")
		{
			if (id is null)
				return BadRequest();
			var dept = _unitOfWork.DepartmentRepository.Get(id.Value);
			if (dept is null)
				return NotFound();
			return View(viewName , dept);
			
		}


		//departmetn/edit/1
		[HttpGet]
		public IActionResult Edit(int? id) {

			/// if (id is null)
			///	return BadRequest();
			///var dept = _departmentRepository.Get(id.Value);
			///if (dept is null)
			///	return NotFound();
			///return View(dept);
			///
			return Details(id , "Edit" );
		}

		[HttpPost]
		[ValidateAntiForgeryToken]// to edit in website only
        public IActionResult Edit([FromRoute] int id ,department department)
        {
			if (id != department.Id)
				return BadRequest();
			if (ModelState.IsValid)
			{
				try
				{
				_unitOfWork.DepartmentRepository.Update(department);

				return RedirectToAction(nameof(Index));
				}
				catch(Exception ex)
				{
					//1- LOG Exxeption
					//2- frindy Massge
					ModelState.AddModelError(string.Empty, ex.Message);
					
				}
			}
			return View(department);

        }
		

		//departmet/delete

		public IActionResult Delete(int? id)
		{

			return Details(id, "Delete");

		}

		[HttpPost]
		public IActionResult Delete([FromRoute]int id ,department department)
		{
			if (id != department.Id)
				return BadRequest();
			try
			{
				 _unitOfWork.DepartmentRepository.delete(department);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);

				return View(department); 
			}
		}
    }
}
