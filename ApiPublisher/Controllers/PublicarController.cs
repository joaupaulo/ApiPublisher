using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPublisher.Entidades;
using ApiPublisher.RabbitServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicarController : ControllerBase
    {
        private ILogger<PublicarController> _logger;
        private IMenssageService _imenssagemservice;
        
        public PublicarController(IMenssageService imenssagemservice)
        {
            _imenssagemservice = imenssagemservice;
        }


        public ActionResult InserirPedido(Produtos produto)
        {
            try
            {
                _imenssagemservice.ConnectMensage(produto);
                return Accepted(produto);
            } catch (Exception ex)
            {
                _logger.LogError("Erro ao tentar criar um novo pedido", ex);


                 return new StatusCodeResult(200);   
            }
        }

    }
}
