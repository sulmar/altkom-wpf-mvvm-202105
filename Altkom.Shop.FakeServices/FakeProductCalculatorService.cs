using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Shop.FakeServices
{
    public class FakeProductCalculatorService : IProductCalculatorService
    {
        public decimal Calculate(IEnumerable<Product> products, CancellationToken cancellationToken, IProgress<int> progress = null)
        {
            decimal result = 0;

            int counter = 0;

            foreach (var product in products)
            {
                //if (cancellationToken.IsCancellationRequested)
                //{
                //    break;
                //}

                //if (cancellationToken.IsCancellationRequested)
                //{
                //    throw new OperationCanceledException();
                //}

                cancellationToken.ThrowIfCancellationRequested();

                result += product.UnitPrice;

                

                Thread.Sleep(TimeSpan.FromSeconds(1));

                progress?.Report(++counter);
            }

            return result;
        }

        public Task<decimal> CalculateAsync(IEnumerable<Product> products, CancellationToken cancellationToken, IProgress<int> progress = null)
        {
            return Task.Run(()=> Calculate(products, cancellationToken, progress));
        }
    }
}
