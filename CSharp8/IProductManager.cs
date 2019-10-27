using System;

namespace CSharp8
{
    public interface IProductManager
    {
        public string GetSku();

        public string GetNamge() => "Sample Name";

        // Now interface can have fields, but have to be static
        private static readonly string name = "name from interface";
        public static readonly string sku = "sku from interface";

        // Now interface can have implemented methods
        public string GetProductInfo()
        => $"{name}: {sku}";

        public string GetProductInfo(string inputName, string inputSku)
        => $"{inputName}: {inputSku}";
    }

    public class ProductManager : IProductManager
    {
        public string GetSku() => "Sample Sku";
    }
}
