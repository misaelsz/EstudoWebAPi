

using apiCrud.bo.Banco;
using apiCrud.bo.negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aula02Marth.Controllers
{
    public class PessoaController : ApiController
    {
        // GET: api/Pessoa
        public HttpResponseMessage Get()
        { 
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, PessoaNegocio.ListarTodos());
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Pessoa/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, PessoaNegocio.ListaPorID(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetPessoas(string nome)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, PessoaNegocio.ListarPorNome(nome));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST: api/Pessoa
        public HttpResponseMessage Post([FromBody]pessoa value)
        {
            try
            {
                value.id = Guid.NewGuid();
                bool retorno = PessoaNegocio.AddPessoa(value);
                if (retorno == false) {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT: api/Pessoa/5
        public HttpResponseMessage Put(Guid id, [FromBody]pessoa value)
        {
            try
            {
                PessoaNegocio.EditaPessoa(id, value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/Pessoa/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                PessoaNegocio.RemovePessoa(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
