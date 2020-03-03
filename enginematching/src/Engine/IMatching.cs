using System;
namespace Engine
{
    public interface IMatching
    {
        // Sell trade
         void SellTrade();
        // chek the validity of the Trade
        bool IsTrade();
        bool IsValidOrder(string operation, string[] operation_statement_array);
        // return a minimum between two integers
         int ReturnLeastNumber(int a, int b);
        // Modify Table
         void ModifyOrder(IOrder order, int numTraded);
        // Convert a cuurent Devise to Dollar Devise
        decimal CovertToDollar(IOrder order);
        void WriteTradeTable();
        void WriteOrderBookCollection();
        void ModifyOrder(string[] stdInputArgumentsArray);
        void PrintOperation();
        void GeneratePrintTable();

    }
}
