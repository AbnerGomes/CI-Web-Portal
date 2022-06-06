using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CofreInteligente.Models;
using CofreInteligente.Service;






namespace CofreInteligente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositoController : ControllerBase
    {

        private readonly DepositoService _service;

        public DepositoController()
        {
            _service = new DepositoService();
        }

        //TODOS OS DEPOSITOS
        [HttpGet]
        public List<Deposito> GetDepositos()
        {                        
            return _service.getDepositos();           
        }

        //DEPOSITO POR ID
        [HttpGet("{id}")]
        public Deposito GetDeposito(int id)
        {                        
            return _service.getDepositoById(id);           
        }

        //CADASTRAR DEPOSITO
        [HttpPost]
        public string InsertDeposito(Deposito dep)
        {                     
            return  _service.insertDeposito(dep) == 1 ? "INSERIDO COM SUCESSO! "  : "ERRO AO CADASTRAR.";           
        }

        //ALTERAR DEPOSITO
        [HttpPut]
        public Deposito UpdateDeposito(Deposito dep)
        {                    
            return _service.updateDeposito(dep) ;           
        }

        //DELETAR DEPOSITO
        [HttpDelete("{id}")]
        public string DeleteDeposito(int id)
        {                     
            return _service.deleteDeposito(id) == 1 ?  "DELETADO COM SUCESSO!" : "DEPOSITO NAO ENCONTRADO.";           
        }
    }
}