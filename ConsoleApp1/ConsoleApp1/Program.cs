using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;



namespace ConsoleApp1
{
    

    public class Program
    {
        delegate bool CallbackA(bool x, double  y, double budget, bool wantsPetFriendly);

        delegate bool CallbackH(string x, double y, double budget, string wantsDanger);

        delegate bool CallbackP(List<string> x, double y, double budget, string wantsPymes);

        public static Dictionary<string, double> resultsApartments = new Dictionary<string, double>();

        public static Dictionary<string, double> resultsHouses = new Dictionary<string, double>();

        public static Dictionary<string, double> resultsPremises = new Dictionary<string, double>();

        static bool IsPetFriendly(bool x, double y, double budget, bool wantsPetFriendly) => x == wantsPetFriendly && y <= budget;
        static bool IsOkDanger(string x, double y, double budget, string wantsDanger)
        {
            return wantsDanger == "Green" ? doSomentingGreen(x) && y <= budget : wantsDanger == "Yellow" ? doSomentingYellow(x) && y <= budget : wantsDanger == "Orange" ? doSomentingOrange(x) && y <= budget : doSomentingRed(x) && y <= budget;
        }

        static bool IsPymesAllow(List<string> x, double y, double budget, string wantsPymes) => x.Contains(wantsPymes) && y <= budget;

        static Dictionary<string, double> FilterA(List<Apartment> numbers, double budget, bool wantsPetFriendly, CallbackA callback)
        {
            

            foreach (var number in numbers)
            {
                if (callback(number.isPetFriendly, number.price, budget, wantsPetFriendly))
                {
                    resultsApartments.Add(number.id, number.price);
                }
            }

            return resultsApartments;
        }

        

        static Dictionary<string, double> FilterH(List<House> numbers, double budget, string wantsDanger, CallbackH callback)
        {


            foreach (var number in numbers)
            {
                if (callback(number.zoneDangerous, number.price, budget, wantsDanger))
                {
                    resultsHouses.Add(number.id, number.price);
                }

            }

            return resultsHouses;
        }

        static Dictionary<string, double> FilterP(List<Premise> numbers, double budget, string wantsPymes, CallbackP callback)
        {


            foreach (var number in numbers)
            {
                if (callback(number.commercialActivities, number.price, budget, wantsPymes))
                {
                    resultsPremises.Add(number.id, number.price);
                }

            }

            return resultsPremises;
        }
        private static bool doSomentingGreen(string color)
        {
            if (color == "Green")
            {
                return true;
            }
            else if (color == "Yellow" )
            {
                return true;
            }
            else if (color == "Orange")
            {
                return true;
            }
            else if (color == "Red")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool doSomentingYellow(string color)
        {
            if (color == "Yellow")
            {
                return true;
            }
            else if (color == "Orange")
            {
                return true;
            }
            else if (color == "Red")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool doSomentingOrange(string color)
        {
            if (color == "Orange")
            {
                return true;
            }
            else if (color == "Red")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool doSomentingRed(string color)
        {
            if (color == "Red")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
            string text = File.ReadAllText(@"C:\Users\Rolando Ziller\Documents\Universidad\2023\Estructuras\lab2\edd_lab2\ConsoleApp1\ConsoleApp1\datos\input_challenge_lab_2.jsonl");
            string[] words = text.Split('\n');

            for (int i = 0; i < words.Length; i++)
            {

                InputLab input = JsonSerializer.Deserialize<InputLab>(words[i])!;
                int sector = 1;
                int casa;
                int apartamento;
                int local;
                //Console.WriteLine(input);
                foreach (Input1 itemInput1 in input.input1)
                {
                    //Console.WriteLine("");
                    //Console.WriteLine($"sector: {sector}");
                    //Console.WriteLine("-----------------------------------");
                    foreach (KeyValuePair<string, bool> entry in itemInput1.services)
                    {
                        //Console.WriteLine("servicios");
                        //Console.WriteLine("-----------------------------------");
                        //Console.WriteLine($"key {entry.Key} - value {entry.Value}");
                    }
                    //Console.WriteLine("");
                    //Console.WriteLine("casas");
                    //Console.WriteLine("-----------------------------------");

                    if (itemInput1.builds.Houses != null)
                    {
                        casa = 1;
                        foreach (House itemHouse in itemInput1.builds.Houses)
                        {
                            //Console.WriteLine($"casa: {casa}");

                            //Console.WriteLine($"zona de peligro: {itemHouse.zoneDangerous}" +" "+ $"direccion: {itemHouse.address}" + " " + $"precio: {itemHouse.price}" + " " + $"telefono de contacto: {itemHouse.contactPhone}" + " " + $"id: {itemHouse.id}");
                            casa++;

                        }

                        
                    }
                    //Console.WriteLine("");
                    //Console.WriteLine("apartamentos");
                    //Console.WriteLine("-----------------------------------");

                    if (itemInput1.builds.Apartments != null)
                    {
                        apartamento = 1;
                        foreach (Apartment itemApartment in itemInput1.builds.Apartments)
                        {
                            //Console.WriteLine($"apartamento: {apartamento}");

                            //Console.WriteLine($"amigable con los animales: {itemApartment.isPetFriendly}" + " " + $"direccion: {itemApartment.address}" + " " + $"precio: {itemApartment.price}" + " " + $"telefono de contacto: {itemApartment.contactPhone}" + " " + $"id: {itemApartment.id}");


                            

                            apartamento++;

                            

                        }

                        


                    }
                    //Console.WriteLine("");
                    //Console.WriteLine("locales");
                    //Console.WriteLine("-----------------------------------");

                    if (itemInput1.builds.Premises != null)
                    {
                        local = 1;
                        foreach (Premise itemPremise in itemInput1.builds.Premises)
                        {
                            //Console.WriteLine($"local: {local}");

                            //Console.Write("actividades comerciales: ");
                            foreach (var item in itemPremise.commercialActivities)
                            {
                                //Console.Write(item +" ");

                            }
                            //Console.WriteLine( $"direccion: {itemPremise.address}" + " " + $"precio: {itemPremise.price}" + " " + $"telefono de contacto: {itemPremise.contactPhone}" + " " + $"id: {itemPremise.id}") ;
                            local++;

                        }


                    }


                    if (itemInput1.builds.Apartments != null)
                    {
                        if (input.input2.typeBuilder == "Apartments")
                        {
                            var isPetFriendly = FilterA(itemInput1.builds.Apartments, input.input2.budget, input.input2.wannaPetFriendly, IsPetFriendly);

                            
                        }
                    }

                    if (itemInput1.builds.Houses != null)
                    {
                        if (input.input2.typeBuilder == "Houses")
                        {
                            var isOkDanger = FilterH(itemInput1.builds.Houses, input.input2.budget, input.input2.minDanger, IsOkDanger);


                        }
                    }

                    if (itemInput1.builds.Premises != null)
                    {
                        if (input.input2.typeBuilder == "Premises")
                        {
                            var isPymesAllow = FilterP(itemInput1.builds.Premises, input.input2.budget, input.input2.commercialActivity, IsPymesAllow);

                            
                        }
                    }



                    sector++;


                }

                //Console.WriteLine("");
                //Console.WriteLine("requerimientos");
                //Console.WriteLine("-----------------------------------");

                //Console.Write($"requirement servicios: ");
                foreach (string requirement in input.input2.requiredServices)
                {
                    //Console.Write(requirement+" ");
                }
                //Console.WriteLine("");
                //Console.WriteLine($"requirement tipo de construccion: {input.input2.typeBuilder}");
                //Console.WriteLine($"requirement peligro: {input.input2.minDanger}");
                //Console.WriteLine($"requirement mascotas: {input.input2.wannaPetFriendly}");
                //Console.WriteLine($"requirement actividad comercial: {input.input2.commercialActivity}");
                //Console.WriteLine($"requirement presupuesto: {input.input2.budget}");


                List<string> apt = new List<string>();

                if (input.input2.typeBuilder == "Apartments" && resultsApartments.Count == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    foreach (KeyValuePair<string, double> item in resultsApartments.OrderBy(key => key.Value))
                    {
                        apt.Add("\"" + item.Key + "\"");


                    }
                }
                

                string resultA = string.Join(",", apt);

                if (resultA.Length > 0)
                {
                    Console.Write("[" + resultA + "]");
                    Console.WriteLine("");
                }
                


                List<string> hou = new List<string>();

                if (input.input2.typeBuilder == "Houses" && resultsHouses.Count == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    foreach (KeyValuePair<string, double> item in resultsHouses.OrderBy(key => key.Value))
                    {
                        hou.Add("\"" + item.Key + "\"");


                    }
                }

                

                string resultH = string.Join(",", hou);


                if (resultH.Length > 0)
                {
                    Console.Write("[" + resultH + "]");

                    Console.WriteLine("");
                }

                

                List<string> pre = new List<string>();


                if (input.input2.typeBuilder == "Premises" && resultsPremises.Count == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    foreach (KeyValuePair<string, double> item in resultsPremises.OrderBy(key => key.Value))
                    {
                        pre.Add("\"" + item.Key + "\"");


                    }
                }
                



                string resultP = string.Join(",", pre);
                if (resultP.Length > 0)
                {
                    Console.Write("[" + resultP + "]");

                    Console.WriteLine("");
                }

                


                resultsApartments.Clear();
                resultsHouses.Clear();
                resultsPremises.Clear();

            }
            
         

        }
    }
}
