using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProgramaClinica
{
    class Program
    {
        static Clinica clinica = new Clinica(@"C.\ Los Almendros, 34", "Medimar", "123456789");        

        static List<Usuario> CrearUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios.Add(new Usuario("Administrador", "Administrador", 0));
            listaUsuarios.Add(new Usuario("Gestor", "Gestor", 1));
            listaUsuarios.Add(new Usuario("Médico", "Médico", 2));
            listaUsuarios.Add(new Usuario("Enfermero", "Enfermero", 3));

            return listaUsuarios;
        }        

        static void Login(List<Usuario> listaUsuarios)
        {
            String usuarioIntroducido = "", passwordIntroducida = "";
            Boolean repetirLogin = true, repetirUsuario = true, repetirPassword = true, romperBucle = true;
            Usuario infoUsuarioLogueado;

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

                        infoUsuarioLogueado = new Usuario(usuarioIntroducido, passwordIntroducida, listaUsuarios[i].Numero);
                        MenuPrincipal(infoUsuarioLogueado);
                    }
                }

                Console.Clear();

                Console.WriteLine("Error, has introducido mal el usuario o la password. Introduce de nuevo los datos.");
                System.Threading.Thread.Sleep(5000);                              
            }            
        }

        static void MenuPrincipal(Usuario infoUsuarioLogueado)
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
                            SubMenu1(infoUsuarioLogueado);
                            break;

                        case 2:
                            MenuClinica(infoUsuarioLogueado);
                            break;

                        case 3:
                            #region Código



                            #endregion

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
        }

        static void SubMenu1(Usuario infoUsuarioLogueado)
        {
            int numIntroducido;
            Boolean repetirMenu = true, repetirPassword = true;
            IFormatter formatear = new BinaryFormatter();
            String passwordIntroducida, usuarioIntroducido = "";
            // String loginAdminParaGuardar;

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

                            if (infoUsuarioLogueado.Numero == 0)
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

                                        // loginAdminParaGuardar = usuarioIntroducido + ',' + passwordIntroducida;                                        

                                        FileStream archivo = new FileStream(@".\Archivos\admin.pas", FileMode.OpenOrCreate, FileAccess.Write);

                                        formatear.Serialize(archivo, (usuarioIntroducido + ',' + passwordIntroducida));

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
                            #region Código

                            if (infoUsuarioLogueado.Numero == 0)
                            {
                                SubMenu2(infoUsuarioLogueado);
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
                            MenuPrincipal(infoUsuarioLogueado);
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

        static void SubMenu2(Usuario infoUsuarioLogueado)
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
                            AnnadirUsuario(infoUsuarioLogueado);

                            break;

                        case 2:
                            EliminarUsuario(infoUsuarioLogueado);

                            break;

                        case 3:
                            Environment.Exit(0);
                            break;

                        case 4:
                            SubMenu1(infoUsuarioLogueado);
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

        static void AnnadirUsuario(Usuario infoUsuarioLogueado)
        {
            int numUsuarioIntroducido;
            Boolean repetirTipoUsuario = true;
            String usuarioIntroducido, passwordIntroducida;
            IFormatter formatear = new BinaryFormatter();

            while (repetirTipoUsuario)
            {
                Console.Clear();

                Console.WriteLine("#######\n # Elegir Tipo Usuario #\n ####### \n\n 1. Gestor \n 2. Médico \n 3. Enfermero \n\n Introduce un número: ");
                numUsuarioIntroducido = int.Parse(Console.ReadLine());

                if (numUsuarioIntroducido >= 1 && numUsuarioIntroducido <= 3)
                {
                    repetirTipoUsuario = false;

                    switch (numUsuarioIntroducido)
                    {
                        case 1:
                            #region Código

                            Console.Clear();

                            Console.WriteLine("Introduce el nombre del usuario: ");
                            usuarioIntroducido = Console.ReadLine();

                            Console.WriteLine("Introduce la contraseña: ");
                            passwordIntroducida = Console.ReadLine();

                            FileStream archivo = new FileStream(@".\Archivos\usuarios.pas", FileMode.Create, FileAccess.Write);

                            Usuario gestor = new Usuario(usuarioIntroducido, passwordIntroducida, 1);
                            formatear.Serialize(archivo, gestor);

                            archivo.Close();
                            Console.Clear();

                            Console.WriteLine("Usuario Añadido.");
                            System.Threading.Thread.Sleep(4000);

                            SubMenu2(infoUsuarioLogueado);

                            #endregion                            

                            break;

                        case 2:
                            #region Código

                            Console.Clear();

                            Console.WriteLine("Introduce el nombre del usuario: ");
                            usuarioIntroducido = Console.ReadLine();

                            Console.WriteLine("Introduce la contraseña: ");
                            passwordIntroducida = Console.ReadLine();

                            FileStream archivo1 = new FileStream(@".\Archivos\usuarios.pas", FileMode.Create, FileAccess.Write);

                            Usuario medico = new Usuario(usuarioIntroducido, passwordIntroducida, 2);
                            formatear.Serialize(archivo1, medico);

                            archivo1.Close();

                            #endregion                            

                            break;

                        case 3:
                            #region Código

                            Console.Clear();

                            Console.WriteLine("Introduce el nombre del usuario: ");
                            usuarioIntroducido = Console.ReadLine();

                            Console.WriteLine("Introduce la contraseña: ");
                            passwordIntroducida = Console.ReadLine();

                            FileStream archivo2 = new FileStream(@".\Archivos\usuarios.pas", FileMode.Create, FileAccess.Write);

                            Usuario enfermero = new Usuario(usuarioIntroducido, passwordIntroducida, 3);
                            formatear.Serialize(archivo2, enfermero);

                            archivo2.Close();

                            #endregion                            

                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo.");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }                
            }
        }

        static void EliminarUsuario(Usuario infoUsuarioLogueado)
        {
            String usuarioIntroducido, passwordIntroducida;
            Boolean repetirNombre = true, repetirPassword = true;
            Usuario datosUsuarioLeido, datosUsuarioNuevo;
            IFormatter formatear = new BinaryFormatter();

            while (repetirNombre)
            {
                Console.Clear();

                Console.WriteLine("Introduce el nombre del usuario: ");
                usuarioIntroducido = Console.ReadLine();

                if (usuarioIntroducido == "")
                {
                    Console.Clear();

                    Console.WriteLine("Error, tienes que introducir un usuario.");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
                else
                {
                    repetirNombre = false;
                }

                while (repetirPassword)
                {
                    Console.WriteLine("Introduce la contraseña: ");
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
                        FileStream archivo = new FileStream(@".\Archivos\usuarios.pas", FileMode.Open, FileAccess.Read);

                        while (archivo.Position < archivo.Length)
                        {
                            datosUsuarioLeido = (Usuario)formatear.Deserialize(archivo);

                            if (datosUsuarioLeido.Nombre == usuarioIntroducido && datosUsuarioLeido.Password == passwordIntroducida)
                            {
                                datosUsuarioNuevo = datosUsuarioLeido;
                                archivo.Close();

                                File.Delete(@".\Archivos\usuarios.pas");
                                FileStream archivo1 = new FileStream(@".\Archivos\usuarios.pas", FileMode.Create, FileAccess.Write);

                                formatear.Serialize(archivo1, datosUsuarioNuevo);

                                archivo1.Close();
                                Console.Clear();

                                Console.WriteLine("Usuario Eliminado.");

                                System.Threading.Thread.Sleep(5000);
                                SubMenu2(infoUsuarioLogueado);
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("Error, los datos introducidos del usuario no existen. ");
                        System.Threading.Thread.Sleep(5000);
                        repetirNombre = true; repetirPassword = true;
                    }
                }
            }
        }

        static void MenuClinica(Usuario infoUsuarioLogueado)
        {
            int numIntroducido;
            Boolean repetirMenu1 = true, repetirMenu2 = true, repetirMenu3 = true, repetirEspecialidad = true, romperBucle = true;
            int numHabitacionIntroducido;
            String especialidadIntroducida;

            if (infoUsuarioLogueado.Numero == 0)
            {                
                while (repetirMenu1)
                {
                    Console.Clear();
                    Console.WriteLine("########## \n # Menú Clínica # \n ########## \n\n 1. Personal \n 2. Habitaciones 3. Salir 4. Volver \n\n Introduce un número: ");
                    numIntroducido = int.Parse(Console.ReadLine());

                    if (numIntroducido >= 1 && numIntroducido <= 4)
                    {
                        repetirMenu1 = false;

                        switch (numIntroducido)
                        {
                            case 1:
                                #region Código

                                while (repetirMenu2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("########## \n # Menú Personal # \n ########## \n\n 1. Añadir Médico \n 2. Borrar Médico \n 3. Añadir Enfermero \n 4. Borrar Enfermero \n 5. Salir \n 6. Volver \n\n Introduce un número: ");
                                    numIntroducido = int.Parse(Console.ReadLine());

                                    if (numIntroducido >= 1 && numIntroducido <= 6)
                                    {
                                        // repetirMenu2 = false;

                                        switch (numIntroducido)
                                        {
                                            case 1:
                                                clinica.AnnadirMedico();
                                                break;

                                            case 2:
                                                clinica.BorrarMedico();
                                                break;

                                            case 3:
                                                clinica.AnnadirEnfermero();
                                                break;

                                            case 4:
                                                clinica.BorrarEnfermero();
                                                break;

                                            case 5:
                                                Environment.Exit(0);
                                                break;

                                            case 6:
                                                MenuClinica(infoUsuarioLogueado);
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

                                #endregion

                                break;

                            case 2:
                                #region Código

                                while (repetirMenu3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("############ \n # Menú Habitaciones # \n ############ \n\n 1. Añadir Habitación \n 2. Eliminar Habitación \n 3. Mostrar Especialidad \n 4. Cambiar Especialidad \n 5. Salir \n 6. Volver \n\n Introduce un número: ");
                                    numIntroducido = int.Parse(Console.ReadLine());

                                    if (numIntroducido >= 1 && numIntroducido <= 6)
                                    {
                                        // repetirMenu2 = false;

                                        switch (numIntroducido)
                                        {
                                            case 1:
                                                #region Código

                                                Console.Clear();
                                                Console.Write("Introduce el número de la habitación: ");
                                                numHabitacionIntroducido = int.Parse(Console.ReadLine());

                                                while (repetirEspecialidad)
                                                {
                                                    Console.Clear();
                                                    Console.Write("Introduce la especialidad: ");
                                                    especialidadIntroducida = Console.ReadLine();

                                                    if (especialidadIntroducida == "")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Error, tienes que introducir una especialidad.");
                                                        System.Threading.Thread.Sleep(5000);
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        repetirEspecialidad = false;

                                                        clinica.Habitaciones.Add(new Habitacion(1, false, especialidadIntroducida));                                                              

                                                        Console.Clear();
                                                        Console.WriteLine("Habitación Añadida.");
                                                    }
                                                }                                                

                                                #endregion

                                                break;

                                            case 2:
                                                #region Código

                                                Console.Clear();
                                                Console.Write("Introduce el número de la habitación: ");
                                                numHabitacionIntroducido = int.Parse(Console.ReadLine());

                                                for (int i = 0; i < clinica.Habitaciones.Count && romperBucle; i++)
                                                {
                                                    if (clinica.Habitaciones[i].Numero == numHabitacionIntroducido)
                                                    {
                                                        romperBucle = false;
                                                        clinica.Habitaciones.Remove(clinica.Habitaciones[i]);                                                        

                                                        Console.Clear();
                                                        Console.WriteLine("Habitación eliminada.");
                                                        System.Threading.Thread.Sleep(4000);
                                                    }
                                                }

                                                #endregion

                                                break;

                                            case 3:
                                                #region Código

                                                Console.Clear();
                                                Console.Write("Introduce el número de la habitación: ");
                                                numHabitacionIntroducido = int.Parse(Console.ReadLine());

                                                for (int i = 0; i < clinica.Habitaciones.Count && romperBucle; i++)
                                                {
                                                    if (clinica.Habitaciones[i].Numero == numHabitacionIntroducido)
                                                    {
                                                        romperBucle = false;
                                                        clinica.Habitaciones[i].MostrarEspecialidad(clinica.Habitaciones[i]);
                                                        Console.ReadKey();

                                                        Console.Clear();                                                        
                                                    }
                                                }

                                                #endregion

                                                break;

                                            case 4:
                                                #region Código

                                                Console.Clear();
                                                Console.Write("Introduce el número de la habitación: ");
                                                numHabitacionIntroducido = int.Parse(Console.ReadLine());

                                                for (int i = 0; i < clinica.Habitaciones.Count && romperBucle; i++)
                                                {
                                                    if (clinica.Habitaciones[i].Numero == numHabitacionIntroducido)
                                                    {
                                                        romperBucle = false;
                                                        clinica.Habitaciones[i].CambiarEspecialidad(clinica.Habitaciones[i]);
                                                    }
                                                }

                                                #endregion

                                                break;

                                            case 5:
                                                Environment.Exit(0);
                                                break;

                                            case 6:
                                                MenuClinica(infoUsuarioLogueado);
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

                                #endregion

                                break;

                            case 3:
                                Environment.Exit(0);
                                break;

                            case 4:
                                MenuPrincipal(infoUsuarioLogueado);
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
            else
            {
                Console.Clear();

                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción: ");
                System.Threading.Thread.Sleep(5000);                
                MenuPrincipal(infoUsuarioLogueado);
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
