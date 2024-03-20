using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sistema_relatorios.models
{
    public class TaxRuleModel
    {
        [Key]
        public int? Code { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        
    }
}
