using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using calculadoraURL.Repositories;

namespace calculadoraURL.Controller
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        private readonly OperacoesRepository _repository;
        public OperacoesController(OperacoesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("lista")]
        public IActionResult operacoes()
        {
            return Ok(_repository.ListarOperacoes());
        }

        [HttpGet("soma/{num1}/{num2}")]
        public IActionResult somar(double num1, double num2)
        {
            return Ok(_repository.somar(num1, num2));
        }

        [HttpGet("subtracao/{num1}/{num2}")]
        public IActionResult subtracao(double num1, double num2)
        {
            return Ok(_repository.subtracao(num1, num2));
        }

        [HttpGet("multiplicacao/{num1}/{num2}")]
        public IActionResult multiplicacao(double num1, double num2)
        {
            return Ok(_repository.multiplicacao(num1, num2));
        }
        [HttpGet("divisao/{num1}/{num2}")]
        public IActionResult divisao(double num1, double num2)
        {
            return Ok(_repository.divisao(num1, num2));
        }
        [HttpGet("funcaoafim/{a:double}/{b:double}/{x:double?}")]
        public IActionResult funcaoAfim(double a, double b, double? x)
        {
            return Ok(_repository.funcaoAfim(a, b, x));
        }
        [HttpGet("funcaograu2/{a}/{b}/{c}")]
        public IActionResult funcaoGrau2(double a, double b, double c)
        {
            return Ok(_repository.funcao2grau(a, b, c));
        }
        [HttpGet("sobre")]
        public IActionResult sobre()
        {
            return Ok(_repository.Ajuda());
        }
    }

    
}
