using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Interfaces;
using Vectra.Avaliacao.BLL.Interfaces;
using Vectra.Avaliacao.Commons.Entities;
using Vectra.Avaliacao.Commons.Exceptions;

namespace Vectra.Avaliacao.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasBLL contasBLL;
        private readonly IResponse response;

        public ContasController(IContasBLL contasBLL, IResponse response)
        {
            this.contasBLL = contasBLL;
            this.response = response;
        }

        // GET: api/<ContasController>
        [HttpGet]
        public async Task<ActionResult<IResponse>> Get(CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Conta> data = await contasBLL.GetAll(cancellationToken);
                return Ok(await this.response.GenerateResponse(statusCode: HttpStatusCode.OK, data: data));
            }
            catch (BusinessRuleException ex)
            {
                IResponse resp = await this.response.GenerateResponse(statusCode: HttpStatusCode.BadRequest);
                resp.AddErrorMessages(ex.Message);
                return BadRequest(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // GET api/<ContasController>/5W
        [HttpGet("{id}")]
        public async Task<ActionResult<IResponse>> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                Conta data = await contasBLL.GetById(id, cancellationToken);
                return Ok(await this.response.GenerateResponse(statusCode: HttpStatusCode.OK, data: data));
            }
            catch (BusinessRuleException ex)
            {
                IResponse resp = await this.response.GenerateResponse(statusCode: HttpStatusCode.BadRequest);
                resp.AddErrorMessages(ex.Message);
                return BadRequest(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // POST api/<ContasController>
        [HttpPost]
        public async Task<ActionResult<IResponse>> Post([FromBody] Conta conta, CancellationToken cancellationToken)
        {
            try
            {
                var changes = await contasBLL.Create(conta, cancellationToken);
                string message = changes <= 0 ? "Ocorreu um erro ao tentar criar a conta" : "Operação realizada com sucesso";
                return Ok(await this.response.GenerateResponse(statusCode: HttpStatusCode.OK, hasError: changes <= 0, message, null));
            }
            catch (BusinessRuleException ex)
            {
                IResponse resp = await this.response.GenerateResponse(statusCode: HttpStatusCode.BadRequest);
                resp.AddErrorMessages(ex.Message);
                return BadRequest(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // PUT api/<ContasController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IResponse>> Put(int id, [FromBody] Conta conta, CancellationToken cancellationToken)
        {
            try
            {
                var changes = await contasBLL.Update(id, conta, cancellationToken);
                string message = changes <= 0 ? "Ocorreu um erro ao tentar alterar a conta" : "Operação realizada com sucesso";
                return Ok(await this.response.GenerateResponse(statusCode: HttpStatusCode.OK, hasError: changes <= 0, message, null));
            }
            catch (BusinessRuleException ex)
            {
                IResponse resp = await this.response.GenerateResponse(statusCode: HttpStatusCode.BadRequest);
                resp.AddErrorMessages(ex.Message);
                return BadRequest(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // DELETE api/<ContasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var changes = await contasBLL.Delete(id, cancellationToken);
                string message = changes <= 0 ? "Ocorreu um erro ao tentar apagar a conta" : "Operação realizada com sucesso";
                return Ok(await this.response.GenerateResponse(statusCode: HttpStatusCode.OK, hasError: changes <= 0, message, null));
            }
            catch (BusinessRuleException ex)
            {
                IResponse resp = await this.response.GenerateResponse(statusCode: HttpStatusCode.BadRequest);
                resp.AddErrorMessages(ex.Message);
                return BadRequest(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
    }
}
