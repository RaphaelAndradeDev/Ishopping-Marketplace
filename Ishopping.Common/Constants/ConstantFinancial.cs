using Ishopping.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Common.Constants
{
    public static class ConstantFinancial
    {
        public static int GetDefaultPlan(int value)
        {
            switch (value)
            {
                case 1:
                    return 111;
                case 2:
                    return 222;
                case 3:
                    return 333;
                case 4:
                    return 444;
                case 5:
                    return 555;
                default:
                    return value;
            }
        }

        public enum Transaction
        {
            Insufficient,           // Insuficiente: Houve uma troca de plano e o valor do saldo atual do cliente era inferior ao valor do plano
            Pendent,                // Aguardando pagamento: o comprador iniciou a transação, mas até o momento o PagSeguro não recebeu nenhuma informação sobre o pagamento.
            PreApproved,            // Em análise: o comprador optou por pagar com um cartão de crédito e o PagSeguro está analisando o risco da transação.
            Approved,               // Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.            
            Contested,              // Em disputa: o comprador, dentro do prazo de liberação da transação, abriu uma disputa.
            Restored,               // Devolvida: o valor da transação foi devolvido para o comprador.
            Canceled,               // Cancelada: a transação foi cancelada sem ter sido finalizada.
            Debited,                // Debitado: o valor da transação foi devolvido para o comprador.
            Retained,               // Retenção temporária: o comprador contestou o pagamento junto à operadora do cartão de crédito ou abriu uma demanda judicial ou administrativa (Procon).
            NotApproved,            // A transação não foi aprovada
            Deducted,               // Deduzida: Houve uma troca de plano e o valor do saldo atual do cliente era igual ou superior ao valor do plano
            Warranted               // Garantido, geralamente usádo para planos gratuitos 
        }

        public enum Company
        {
            None,
            UolPagSeguro 
        }

        public enum TransactionFor
        {
            Internal = 1,       //Profiles do Ishopping 
            External = 2        //Lojas virtual
        }

        public static string GetCompany(int company)
        {
            switch (company)
            {
                case 0:
                    return "Sem financeira";
                case 1:
                    return "Uol PagSeguro";
                default:
                    return "Indefinida";
            }
        }

        public static string GetStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return Messages.Msg10000;
                case 1:
                    return Messages.Msg10001;
                case 2:
                    return Messages.Msg10002;
                case 3:
                    return Messages.Msg10003;
                case 4:
                    return Messages.Msg10004;
                case 5:
                    return Messages.Msg10005;
                case 6:
                    return Messages.Msg10006;
                case 7:
                    return Messages.Msg10007;
                case 8:
                    return Messages.Msg10008;
                case 9:
                    return Messages.Msg10009;
                case 10:
                    return Messages.Msg10010;
                default:
                    return Messages.Msg10011;
            }
        }

        public static string GetStatusDetails(int status)
        {
            switch (status)
            {
                case 0:
                    return Messages.Msg10000;
                case 1:
                    return Messages.Msg10001;
                case 2:
                    return Messages.Msg10002;
                case 3:
                    return Messages.Msg10003;
                case 4:
                    return Messages.Msg10004;
                case 5:
                    return Messages.Msg10005;
                case 6:
                    return Messages.Msg10006;
                case 7:
                    return Messages.Msg10007;
                case 8:
                    return Messages.Msg10008;
                case 9:
                    return Messages.Msg10009;
                case 10:
                    return Messages.Msg10010;
                default:
                    return Messages.Msg10011;
            }
        }


    }
}
