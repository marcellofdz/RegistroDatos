using System;
using System.Text;
using System.IO;

namespace RG_v3
{
    class Capturar3
    {
        public static void Main(string[] args)
        {
             //nombre, apellido, cedula, edad, 
        Console.WriteLine("=============== Bienvenido ===============");
        Console.Write("Desea ver el menú? Y/N  : ");
        string question = Console.ReadLine();
        


        if (question == "Y" || question == "y")
        {

        Console.WriteLine("¿Que desea hacer?");
        Console.WriteLine("[1] Agregar Información. \n[2] Buscar Información \n[3] Editar Información\n[4] Eliminar información \n[5] Salir.");
        int menu = Convert.ToInt32(Console.ReadLine());

        switch (menu)
            {
          case 1:
                        Console.Clear();
                        Console.WriteLine("************** Agregar datos **************");
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
                            

                            if (desicion == "N" || desicion == "n")
                            {
                                Console.WriteLine("Tenga buen día.");
                            }

                            else
                            {

                                    agregar(vNombre, vApellido, vEdad, vCedula);

                            }
                        }

                        catch (System.Exception)
                        {
                            
                            Console.WriteLine("Ha Ocurrido un error");
                            throw;
                        }
 

              break;
          case 2:
              Console.Clear();
              Console.WriteLine("************** Buscar datos **************");
              Console.Write("Dame la cedula a buscar: ");
              string vSCedula = Console.ReadLine();
              string vSfile = @"Datos.csv";

                buscar(vSfile, vSCedula);
                     
              break;

        case 3: 
            Console.Clear();
            Console.WriteLine("************** Editar datos **************");
            Console.Write("Dame el nombre del registro a editar: ");
        break;

        case 4:
            Console.Clear();
            Console.WriteLine("************** Eliminar datos **************");
            Console.Write("Dame el nombre del registro a eliminar: ");
            string vDnombre = Console.ReadLine();
            string vDfile = @"Datos.csv";

            eliminar(vDfile, vDnombre);
        break;

          
          default:
              Console.WriteLine("Default case");
              break;
            } 






        }

        else
        {
            Console.WriteLine("Tenga buen día.");
        }

   
        }


#region Función Agregar datos
        public static void agregar(String vNombre, String vApellido, Int32 vEdad, String vCedula)
        {
            // Creating a file
            string vfile = @"Datos.csv"; 
                    
            // Appending the given texts 
            using(StreamWriter sw = File.AppendText(vfile)) 
            { 
             sw.WriteLine($"{vNombre},{vApellido},{vEdad},{vCedula}");
            } 

            Console.WriteLine($"{vNombre},{vApellido},{vEdad},{vCedula}");
                        
/*             // Opening the file for reading 
            using(StreamReader sr = File.OpenText(vfile)) 
            { 
            string s = ""; 
            while ((s = sr.ReadLine()) != null) { 
            Console.WriteLine(s); 
             } 
                                    
                                    
            } */
        }

#endregion

#region Función Buscar datos
        public static string buscar(String vSfile, String vSCedula)
        {
               {       
                        var strLines=File.ReadLines($"{vSfile}");
                        foreach(var line in strLines)
                        {
                            if(line.Split(',')[3].Equals(vSCedula))
                              Console.WriteLine(line);
                        }

                        return "";

                }           

        }
#endregion


#region Función Editar datos
/*         public static string editar(String vSfile, String vSCedula)
        {
            

        } */
#endregion



#region Función Eliminar datos
        public static string eliminar(String vDfile, String vDnombre)
        {
            
                    string line = null;
                    string line_to_delete = vDnombre;

                    using (StreamReader reader = new StreamReader(vDfile)) 
                    {
                        using (StreamWriter writer = new StreamWriter(vDfile)) 
                        {
                            while ((line = reader.ReadLine()) != null) 
                            
                            {
                                if (String.Compare(line, line_to_delete) == 0)
                                    continue;

                                writer.WriteLine(line);
                            }

                            Console.WriteLine(line);
                        }
                    }

                    return "";


        }
#endregion







    }





}
