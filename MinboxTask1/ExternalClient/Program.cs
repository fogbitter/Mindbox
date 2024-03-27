// See https://aka.ms/new-console-template for more information

using FigureService.Logics;
using FigureService.Models;

Console.WriteLine("Hello, World!");
var figureCollection = new List<BaseFigure>()
{
    Service.GetCircle(1),
    Service.GetCircle(2),
    Service.GetCircle(3),
    Service.GetTriangle(1,2,3),
    Service.GetTriangle(2,3,4),
    Service.GetTriangle(4,3,4),
    Service.GetTriangle(3,4,5),
};

foreach(var figure in figureCollection)
{
    Console.WriteLine($"{figure}, area : {figure.GetArea().ToString("0.000")}");
}
Console.ReadLine();

