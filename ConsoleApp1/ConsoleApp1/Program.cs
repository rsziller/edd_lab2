using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



namespace ConsoleApp1
{
    

    public class Program
    {

        


        public interface IPlace
        {
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }

        }

        public class House : IPlace
        {
            public string zoneDangerous { get; set; }
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }
        }

        public class Apartment : IPlace
        {
            public bool isPetFriendly { get; set; }
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }
        }

        public class Premise : IPlace
        {
            public List<string> commercialActivities { get; set; }
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }
        }

        public class Input2
        {
            public List<string> requiredServices { get; set; }
            public string typeBuilder { get; set; }
            public string minDanger { get; set; }
            public bool wannaPetFriendly { get; set; }
            public string commercialActivity { get; set; }
            public double budget { get; set; }
        }


        public class Builds
        {
            public List<House> Houses { get; set; }
            public List<Apartment> Apartments { get; set; }
            public List<Premise> Premises { get; set; }
        }

        public class Service 
        {
            public Dictionary<string, bool> services { get; set; }

           
        }

        public class Input1
        {

            public Dictionary<string, bool> services { get; set; }
            public Builds builds { get; set; }

        }


        public class InputLab
        {

            public List<Input1> input1 { get; set; }
            public Input2 input2 { get; set; }
        }

        

        public static void Main()
        {
            string text = File.ReadAllText(@"C:\Users\Rolando Ziller\Documents\Universidad\2023\Estructuras\lab2\edd_lab2\ConsoleApp1\ConsoleApp1\datos\input_challenge_2.jsonl");
            string[] words = text.Split('\n');

            for (int i = 0; i < words.Length; i++)
            {

                InputLab input = JsonSerializer.Deserialize<InputLab>(words[i])!;
                int sector = 0;
                int casa;
                int apartamento;
                int local;
                Console.WriteLine(input);
                foreach (Input1 itemInput1 in input.input1)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"sector: {sector}");
                    Console.WriteLine("-----------------------------------");
                    foreach (KeyValuePair<string, bool> entry in itemInput1.services)
                    {
                        Console.WriteLine("servicios");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine($"key {entry.Key} - value {entry.Value}");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("casas");
                    Console.WriteLine("-----------------------------------");

                    if (itemInput1.builds.Houses != null)
                    {
                        casa = 0;
                        foreach (House itemHouse in itemInput1.builds.Houses)
                        {
                            Console.WriteLine($"casa: {casa}");

                            Console.WriteLine($"zona de peligro: {itemHouse.zoneDangerous}" +" "+ $"direccion: {itemHouse.address}" + " " + $"precio: {itemHouse.price}" + " " + $"telefono de contacto: {itemHouse.contactPhone}" + " " + $"id: {itemHouse.id}");
                            casa++;

                        }

                        
                    }
                    Console.WriteLine("");
                    Console.WriteLine("apartamentos");
                    Console.WriteLine("-----------------------------------");

                    if (itemInput1.builds.Apartments != null)
                    {
                        apartamento = 0;
                        foreach (Apartment itemApartment in itemInput1.builds.Apartments)
                        {
                            Console.WriteLine($"apartamento: {apartamento}");

                            Console.WriteLine($"amigable con los animales: {itemApartment.isPetFriendly}" + " " + $"direccion: {itemApartment.address}" + " " + $"precio: {itemApartment.price}" + " " + $"telefono de contacto: {itemApartment.contactPhone}" + " " + $"id: {itemApartment.id}");
                            apartamento++;

                        }


                    }
                    Console.WriteLine("");
                    Console.WriteLine("locales");
                    Console.WriteLine("-----------------------------------");

                    if (itemInput1.builds.Premises != null)
                    {
                        local = 0;
                        foreach (Premise itemPremise in itemInput1.builds.Premises)
                        {
                            Console.WriteLine($"local: {local}");

                            Console.Write("actividades comerciales: ");
                            foreach (var item in itemPremise.commercialActivities)
                            {
                                Console.Write(item +" ");

                            }
                            Console.WriteLine( $"direccion: {itemPremise.address}" + " " + $"precio: {itemPremise.price}" + " " + $"telefono de contacto: {itemPremise.contactPhone}" + " " + $"id: {itemPremise.id}") ;
                            local++;

                        }


                    }


                    sector++;
                }

                Console.WriteLine("");
                Console.WriteLine("requerimientos");
                Console.WriteLine("-----------------------------------");

                Console.Write($"requirement servicios: ");
                foreach (string requirement in input.input2.requiredServices)
                {
                    Console.Write(requirement+" ");
                }
                Console.WriteLine("");
                Console.WriteLine($"requirement tipo de construccion: {input.input2.typeBuilder}");
                Console.WriteLine($"requirement peligro: {input.input2.minDanger}");
                Console.WriteLine($"requirement mascotas: {input.input2.wannaPetFriendly}");
                Console.WriteLine($"requirement actividad comercial: {input.input2.commercialActivity}");
                Console.WriteLine($"requirement presupuesto: {input.input2.budget}");



            }


        }
    }
}
