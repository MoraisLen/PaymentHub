using Microsoft.AspNetCore.Mvc;
using PaymentHub.Domain.Interface;
using PaymentHub.MercadoPago.Model;
using PaymentHub.MercadoPago.Model.Enum;

namespace PaymentHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PixController : ControllerBase
    {
        private IPixService _service;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public PixController(IPixService service)
        {
            _service = service;
        }

        /// <summary>
        /// Criar pagamento via PIX.
        /// </summary>
        /// <param name="request">Dados do pagamento.</param>
        /// <response code="201">Pagamento gerado.</response>
        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
        [HttpPost("CreateAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PreferenceModel))]
        public async Task<IActionResult> CreateAsync([FromBody] PaymentModel request)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Buscar pagamento via PIX.
        /// </summary>
        /// <response code="200">Resultado da consulta.</response>
        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
        [HttpGet("GetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PaymentDetailModel>))]
        public async Task<IActionResult> GetAsync([FromQuery] PaymentTypeStatusEnum? status = null)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(status));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Buscar pagamento via PIX por ID.
        /// </summary>
        /// <param name="Id">Id do pagamento.</param>
        /// <response code="200">Resultado da consulta.</response>
        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
        /// <response code="404">Nenhum resultado encontrado.</response>
        [HttpGet("GetAsync/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PaymentDetailModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromRoute] string Id)
        {
            try
            {
                PaymentDetailModel? result = await _service.GetAsync(Id);
                return StatusCode(result != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cancelar pagamento via PIX.
        /// </summary>
        /// <param name="Id">Id do pagamento.</param>
        /// <response code="200">Pagamento cancelado.</response>
        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
        /// <response code="404">Pagamento não encontrado.</response>
        [HttpPut("CancellAsync/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PaymentDetailModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancellAsync([FromRoute] string Id)
        {
            try
            {
                PaymentDetailModel? result = await _service.CancellAsync(Id);
                return StatusCode(result != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}