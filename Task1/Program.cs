public abstract class Logistics
{
	public void PlanDelivery() {
		ITransport t = CreateTransport();
		t.Deliver();
	}
	public abstract ITransport CreateTransport();
}

public class RoadLogistics: Logistics
{
    public override ITransport CreateTransport()
    {
		return new Truck();
	}
}

public class SeaLogistics : Logistics
{
	public override ITransport CreateTransport()
	{
		return new Ship();
	}
}

public class AirLogistics : Logistics
{
	public override ITransport CreateTransport()
	{
		return new Airplane();
	}
}

public interface ITransport
{
	void Deliver();
}

public class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivered by truck");
    }
}
public class Ship : ITransport
{
	public void Deliver()
	{
		Console.WriteLine("Delivered by Ship");
	}
}
public class Airplane : ITransport
{
	public void Deliver()
	{
		Console.WriteLine("Delivered by Airplane");
	}
}














class Program
{ // LogisticsApp in Refactoring Guru

	static void Main()
	{
		// Logistics logistics = new AirLogistics();
		// ITransport transport = logistics.CreateTransport();
		// transport.Deliver();

		Logistics? logistics = null;
		while (true)
		{
			Console.WriteLine(@"
							1: Road
							2: Sea
							3: Air
							Any: Exit");

			Console.Write("\n\tEnter choice: ");


			logistics = Console.ReadLine() switch
			{
				"1" => new RoadLogistics(),
				"2" => new SeaLogistics(),
				"3" => new AirLogistics(),
				_ => null
			};

			if (logistics == null)
				break;


			logistics?.PlanDelivery();
		}
	}
}