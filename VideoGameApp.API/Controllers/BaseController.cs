using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.BLL.Services;

namespace VideoGameApp.API.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
