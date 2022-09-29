using Library;
using System;
using System.Text.Json;

public class Program{
    static void Main(string[] args){

        DateTime naci = new DateTime(2022,05,10);
        Persona p1 = new Persona("54628979", "Roberto",naci);
        Console.ForegroundColor=ConsoleColor.Blue;
        var settings= new JsonSerializerOptions{ WriteIndented = true };
        var jsonstring = JsonSerializer.Serialize(p1, settings);
        Console.WriteLine(jsonstring);

        Persona p1deserializado = JsonSerializer.Deserialize<Persona>(jsonstring);
        Console.ForegroundColor=ConsoleColor.Red;
        Console.WriteLine(p1deserializado.cedula);
        Console.WriteLine(p1deserializado.nombre);
        Console.WriteLine(p1deserializado.nacimiento);

        Console.ForegroundColor=ConsoleColor.White;

    }
}