namespace FactoryPattern;


interface IProduct
{
    string ShipFrom();
}


class ProductA : IProduct
{
    public string ShipFrom()
    {
        return " from South Africa";
    }
}

class ProductB : IProduct
{
    public string ShipFrom()
    {
        return " from Spain";
    }
}

class DefaultProduct : IProduct
{
    public string ShipFrom()
    {
        return "not available";
    }
}


class Creator
{
    public IProduct FactoryMethod(int month)
        => month switch
        {
            >= 4 and <= 11 => new ProductA(),
            1 or 2 or 12 => new ProductB(),
            _ => new DefaultProduct()
        };
}


class Program
{
    static void Main()
    {
        Creator c = new Creator();
        IProduct product;

        for (int i = 1; i <= 12; i++)
        {
            product = c.FactoryMethod(i);
            Console.WriteLine("Avocados " + product.ShipFrom());
        }
    }
}