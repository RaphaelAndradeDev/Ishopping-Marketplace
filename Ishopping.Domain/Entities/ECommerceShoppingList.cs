using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class ECommerceShoppingList
    {
        public Guid Id { get; set; }
        public bool PagPendente { get; set; }               // PS Aguardando pagamento: o comprador iniciou a transação, mas até o momento o PagSeguro não recebeu nenhuma informação sobre o pagamento. Exibe também a data que a compra foi finalizada
        public DateTime DataPagPendente { get; set; }
        public bool PagPreAprovado { get; set; }            // PS Em análise: o comprador optou por pagar com um cartão de crédito e o PagSeguro está analisando o risco da transação.
        public DateTime DataPagPreAprovado { get; set; }
        public bool PagAprovado { get; set; }               // PS Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.
        public DateTime DataPagAprovado { get; set; }
        public bool ProdEnviado { get; set; }               // O produto foi enviado.
        public DateTime DataProdEnviado { get; set; }
        public bool ProdDisponivel { get; set; }            // PS Disponível: a transação foi paga e chegou ao final de seu prazo de liberação sem ter sido retornada e sem que haja nenhuma disputa aberta.
        public DateTime DataProdDisponivel { get; set; }
        public bool ProdEntregue { get; set; }              //  O produto foi entregue ao seu destino ou está aguardando a retirada 
        public DateTime DataProdEntregue { get; set; }
        public bool ProdRecebido { get; set; }              // se o cliente recebeu o produto ou recusou
        public DateTime DataProdRecebido { get; set; }
        public string ProdRecusObs { get; set; }            // motivo pelo qual o cliente nao recebeu o produto
        public bool EmDisputa { get; set; }                 // PS Em disputa: o comprador, dentro do prazo de liberação da transação, abriu uma disputa.
        public DateTime DataEmDisputa { get; set; }
        public bool PagDevolvido { get; set; }              // PS Devolvida: o valor da transação foi devolvido para o comprador.
        public DateTime DataPagDevolvido { get; set; }
        public bool TranCancelada { get; set; }             // PS Cancelada: a transação foi cancelada sem ter sido finalizada.
        public DateTime DataTranCancelada { get; set; }
        public int CodStatus { get; set; }
        public string Status { get; set; }                  // Status atual da lista
        public string CodRastreamento { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorTotal { get; set; }
        public bool CompraFinalizada { get; set; }
        public DateTime DataComFinalizada { get; set; }
        public string Erro { get; set; }                    // Acusa algum erro referente a notificações da transação
        public Guid UserRegisterProfileId { get; set; }
        public virtual UserRegisterProfile UserRegisterProfile { get; set; }
        public Guid UserRegisterStandardId { get; set; }
        public virtual UserRegisterStandard UserRegisterStandard { get; set; }
        public IList<ECommerceProductSold> ECommerceProductSold { get; set; }
    }
}
