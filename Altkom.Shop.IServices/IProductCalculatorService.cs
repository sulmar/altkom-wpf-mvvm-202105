using Altkom.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Shop.IServices
{
    public interface IProductCalculatorService
    {
        decimal Calculate(IEnumerable<Product> products, CancellationToken cancellationToken = default, IProgress<int> progress = null);

        Task<decimal> CalculateAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default, IProgress<int> progress = null);
    }
}
