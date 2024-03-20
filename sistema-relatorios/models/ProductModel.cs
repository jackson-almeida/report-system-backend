using sistema_relatorios.models;
using System.ComponentModel.DataAnnotations;

namespace sistema_relatorios.models
{
    public class ProductModel
    {
        [Key]
        public int Code {  get; set; }
        public string Name { get; set; }
        public double CustPrice { get; set; }
        public double Markup { get; set; }
        public double CustSale { get; set; }
        public double RealMargin { get; set; }
        public int TaxRuleCode { get; set; }
        //public TaxRuleModel TaxRule { get; set; }
    }
}
