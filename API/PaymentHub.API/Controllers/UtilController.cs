//using Microsoft.AspNetCore.Mvc;
//using Payment.Business.Service;
//using PaymentHub.Business.Model;

//namespace PaymentHub.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    public class UtilController : ControllerBase
//    {
//        private UtilService _service;

//        /// <summary>
//        /// Construtor da classe.
//        /// </summary>
//        public UtilController(UtilService service)
//        {
//            _service = service;
//        }

//        /// <summary>
//        /// Retorna os métodos de pagamento.
//        /// </summary>
//        /// <response code="200">Lista carregada com sucesso.</response>
//        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
//        [HttpGet("GetPaymentMethodsAsync")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PaymentMethodModel>))]
//        public async Task<IActionResult> GetPaymentMethodsAsync()
//        {
//            try
//            {
//                return Ok(await _service.GetPaymentMethodsAsync());
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }
//    }
//}