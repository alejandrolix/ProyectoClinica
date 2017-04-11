using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Clinica
{
    class Program
    {
        static List<Usuario> CrearUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();            
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
                        MenuPrincipal(usuarioIntroducido, passwordIntroducida);
                    }
                    /* else if (usuarioIntroducido == "Administrador" && passwordIntroducida == "Administrador")
                    {
                        repetirLogin = false;
                        romperBucle = false;
                        MenuPrincipal(usuarioIntroducido, passwordIntroducida);
                    } */
                }

                Console.Clear();

                Console.WriteLine("Error, has introducido mal el usuario o la password. Introduce de nuevo los datos.");
                System.Threading.Thread.Sleep(5000);                              
            }            
        }

        static void MenuPrincipal(String usuarioIntroducido, String passwordIntroducida)
        {
            int numIntroducido;
            Boolean repetirMenu = true;

            while (repetirMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Configuración \n 2. Clínica \n 3. Gestión Pacientes \n 4. Médicos 5. Salir \n\n Introduce un número: ");
                numIntroducido = int.Parse(Console.ReadLine());

                if (numIntroducido >= 1 && numIntroducido <= 5)
                {                    
                    switch (numIntroducido)
                    {
                        case 1:
                            SubMenu1(usuarioIntroducido, passwordIntroducida);
                            break;

                        case 2:
                            // Implementar.
                            break;

                        case 3:
                            // Implementar.
                            break;

                        case 4:
                            // Implementar.
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo: ");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
            }

            /* int numIntroducido;
            Boolean repetirMenu = true, repetirPassword = true;            

            while (repetirMenu)
            {
                Console.Clear();

                Console.WriteLine("1. Configuración \n 2. Usuarios \n 3. Cargar Datos \n 4. Guardar Datos \n 5. Salir Aplicación \n \n Introduce un número: ");
                numIntroducido = int.Parse(Console.ReadLine());

                if (numIntroducido >= 1 && numIntroducido <= 5)
                {
                    repetirMenu = false;
                   
                    switch (numIntroducido)
                    {
                        case 1:                 // Opción de "Administrador".
                            if (usuarioIntroducido == "Administrador" && passwordIntroducida == "Administrador")
                            {
                                while (repetirPassword)
                                {
                                    Console.Clear();

                                    Console.Write("Introduce la nueva constraseña del administrador: ");
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
                                        StreamWriter archivo = new StreamWriter(@".\Archivos\admin.pas", false, Encoding.UTF8);

                                        archivo.WriteLine(usuarioIntroducido + ',' + passwordIntroducida);

                                        archivo.Close();
                                    }
                                }
                            }
                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;

                        case 5:

                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo: ");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
            } */            
        }

        static void SubMenu1(String usuarioIntroducido, String passwordIntroducida)
        {
            int numIntroducido;
            Boolean repetirMenu = true, repetirPassword = true;
            IFormatter formatear = new BinaryFormatter();
            String loginAdminParaGuardar;

            while (repetirMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Administrador \n 2. Usuarios \n 3. Cargar Datos \n 4. Guardar Datos \n 5. Salir Aplicación \n 6. Volver \n\n Introduce un número: ");
                numIntroducido = int.Parse(Console.ReadLine());

                if (numIntroducido >= 1 && numIntroducido <= 6)
                {                    
                    switch (numIntroducido)
                    {
                        case 1:
                            #region Código

                            if (usuarioIntroducido == "Administrador" && passwordIntroducida == "Administrador")
                            {
                                while (repetirPassword)
                                {
                                    Console.Clear();

                                    Console.Write("Introduce la nueva constraseña del administrador: ");
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

                                        loginAdminParaGuardar = usuarioIntroducido + ',' + passwordIntroducida;                                        

                                        FileStream archivo = new FileStream(@".\Archivos\admin.pas", FileMode.OpenOrCreate, FileAccess.Write);

                                        formatear.Serialize(archivo, loginAdminParaGuardar);

                                        archivo.Close();
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();                                

                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                System.Threading.Thread.Sleep(5000);
                                Console.Clear();
                            }

                            #endregion
                            
                            break;

                        case 2:
                            SubMenu2(usuarioIntroducido, passwordIntroducida);
                            break;

                        case 3:
                            // Implementar.
                            break;

                        case 4:
                            // Implementar.
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        case 6:
                            MenuPrincipal(usuarioIntroducido, passwordIntroducida);
                            break;
                    }
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo: ");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
            }
        }

        static void SubMenu2(String usuarioIntroducido, String passwordIntroducida)
        {
            int numIntroducido;
            Boolean repetirMenu = true;

            while (repetirMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Alta Usuario \n 2. Baja Usuario \n 3. Salir \n 4. Volver \n\n Introduce un número: ");
                numIntroducido = int.Parse(Console.ReadLine());

                if (numIntroducido >= 1 && numIntroducido <= 4)
                {
                    switch (numIntroducido)
                    {
                        case 1:                                                                                  


                            break;

                        case 2:
                            // Implementar.
                            break;

                        case 3:
                            Environment.Exit(0);
                            break;

                        case 4:
                            SubMenu1(usuarioIntroducido, passwordIntroducida);
                            break;
                    }
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo: ");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                List<Usuario> listaUsuarios;

                listaUsuarios = CrearUsuarios();
                Login(listaUsuarios);







                Console.ReadKey();
            }
            catch (Exception)
            {
                                
            }
        }
    }
}
