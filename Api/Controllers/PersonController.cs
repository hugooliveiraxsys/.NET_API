using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;
using Models.Requests;
using Models.Responses.Base;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

/*São responsaveis pelas rotas 
 * 
 * A camada de controle é responsável por intermediar as requisições enviadas pelo View 
 * com as respostas fornecidas pelo Model, processando os dados que o usuário informou e
 * repassando para outras camadas. 

 */
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<GenericResponse<int?>> Create(PersonRequest personRequest)
        {
            try
            {
                int? data = await _personService.CreateAsync(personRequest);
                return new GenericResponse<int?>(data).CreatedWithSucess();
            }
            catch (Exception e)
            {
                return new GenericResponse<int?>().Error(HttpStatusCode.InternalServerError, e.Message); ;
            }
        }

        [HttpPost]
        [Route("bulkmanual")]
        public async Task<GenericResponse<int?>> BulkManualInsert(List<PersonRequest> peopleRequests)
        {
            try
            {
                int? data = await _personService.BulkManualInsert(peopleRequests);
                return new GenericResponse<int?>(data).CreatedWithSucess();
            }
            catch (Exception e)
            {
                return new GenericResponse<int?>().Error(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPost]
        [Route("bulkinsertauto")]
        public async Task<GenericResponse<bool>>BulkInsert([FromBody] List<PersonRequest> peopleRequests)
        {
            try
            {
                await _personService.BulkInsert(peopleRequests);
                return new GenericResponse<bool>().CreatedWithSucess();
            }
             catch (Exception e)
            {
                return new GenericResponse<bool>().Error(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<GenericResponse<int>> Update([FromBody] PersonRequest personRequest)
        {
            try
            {
                int data = (int)await _personService.UpdateAsync(personRequest);
                return new GenericResponse<int>(data).CreatedWithSucess();
}
            catch (Exception e)
            {
                return new GenericResponse<int>().Error(HttpStatusCode.InternalServerError, e.Message);
            }
          }

        [HttpGet]
        [Route("{id}")]
        //public async Task<GenericResponse<PessoaEntity>>GetById(int id)
        //{
        //    try
        //    {
        //        PessoaEntity entity = await _personService.GetByIdAsync(id);
        //        return new GenericResponse<PessoaEntity>(entity).CreatedWithSucess();
        //    }
        //    catch(Exception e)
        //    {
        //        return new GenericResponse<PessoaEntity>().Error(HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}

        public async Task<PessoaEntity> GetById(int id)
        {
            try
            {
                PessoaEntity entity = await _personService.GetByIdAsync(id);
                return entity;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("list")]
        public async Task<IEnumerable<PessoaEntity>> ListAsync([FromBody] PersonQuery personQuery)
        {
            try
            {
                IEnumerable <PessoaEntity> entities = await _personService.ListAsync(personQuery);
                return entities;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("combo")]
        public async Task<GenericResponse<IEnumerable<ComboItem>>> ComboItemAsync()
        {
            try
            {
                IEnumerable<ComboItem> comboitem = await _personService.ComboItem();
                return new GenericResponse<IEnumerable<ComboItem>>(comboitem).CreatedWithSucess();
            }
            catch (Exception e)
            {
                return new GenericResponse<IEnumerable<ComboItem>>().Error(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<GenericResponse<int>>Delete(int id)
        {
            try
            {
                int data = await _personService.DeleteAsync(id);
                return new GenericResponse<int>().CreatedWithSucess();
            }
            catch (Exception e)
            {
                return new GenericResponse<int>().Error(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
