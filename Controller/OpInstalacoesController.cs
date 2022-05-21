using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using calculadoraURL.Repositories;

namespace calculadoraURL.Controller
{
    [Produces("application/json")]

    [Route("")]
    [ApiController]
    public class OpInstalacoesController : ControllerBase
    {
        private readonly OperacoesDeInstalacoesRepository _operacoes;
        public OpInstalacoesController(OperacoesDeInstalacoesRepository operacoes)
        {
            _operacoes = operacoes;
        }

        //Não se usa no endpoint entre parênteses do get, put e outros, caracteres maiúsculos,pois dá erro.

        [HttpGet]
        public IActionResult autoria()
        {
            return Ok(_operacoes.Autoria()+" Digite na url: /ajuda");
        }
        [HttpGet("ajuda")]
        public IActionResult Sobre()
        {
            return Ok(_operacoes.sobre());
        }
        [HttpGet("diametro/{q}/{v}/{unidademedidaq}/{densidade:double?}")]
        public IActionResult Diametro(double q, double v, string unidademedidaq, string? densidade)
        {

            return Ok(_operacoes.DiametroTubulacao(q, v, unidademedidaq, densidade));
        }

        [HttpGet("hu/{q}/{d}/{constante}")]
        public IActionResult PerdaCargaUnitaria(double q, double d, string constante)
        {
            return Ok(_operacoes.PerdaCargaUnitaria(q, d, constante));
        }
        [HttpGet("httubulacaoreta/{hu}/{l}")]
        public IActionResult PerdaCargaTotal1(double hu, double l)
        {
            return Ok(_operacoes.PercaCargaTotalTubulacaoReta(hu, l));
        }
        [HttpGet("httubulacaods/{hu}/{l1}/{l2}/{l3}/{dl}")]
        public IActionResult PerdaCargaTotal1(double hu, double l1, double l2, double l3, double dl)
        {
            return Ok(_operacoes.PercaCargaTotalTubulacaoDescontinua(hu, l1, l2, l3, dl));
        }
        [HttpGet("httubulacaoinc/{hu}/{l}/{dl}")]
        public IActionResult PerdaCargaTotal1(double hu, double l, double dl)
        {
            return Ok(_operacoes.PercaCargaTotalTubulacaoInclinada(hu, l, dl));
        }
        [HttpGet("trgco/{angulo}/{co}/{hi:double?}")]
        public IActionResult TrogonometriaCo(double angulo, double co, double? hi)
        {
            return Ok(_operacoes.TrgCo(angulo, co, hi));
        }
        [HttpGet("trgca/{angulo}/{ca}/{hi:double?}")]
        public IActionResult TrogonometriaCa(double angulo, double ca, double? hi)
        {
            return Ok(_operacoes.TrgCa(angulo, ca, hi));
        }
        [HttpGet("trghi/{angulo}/{hi}/{ca:double?}")]
        public IActionResult TrogonometriaHi(double angulo, double hi, double? ca)
        {
            return Ok(_operacoes.TrgHi(angulo, hi, ca));
        }
    }
}
