using EDSystems.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDSystems.WebApi.Controllers
{
    /// <summary>
    /// Class
    /// </summary>

    [AllowAnonymous]
    public class ExchangeRateController : BaseController
    {
        private readonly IGetExchangeRateService _getExchangeRateService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="getExchangeRateService"></param>
        public ExchangeRateController(IGetExchangeRateService getExchangeRateService) => (_getExchangeRateService) = (getExchangeRateService);

        /// <summary>
        /// Gets Exchange Rate of Rubl
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">If the user is unauthorized</responce>
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetRub()
        {
            var responseBody = await _getExchangeRateService.Handle("RUB");
            return Ok(responseBody);
        }

        /// <summary>
        /// Gets Exchange Rate of Usd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetUsd()
        {
            var responseBody = await _getExchangeRateService.Handle("USD");
            return Ok(responseBody);
        }
    }
}