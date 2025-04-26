//using Microsoft.AspNetCore.Mvc;
//using Payment.Business.Service;
//using PaymentHub.MercadoPago.Model;

//namespace PaymentHub.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    public class PreferenceController : ControllerBase
//    {
//        private PreferenceService _service;

//        /// <summary>
//        /// Construtor da classe.
//        /// </summary>
//        public PreferenceController(PreferenceService service)
//        {
//            _service = service;
//        }

//        /// <summary>
//        /// Criação de pagamento via plataforma do Mercado Pago.
//        /// </summary>
//        /// <param name="request">Dados do pagamento.</param>
//        /// <response code="201">Pagamento gerado.</response>
//        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
//        [HttpPost("CreateAsync")]
//        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PreferenceModel))]
//        public async Task<IActionResult> CreateAsync([FromBody] PreferenceModel request)
//        {
//            try
//            {
//                return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request));
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }

//        /// <summary>
//        /// Busca pagamentos registrados.
//        /// </summary>
//        /// <response code="200">Resultado da consulta.</response>
//        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
//        [HttpGet("GetAsync")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PreferenceItemModel))]
//        public async Task<IActionResult> GetAsync()
//        {
//            try
//            {
//                return StatusCode(StatusCodes.Status200OK, await _service.SearchPreference());
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }

//        /// <summary>
//        /// Busca pagamento por Id.
//        /// </summary>
//        /// <param name="Id">Id do pagamento.</param>
//        /// <response code="200">Resultado da consulta.</response>
//        /// <response code="404">Nenhum resultado encontrado.</response>
//        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
//        [HttpGet("GetAsync/{Id}")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PreferenceModel))]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<IActionResult> GetAsync([FromRoute] string Id)
//        {
//            try
//            {
//                PreferenceModel? result = await _service.SearchPreference(Id);
//                return StatusCode(result != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, result);
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }
//    }
//}