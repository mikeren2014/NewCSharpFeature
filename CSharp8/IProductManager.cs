using System;

namespace CSharp8
{
    public interface IProductManager
    {
        string GetSku();

        public string GetNamge() => "Sample Name";

        // Now interface can have fields, but have to be static
        private static string name = "name from interface";

        public static string sku = "sku from interface";

        public static void SetNameAndSku(string name, string sku)
        { 
            
        }

        // Now interface can have implemented methods
        public static string GetProductInfo()
        { 
           return $"{name}: {sku}";
        }


        public string GetProductInfo(string inputName, string inputSku)
        => $"{inputName}: {inputSku}";
    }

    public class ProductManager : IProductManager
    {

        public string GetProductInfo(string inputName, string inputSku)
        {
            //IProductManager.GetProductInfo
            return string.Empty;
        }

        public string GetSku()
        {
            throw new NotImplementedException();
        }
    }
}
