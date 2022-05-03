using System;

namespace Loja_De_Items
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5);
            var Store = new Store();

            Store.Greetings();

            Store.ExecuteStoreLoop(player);

            Store.End(player);

        }
    }
}
