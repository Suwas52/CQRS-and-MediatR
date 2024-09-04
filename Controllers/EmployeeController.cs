using AutoMapper;
using CQRS_and_MediatR.Core.DTOs;
using CQRS_and_MediatR.Core.DTOs.General;
using CQRS_and_MediatR.Model;
using CQRS_and_MediatR.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_and_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericRepo<Employee,int> _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IGenericRepo<Employee, int> repo, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<GeneralResponseDto>> CreateEmployee ([FromBody] EmployeeCreateDto model)
        {
            try
            {
                var mapData = _mapper.Map<Employee>(model);
                await _repo.CreateAsync(mapData);
                _logger.LogInformation("Employee Created Successfully");

                return new GeneralResponseDto
                {
                    IsSucceed = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Employee Created Successfully"
                };
                
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Something happend during employee create");
                return new GeneralResponseDto
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    IsSucceed = false,
                    Message = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<ActionResult<GeneralResponseDto>> DeleteEmployee(int id)
        {
            try
            {
                var data = await _repo.GetByIdAsync(id);
                if(data.IsDeleted && !data.Status)
                {
                    return new GeneralResponseDto
                    {
                        IsSucceed = false,
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "Employee is not found"
                    };
                }

                var StatusMessage = await _repo.DeleteByIdAsync(id);
                return StatusMessage;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something happend during employee delete");
                return new GeneralResponseDto
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    IsSucceed = false,
                    Message = ex.Message
                };
            }
        }
    }
}
