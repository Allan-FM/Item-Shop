namespace Loja_De_Items
{
    public class Item
    {
        public string Name {get; private set;}
        public int Price {get; private set;}

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}