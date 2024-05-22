using System;
using System.Collections.Generic;

public class Shape
{
 
    private string color;


    public Shape(string color)
    {
        this.color = color;
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public virtual double GetArea()
    {
        return 0.0;
    }
}

public class Circle : Shape
{
    // Private member variable for the radius
    private double _radius;

    // Constructor that accepts the color and radius, and calls the base constructor with the color
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method to calculate the area of the circle
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

public class Square : Shape
{
    // Private member variable for the side length
    private double _side;

    // Constructor that accepts the color and side, and calls the base constructor with the color
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method to calculate the area of the square
    public override double GetArea()
    {
        return _side * _side;
    }
}

public class Rectangle : Shape
{
    // Private member variables for the length and width
    private double _length;
    private double _width;

    // Constructor that accepts the color, length, and width, and calls the base constructor with the color
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override the GetArea method to calculate the area of the rectangle
    public override double GetArea()
    {
        return _length * _width;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add a square, rectangle, and circle to the list
        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));

        // Iterate through the list of shapes and display the color and area for each
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}