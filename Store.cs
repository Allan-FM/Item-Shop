using System;
using System.Collections.Generic;

namespace Loja_De_Items
{
    public class Store
    {
        private List<Item> items;
        public Store()
        {
            items = new List<Item>()
            {
                new Item("Pao de queijo", 1),
                new Item("Batata", 2),
                new Item("Refrigerante", 2)
            };
        }
        public void Greetings()
        {
            PrintLineAndWait("Bem vindo a nossa loja!");
            PrintLineAndWait("Eu vejo que voce tem muitos coins com voce...");
            PrintLineAndWait("Hmmm... voce quer dar uma olhada no nosso inventario? Sim ou sim? :)");
        }
        public void ExecuteStoreLoop(Player player)
        {
            while(player.CanBuyAny(items))
            {
                PrintStoreOptions();
                Item item = ReadItem("Digite o numero do item que voce deseja comprar -> ");
                if(player.TryPusheadItem(item))
                {
                    Console.WriteLine();
                    PrintLineAndWait($"Voce comprou {item.Name} por ${item.Price}. Voce tem ${player.Money} coins");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    PrintLineAndWait($"Esse item custa {item.Price} e voce so tem ${player.Money} coins");
                    Console.WriteLine();
                }
            }
        }
        public void End(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("Voce nao consegue comprar mais nada! Esse sao seus items: ");
            PrintSeparator();
            player.PrintPlayerItems();

            PrintSeparator();

            PrintLineAndWait("FIM!");

        }
        private int ReadNumber(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            int number;
            if(int.TryParse(input, out number))
            {
                return number;
            }
            return -1;
        }
        private Item ReadItem(string message)
        {
            int index = ReadNumber(message);
            index -= 1;
            while(index < 0 || index >= items.Count)
            {
                Console.WriteLine("Eu nao conheco esse item! Voce nao sai daqui ate comprar!!!");
                index = ReadNumber(message);
                index -= 1;
            }
            return items[index];
        }

        private void PrintLineAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
        private void PrintStoreOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Essas sao nossas opcoes: ");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {items[i].Name} - ${items[i].Price}");
            }
        }
        public void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine();
        }
    }
}