
namespace Ishopping.ViewModels.Admin
{
    public class AdminFinancialPlanViewModel
    {
        public int Id { get; set; }
        public int Cod { get; set; }                    // Identificação única
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Month { get; set; }

        // Configurações do plano
        public int Group { get; set; }
        public int Exhibition { get; set; }
        public int Gallery { get; set; }
        public int Products { get; set; }
        public int DataBase { get; set; }
    }
}