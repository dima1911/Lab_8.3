using System;

// Інтерфейси для компонентів
abstract class Screen
{
    public abstract void Display();
}

abstract class Processor
{
    public abstract void Process();
}

abstract class Camera
{
    public abstract void Capture();
}

// Реалізації компонентів
class OLED : Screen
{
    public override void Display()
    {
        Console.WriteLine("OLED Screen Displaying...");
    }
}

class Snapdragon : Processor
{
    public override void Process()
    {
        Console.WriteLine("Snapdragon Processor Processing...");
    }
}

class DualCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Dual Camera Capturing...");
    }
}

// Абстрактна фабрика для створення компонентів
abstract class TechComponentFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}
class SmartphoneFactory : TechComponentFactory
{
    public override Screen CreateScreen()
    {
        return new OLED();
    }

    public override Processor CreateProcessor()
    {
        return new Snapdragon();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

class LaptopFactory : TechComponentFactory
{
    public override Screen CreateScreen()
    {
        return new OLED();
    }

    public override Processor CreateProcessor()
    {
        return new Snapdragon();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

class TabletFactory : TechComponentFactory
{
    public override Screen CreateScreen()
    {
        return new OLED();
    }

    public override Processor CreateProcessor()
    {
        return new Snapdragon();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

// Клас продукту
class TechProduct
{
    public Screen Screen { get; set; }
    public Processor Processor { get; set; }
    public Camera Camera { get; set; }

    public void Assemble()
    {
        Screen.Display();
        Processor.Process();
        Camera.Capture();
        Console.WriteLine("Tech product assembled.");
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter the type of product (smartphone/laptop/tablet): ");
        string productType = Console.ReadLine().ToLower();

        TechComponentFactory factory;

        switch (productType)
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            case "tablet":
                factory = new TabletFactory();
                break;
            default:
                Console.WriteLine("Invalid product type.");
                return;
        }

        // Використання фабрики для створення компонентів та збірки продукту
        TechProduct product = new TechProduct
        {
            Screen = factory.CreateScreen(),
            Processor = factory.CreateProcessor(),
            Camera = factory.CreateCamera()
        };

        product.Assemble();
    }
}
