//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Heinekamp.Application.Interfaces;
//using Heinekamp.Application.Models;
//using Heinekamp.Application.Wrappers;
//using Heinekamp.Domain.Interfaces;
//using MediatR;
//using Microsoft.Extensions.Logging;

//namespace Heinekamp.Application.Features.Tariffs.Queries
//{
//    public class TariffCalculationHandler : IRequestHandler<GetTariffByConsumptionQuery, Response<List<Comparison>>>
//    {
//        private readonly ITariffProvider _tariffProvider;
//        private readonly ILogger<TariffCalculationHandler> _logger;

//        public TariffCalculationHandler(
//            ITariffProvider tariffProvider,
//            ILogger<TariffCalculationHandler> logger)
//        {
//            _tariffProvider = tariffProvider ?? throw new ArgumentNullException(nameof(tariffProvider));
//            _logger = logger;
//        }

//        public async Task<Response<List<Comparison>>> Handle(GetTariffByConsumptionQuery request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var products = await _tariffProvider.GetProducts();

//                if (products is null)
//                {
//                    _logger.LogWarning("Provider: {Provider} Failed to retrieve products from the tariff provider.", nameof(TariffCalculationHandler));
//                    return new Response<List<Comparison>>("Failed to retrieve products.");
//                }

//                var result = products
//                    .Select(t => new Comparison
//                    {
//                        TariffName = t.Name,
//                        AnnualCost = ((IProductStrategy)t).GetCalculationStrategy(request.ConsumptionKwh)
//                    })
//                    .ToList();

//                _logger.LogInformation("Tariff calculation completed successfully. Consumption: {Consumption}", request.ConsumptionKwh);
//                return new Response<List<Comparison>>(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "An error occurred during tariff calculation.");
//                return new Response<List<Comparison>>(ex.GetBaseException().Message);
//            }
//        }
//    }
//}
