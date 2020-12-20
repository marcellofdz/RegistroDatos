using System;
using System.Text;
using System.IO;

namespace RG_v1
{
    class Capturar
    {
        static void Main(string[] args)
        {
             //nombre, apellido, cedula, edad, 

                        Console.Write("Inserte su nombre: ");
                        string vNombre = Console.ReadLine();

                        Console.Write("Inserte su apellido: ");
                        string vApellido = Console.ReadLine();

                        Console.Write("Inserte su edad: ");
                        int vEdad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserte su Cedula: ");
                        string vCedula = Console.ReadLine();

                        Console.Write("¿Quieres grabar los datos? Y/N  : ");
                        string desicion = Console.ReadLine();

                        try
                        {
                            

                            if (desicion == "N" || desicion == "N")
                            {
                                Console.WriteLine("Tenga buen día.");
                            }

                            else
                            {

                                // Creating a file
                                string vfile = @"Datos.csv"; 
                        
                                // Appending the given texts 
                                using(StreamWriter sw = File.AppendText(vfile)) 
                                { 
                                    sw.WriteLine($"{vNombre},{vApellido},{vEdad},{vCedula}");
                                } 
                        
                                // Opening the file for reading 
                                using(StreamReader sr = File.OpenText(vfile)) 
                                { 
                                    string s = ""; 
                                    while ((s = sr.ReadLine()) != null) { 
                                        Console.WriteLine(s); 
                                    } 
                                    
                                    
                                 }
                            }
                        }

                        catch (System.Exception)
                        {
                            
                            Console.WriteLine("Ha Ocurrido un error");
                            throw;
                        }
        }
    }
}
