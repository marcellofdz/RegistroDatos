using System;
using System.Text;
using System.IO;

namespace RG_v7
{
    class RG_v7class
    {
        public static void Main(string[] args)
        {
            
        int vDesicion;
        do
        {
            
        Console.Clear();
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
                        Console.Write("Inserte su cedula: ");
                        string vCedula = Console.ReadLine();
                        

                        Console.Write("Inserte su nombre: ");
                        string vNombre = Console.ReadLine();
                        

                        Console.Write("Inserte su apellido: ");
                        string vApellido = Console.ReadLine();
                        
                        //Console.Write("Inserte la cantidad de ahorros: ")
                        //int vAhorros = Console.ReadLine();

                        Console.Write("Inserte su edad: ");
                        int vEdad = Convert.ToInt32(Console.ReadLine());

                        //Console.Write("Inserte contraseña: ");


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
            Console.WriteLine("************** Editar datos ************** ");
            Console.Write("Dame la cedula del registro a Editar: ");
            string vECedula = Console.ReadLine();
            string vEfile = @"Datos.csv";

                 editar(vEfile, vECedula);

        break;

        case 4:
            Console.Clear();
            Console.WriteLine("************** Eliminar datos ************** ");
            Console.Write("Dame la cedula del registro a eliminar: ");
            string vDCedula = Console.ReadLine();
            string vDfile = @"Datos.csv";

            eliminar(vDfile, vDCedula);
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

         

        Console.WriteLine("¿Desea repetir el programa?\n Presione 0 para repetir opciones.");
        vDesicion = Convert.ToInt32(Console.ReadLine());
        if (vDesicion != 0)
        {
            break;
        }
        }
        while (true);

        
        }
        


#region Función Agregar datos
        public static void agregar(String vNombre, String vApellido, Int32 vEdad, String vCedula)
        {
            // Creating a file
            string vfile = @"Datos.csv"; 
                    
            // Appending the given texts 
            using(StreamWriter sw = File.AppendText(vfile)) 
            { 
             sw.WriteLine($"{vCedula},{vNombre},{vApellido},{vEdad}");
            } 

            Console.WriteLine("Cedula: " + $"{vCedula}\n" + "Nombre: " + $"{vNombre}\n" + "Apellido: "+ $"{vApellido}\n" + "Edad: " + $"{vEdad}");
                        
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
                            if(line.Split(',')[0].Equals(vSCedula))
                              Console.WriteLine(line);
                        }

                        return "";

                }           

        }
#endregion


#region Función Editar datos
         public static string editar(String vEfile, String vECedula)
        {

            var lines = File.ReadAllLines(vEfile);
            //comienza en cero para tomar desde la linea 1 del documento, cuando tenga el header debo saltar la linea 1 y poner el for comience en 1

            for (var i = 0; i < lines.Length; i+=1)
            {
                var data = lines[i];

                if (!string.IsNullOrEmpty(data) && data.Contains(vECedula))
                {   
                    Console.Write("Inserte el nuevo nombre: ");
                    string newNombre = Console.ReadLine();

                    Console.Write("Inserte el nuevo apellido: ");
                    string newApellido = Console.ReadLine();

                    Console.Write("Inserte la nueva edad: ");
                    Int32 newEdad = Convert.ToInt32(Console.ReadLine());

                    string text = File.ReadAllText(vEfile);
                    text = text.Replace(data, $"{vECedula},{newNombre},{newApellido},{newEdad}");
                    File.WriteAllText(vEfile,text);
                }
            }





               /* String path = vEfile;
                List<String> lines = new List<String>();

                if (File.Exists(path));
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;
                        while ((line = reader.ReadLine()) != null)
                        {
                        if (line.Contains(","))
                        {
                            String[] split = line.Split(',');
                            if (split[4].Contains(vECedula))
                            {
                                split[0] = "100";
                                line = String.Join(",", split);
                            
                            }
                            
                        }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                           foreach (String line in lines)
                           writer.WriteLine(line);
                    }
                }
                return "";*/

                return "";
        }  
#endregion



#region Función Eliminar datos
        public static string eliminar(String vDfile, String vDCedula)
        {
            
               string busqueda = vDCedula;
               string[] values = File.ReadAllText(vDfile).Split(new char[] { '\n' });
               StringBuilder ObjStringBuilder = new StringBuilder();

                for (int i = 0; i < values.Length; i++)
                        {
                    if (values[i].Split(',')[0] == busqueda)
                        continue;
                        ObjStringBuilder.AppendLine(values[i].TrimEnd('\r'));
                        }
                File.WriteAllText(vDfile, ObjStringBuilder.ToString().TrimEnd(new char[] {'\n','\r'}),Encoding.UTF8);

                Console.WriteLine("Usuario con la cedula {0} ha sido eliminado. \n",vDCedula);
                return "";

        }
#endregion

        public static string HidePassword()
        {
            string psw = "";
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    psw += key.KeyChar;
                }
                else
                {
                    if (psw.Length > 0)
                    {
                        psw = psw.Remove(psw.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                key = Console.ReadKey(true);
            }
            Console.WriteLine();
            return psw;
        }

    public Person(in string id, in string name, in string age, in double ahorros, in Gender gender, in MCstatus mStatus, in Agrad agrad, in string password)
    {
        Id = id;
        Name=name;
        ahorros = ahorros;
        password = Password;
        bitpacking = (age << 4) | (int)gender | (int)MCstatus | (int)aGrad;

    }

    public override string ToString() ==> $"{GetType().Name}({nameof(Id)}:{Id}; {nameof(Name)}:{Name}; {nameof(bitpacking)}:{bitpacking}; {nameof(Age)}:{Age}; {nameof(Gender)}:{gender}; {nameof(MStatus)}:{mStatus}; {nameof(AGrad)}:{aGrad}; {nameof(Ahorros)}:{Ahorros}; {nameof(Password)}:{Password};)";
    {
    }


    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return Id.Equals(other.Id);
        }

        return false;        
    }


    public override int GetHashCode()
    {
        return Age.GetHashCode();
    }

    
    internal static Person FromvDfile(string line)
    {
        string[] tokens = line.splint(',');
        (
            string id, name,
            double ahorros,
            int bitpacking,
            string password 
        ) = (

            tokens[0];,
            tokens[1];
            double.Parse(tokens[2]),
            int.Parse(tokens[3]),
            tokens[4](Gender)(bitpacking & 0b1000));
            MStatus mStatus = (MStatus)(bitpacking & 0b1000);
            AGrad aGrad = (AGrad)(bitpacking & 0b11);
            return new Person(id, name, age, ahorros, gender, mStatus, aGrad, password);
    }

    internal static Person FromConsole(string record)
    {(
        var tokens = record.Split(',');
        (
            string id, 
            string name,
            int age,
            double ahorros,
            string password,
            Gender gender,
            MStatus mStatus,
            Agrad aGrad
        ) = (
            to[kens[0],
            tokens[1],
            Convert.ToInt32(tokens[3]),
            double.Parse(tokens[3]),
            tokens[4],
            (Gender)int.Parse(tokens[5]),
            (MStatus)int.Parse(tokens[6]),
            (AGrad)int.Parse(tokens[7])
        );

        return new Person(id, name, age, ahorros, gender, mStatus, aGrad, password);
    }

    internal static void SaveToCsv()
    {
        if (Persons.Count() > 0)
        {
            File.WriteAllText(vDfile, $"{Environment.NewLine}{p.Id},{p.Name},,{p.Ahorros},{p.Password},{p.Age}");
        }
    }


    internal string UpdateData()
    {
        try
        {
            var updated = persons.FindIndex(a => a.Id == this.Id);

            persons[updated] = this;
            return "Datos modificados de forma correcta."
        }

        catch(Exception)
        {
            return "no se pudieron modificar los datos, valida la excepcion";
        }
    }

    public enum Gender 
    {
        Male = 0,
        Female = 4
    }

    public enum AGrad 
    {
        Inicial = 0,
        Bachiller = 1,
        Grado = 2,
        Postgrado =3
    }




}
