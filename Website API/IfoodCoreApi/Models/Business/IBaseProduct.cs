using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodCoreApi.Models.Business
{
    public interface IBaseProduct
    {
        string Name { get; }
        string Description { get; }
        decimal Price { get; }
        byte[] ProductImage { get; }
    }
}
