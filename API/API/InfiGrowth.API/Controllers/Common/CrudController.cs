using InfiGrowth.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Skyttus.Core.Entity.Contracts;
using Skyttus.Core.Services.Contracts;
using Skyttus.Core.Services.Response;
using Skyttus.Core.Services.Result;

namespace InfiGrowth.API.Controllers.Common
{
    public abstract class CrudController<T, Q> : ControllerBase where T : class
                                                       where Q : class, IBaseEntity
    {
        private readonly ILogger _logger;
        private readonly IBaseService<T, Q> _baseService;

        public CrudController(ILogger logger, IBaseService<T, Q> baseService)
        {
            _logger = logger;
            _baseService = baseService;
        }

        [HttpPost]
        public virtual async Task<ActionResult<BaseResult<T>>> Add([FromBody] T entity)
        {
            //var errors = CheckBeforeAdd(entity);

            //if (errors == null && errors.Count > 0)
            //{
                var result = await _baseService.Add(entity);
                return Ok(new SuccessResult<T>(result));
            //}
            //else
            //{
            //    return BadRequest(errors);
            //}
        }

        protected virtual List<string> CheckBeforeAdd(T entity)
        {
            return new();
        }

        [HttpPost]
        [Route("api/[controller]/returnGuid")]
        public virtual async Task<ActionResult<Guid>> AddReturnGuid([FromBody] T entity)
        {
            var result = await _baseService.Add<Guid>(entity);
            return Ok(new SuccessResult<Guid>(result));
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<BaseResult<T>>> GetById(Guid id)
        {
            var result = await _baseService.GetById(id)
;
            if (result == null)
            {
                return Ok(new ErrorResult<T>(203, new ErrorResponse() { Type = "NoContent", ErrorMessage = "No Data Found" }));
            }
            else
            {
                return Ok(new SuccessResult<T>(result));
            }
        }

        [HttpGet]
        public virtual async Task<ActionResult<T>> GetAll(bool trackChanges)
        {
            var result = await _baseService.GetAll(trackChanges);
            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<T>> Update(T entity)
        {
            if (entity is AuditableBaseEntity auditableEntity)
            {
                auditableEntity.CreatedAt = DateTime.Now;
                auditableEntity.DeletedAt = DateTime.Now;
                auditableEntity.UpdatedAt = DateTime.Now;
            }
            var result = await _baseService.Update(entity);
            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await _baseService.Delete(id);
            _logger.LogInformation("< Delete");
            return Ok();
        }
    }
}
