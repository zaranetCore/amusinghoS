using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amusinghoS.App.Dto;
using amusinghoS.EntityData.Model;
using amusinghoS.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace amusinghoS.App.Controllers
{
    public class OauthController : Controller
    {
        private UnitOfWork _unitWork;
        private readonly IMapper _mapper;
        public OauthController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Regist([FromBody] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _unitWork.amusingArticleUserRepository.AnyAsync(u=>u.articleUserName == userViewModel.username))
                {
                    return Content("The user already exists!");
                }
                else
                {
                    await _unitWork.amusingArticleUserRepository.InsertAsync(
                        _mapper.Map<amusingUser>(userViewModel)
                        ,true);
                    return Content("save successfully!");
                }
            }
            return Content(new ArgumentException().ToString());
        }

        public async Task<IActionResult> Signin([FromBody] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _unitWork.amusingArticleUserRepository.AnyAsync(u => u.articleUserName == userViewModel.username ))
                {
                    return Content("The user already exists!");
                }
            }
            return Content(new ArgumentException().ToString());
        }
    }
}