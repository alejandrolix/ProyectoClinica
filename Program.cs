using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    class Program
    {
        static List<Usuario> CrearUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios.Add(new Usuario("Administrador", "Administrador"));
            listaUsuarios.Add(new Usuario("Gestor", "Gestor"));
            listaUsuarios.Add(new Usuario("Médico", "Médico"));
            listaUsuarios.Add(new Usuario("Enfermero", "Enfermero"));

            return listaUsuarios;
        }

        static void Login(List<Usuario> listaUsuarios)
        {
            String usuarioIntroducido = "", passwordIntroducida = "";
            Boolean repetirLogin = true, repetirUsuario = true, repetirPassword = true, romperBucle = true;

            while (repetirLogin)
            {
                Console.Clear();

                Console.WriteLine("###########");
                Console.WriteLine("#  Login  #");
                Console.WriteLine("########### \n");

                while (repetirUsuario)
                {                    
                    Console.Write("  Usuario: ");
                    usuarioIntroducido = Console.ReadLine();

                    if (usuarioIntroducido == "")
                    {
                        Console.Clear();

                        Console.WriteLine("Error, tienes que introducir un usuario.");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                    }
                    else
                    {
                        repetirUsuario = false;
                    }
                }

                while (repetirPassword)
                {                                      
                    Console.Write("  Contraseña: ");
                    passwordIntroducida = Console.ReadLine();

                    if (passwordIntroducida == "")
                    {
                        Console.Clear();

                        Console.WriteLine("Error, tienes que introducir una contraseña.");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else
                    {
                        repetirPassword = false;
                    }
                }                                

                for (int i = 0; i < listaUsuarios.Count && romperBucle; i++)
                {
                    if (usuarioIntroducido == listaUsuarios[i].Nombre && passwordIntroducida == listaUsuarios[i].Password)
                    {
                        repetirLogin = false;
                        romperBucle = false;
                        SubMenu();                        
                    }
                }

                Console.Clear();

                Console.WriteLine("Error, has introducido mal el usuario o la password. Introduce de nuevo los datos.");
                System.Threading.Thread.Sleep(5000);                              
            }            
        }

        static void SubMenu()
        {

        }

        static void Main(string[] args)
        {
            List<Usuario> listaUsuarios;

            listaUsuarios = CrearUsuarios();
            Login(listaUsuarios);







            Console.ReadKey();
        }
    }
}
