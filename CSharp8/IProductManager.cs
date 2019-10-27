using System;

namespace CSharp8
{
    public interface IProductManager
    {
        public string GetSku();

        public string GetNamge() => "Sample Name";
    }

    public class ProductManager : IProductManager
    {
        public string GetSku() => "Sample Sku";
    }
}
