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
        static Clinica clinica = new Clinica(@"C.\ Los Almendros, 34", "Medimar", "123456789", new List<Usuario>());

        static void AnnadirUsuariosClinica()
        {
            clinica.AnnadirUsuario(new Usuario("Administrador", "Administrador", 0));
            clinica.AnnadirUsuario(new Usuario("Gestor", "Gestor", 1));
            clinica.AnnadirUsuario(new Usuario("Medico", "Medico", 2));
            clinica.AnnadirUsuario(new Usuario("Enfermero", "Enfermero", 3));
        }

        static void Login()
        {
            String usuarioIntroducido = "", passwordIntroducida = "";
            ConsoleKeyInfo caracPasswordIntroducida;
            List<Char> listaTeclas = new List<Char>();
            Char teclaIntroducida;
            Boolean repetirLogin = true, repetirUsuario = true, repetirPassword = true, romperBucle = true, repetirCaracPass = true;
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
                    Console.WriteLine("");

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

                    while (repetirCaracPass)
                    {
                        caracPasswordIntroducida = Console.ReadKey(true);

                        teclaIntroducida = caracPasswordIntroducida.KeyChar;

                        if (caracPasswordIntroducida.Key == ConsoleKey.Enter)
                        {
                            repetirCaracPass = false;
                        }
                        else
                        {
                            listaTeclas.Add(teclaIntroducida);
                            Console.Write("*");
                        }
                    }

                    for (int i = 0; i < listaTeclas.Count; i++)
                    {
                        passwordIntroducida += listaTeclas[i];
                    }

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

                for (int i = 0; i < clinica.Usuarios.Count && romperBucle; i++)
                {
                    if (usuarioIntroducido == clinica.Usuarios[i].Nombre && passwordIntroducida == clinica.Usuarios[i].Password)
                    {
                        repetirLogin = false;
                        romperBucle = false;

                        infoUsuarioLogueado = new Usuario(usuarioIntroducido, passwordIntroducida, clinica.Usuarios[i].Numero);
                        MenuPrincipal(infoUsuarioLogueado);
                    }
                }

                Console.Clear();

                Console.WriteLine("Error, has introducido mal el usuario o la password.");
                System.Threading.Thread.Sleep(5000);

                repetirUsuario = true; repetirPassword = true; repetirCaracPass = true;
            }
        }

        static void MenuPrincipal(Usuario infoUsuarioLogueado)
        {
            int numIntroducido;
            Boolean repetirMenu = true, repetirMenu1 = true, repetirMenu2 = true;
            List<Paciente> pacientes = new List<Paciente>();
            List<Medico> medicos = new List<Medico>();

            while (repetirMenu)
            {
                Console.Clear();
                Console.Write("##################\n# Menú Principal #\n################## \n\n 1. Configuración \n 2. Clínica \n 3. Gestión Pacientes \n 4. Médicos \n 5. Salir \n\n Introduce un número: ");
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

                            while (repetirMenu1)
                            {
                                Console.Clear();
                                Console.WriteLine("############# \n # Menú Gestión Pacientes # \n ############# \n\n 1. Ingresar Paciente \n 2. Alta Paciente \n 3. Mostrar Datos \n 4. Diagnóstico \n 5. Tratamiento \n 6. Buscar Habitación \n 7. Buscar Médico \n 8. Baja Paciente \n 9. Volver \n 10. Salir \n\n Introduce un número: ");
                                numIntroducido = int.Parse(Console.ReadLine());

                                if (numIntroducido >= 1 && numIntroducido <= 10)
                                {
                                    pacientes[0] = new Paciente("123456H", "Pepe", "Rodríguez Albaladejo", "Hombre", new DateTime(1998, 2, 3), 20, new List<Diagnostico>());
                                    pacientes[1] = new Paciente("856976Q", "María", "Sánchez Cano", "Mujer", new DateTime(1999, 6, 9), 16, new List<Diagnostico>());

                                    switch (numIntroducido)
                                    {
                                        case 1:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Gestor")
                                            {
                                                for (int i = 0; i < pacientes.Count; i++)
                                                {
                                                    pacientes[i].IngresarPaciente(clinica);

                                                    Console.Clear();
                                                    Console.WriteLine("Paciente Ingresado.");
                                                    System.Threading.Thread.Sleep(4000);
                                                    Console.Clear();
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 2:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Gestor")
                                            {
                                                for (int i = 0; i < pacientes.Count; i++)
                                                {
                                                    if (pacientes[i].AltaPaciente(clinica) == true)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Paciente dado de Alta.");
                                                        System.Threading.Thread.Sleep(4000);
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("El paciente no está dado de alta.");
                                                        System.Threading.Thread.Sleep(5000);
                                                        Console.Clear();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 3:
                                            #region Código

                                            for (int i = 0; i < pacientes.Count; i++)
                                            {
                                                pacientes[i].MostrarDatosPaciente(pacientes[i]);
                                            }

                                            #endregion

                                            break;

                                        case 4:
                                            #region Código

                                            pacientes[1].Diagnostico(pacientes[0]);

                                            Console.WriteLine("\n Pulsa cualquier tecla para continuar...");
                                            Console.ReadKey();

                                            #endregion

                                            break;

                                        case 5:
                                            #region Código

                                            pacientes[0].Tratamiento(pacientes[0]);

                                            Console.WriteLine("\n Pulsa cualquier tecla para continuar...");
                                            Console.ReadKey();

                                            #endregion

                                            break;

                                        case 6:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Medico" || infoUsuarioLogueado.Nombre == "Enfermero")
                                            {
                                                pacientes[1].BuscarHabitacion(pacientes[1]);

                                                Console.WriteLine("\n Pulsa cualquier tecla para continuar...");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 7:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Medico" || infoUsuarioLogueado.Nombre == "Enfermero")
                                            {
                                                pacientes[0].BuscarMedico(pacientes[0], clinica);
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 8:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Medico" || infoUsuarioLogueado.Nombre == "Enfermero")
                                            {
                                                pacientes[1].BajaPaciente(pacientes[0]);
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 9:
                                            repetirMenu1 = false;
                                            break;

                                        case 10:
                                            Environment.Exit(0);
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();

                                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo: ");
                                    System.Threading.Thread.Sleep(5000);
                                }
                            }

                            #endregion

                            break;

                        case 4:
                            #region Código

                            while (repetirMenu2)
                            {
                                Console.Clear();
                                Console.WriteLine("############ \n # Menú Gestión Médicos # \n ############ \n\n 1. Diagnosticar \n 2. Tratar \n 3. Volver \n 4. Salir \n\n Introduce un número: ");
                                numIntroducido = int.Parse(Console.ReadLine());

                                if (numIntroducido >= 1 && numIntroducido <= 4)
                                {
                                    medicos[0] = new Medico("Pascual", "Marco González", "759632568G", "Cardiología");
                                    medicos[1] = new Medico("Vicente", "Ferrer", "796301201Q", "Dermatología");

                                    switch (numIntroducido)
                                    {
                                        case 1:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Medico")
                                            {
                                                medicos[0].Diagnosticar();
                                                medicos[1].Diagnosticar();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 2:
                                            #region Código

                                            if (infoUsuarioLogueado.Nombre == "Medico")
                                            {
                                                medicos[0].Tratar(pacientes[0]);
                                                medicos[1].Tratar(pacientes[1]);
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Error, no tienes permiso para acceder a ésta opción.");
                                            }

                                            #endregion

                                            break;

                                        case 3:
                                            repetirMenu2 = false;
                                            break;

                                        case 4:
                                            Environment.Exit(0);
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();

                                    Console.WriteLine("Error, no has introducido bien el número. Introdúcelo de nuevo: ");
                                    System.Threading.Thread.Sleep(5000);
                                }
                            }

                            #endregion

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
            Boolean repetirMenu = true, repetirPassword = true, repetirCaracPass = true;
            IFormatter formatear = new BinaryFormatter();
            String passwordIntroducida = "", repePasswordIntroducida = "";
            ConsoleKeyInfo caracPasswordIntroducida;
            List<Char> listaTeclas = new List<Char>();
            Char teclaIntroducida;

            while (repetirMenu)
            {
                Console.Clear();
                Console.Write("######################\n# Menú Administrador #\n###################### \n\n 1. Administrador \n 2. Usuarios \n 3. Cargar Datos \n 4. Guardar Datos \n 5. Salir Aplicación \n 6. Volver \n\n Introduce un número: ");
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

                                    while (repetirCaracPass)
                                    {
                                        caracPasswordIntroducida = Console.ReadKey(true);

                                        teclaIntroducida = caracPasswordIntroducida.KeyChar;

                                        if (caracPasswordIntroducida.Key == ConsoleKey.Enter)
                                        {
                                            repetirCaracPass = false;
                                        }
                                        else
                                        {
                                            listaTeclas.Add(teclaIntroducida);
                                            Console.Write("*");
                                        }
                                    }

                                    for (int i = 0; i < listaTeclas.Count; i++)
                                    {
                                        passwordIntroducida += listaTeclas[i];
                                    }

                                    if (passwordIntroducida == "")
                                    {
                                        Console.Clear();

                                        Console.WriteLine("Error, tienes que introducir una contraseña.");
                                        System.Threading.Thread.Sleep(5000);
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        repetirCaracPass = true;
                                        listaTeclas.Clear();

                                        Console.Clear();
                                        Console.Write("Introduce de nuevo la nueva contraseña administrador: ");

                                        while (repetirCaracPass)
                                        {
                                            caracPasswordIntroducida = Console.ReadKey(true);

                                            teclaIntroducida = caracPasswordIntroducida.KeyChar;

                                            if (caracPasswordIntroducida.Key == ConsoleKey.Enter)
                                            {
                                                repetirCaracPass = false;
                                            }
                                            else
                                            {
                                                listaTeclas.Add(teclaIntroducida);
                                                Console.Write("*");
                                            }
                                        }

                                        for (int i = 0; i < listaTeclas.Count; i++)
                                        {
                                            repePasswordIntroducida += listaTeclas[i];
                                        }

                                        if (passwordIntroducida == repePasswordIntroducida)
                                        {
                                            repetirPassword = false;

                                            infoUsuarioLogueado.Password = passwordIntroducida;

                                            FileStream archivo = new FileStream(@".\..\..\Archivos\admin.pas", FileMode.Create, FileAccess.Write);

                                            formatear.Serialize(archivo, infoUsuarioLogueado);

                                            archivo.Close();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Error, las contraseñas introducidas no coinciden.");
                                            System.Threading.Thread.Sleep(4000);

                                            Console.Clear();
                                        }
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
                Console.Write("#################\n# Menú Usuarios #\n################# \n\n 1. Alta Usuario \n 2. Baja Usuario \n 3. Salir \n 4. Volver \n\n Introduce un número: ");
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
            Boolean repetirTipoUsuario = true, repetirCaracPass = true;
            ConsoleKeyInfo caracPasswordIntroducida;
            String usuarioIntroducido, passwordIntroducida = "";
            List<Char> listaTeclas = new List<char>();
            IFormatter formatear = new BinaryFormatter();
            Char teclaIntroducida;

            while (repetirTipoUsuario)
            {
                Console.Clear();
                Console.Write("########################\n # Elegir Tipo Usuario #\n######################## \n\n 1. Gestor \n 2. Médico \n 3. Enfermero \n\n Introduce un número: ");
                numUsuarioIntroducido = int.Parse(Console.ReadLine());

                if (numUsuarioIntroducido >= 1 && numUsuarioIntroducido <= 3)
                {
                    repetirTipoUsuario = false;

                    switch (numUsuarioIntroducido)
                    {
                        case 1:
                            #region Código

                            Console.Clear();

                            Console.Write("Introduce el nombre del usuario: ");
                            usuarioIntroducido = Console.ReadLine();

                            Console.Write("Introduce la contraseña: ");

                            while (repetirCaracPass)
                            {
                                caracPasswordIntroducida = Console.ReadKey(true);

                                teclaIntroducida = caracPasswordIntroducida.KeyChar;

                                if (caracPasswordIntroducida.Key == ConsoleKey.Enter)
                                {
                                    repetirCaracPass = false;
                                }
                                else
                                {
                                    listaTeclas.Add(teclaIntroducida);
                                    Console.Write("*");
                                }
                            }

                            for (int i = 0; i < listaTeclas.Count; i++)
                            {
                                passwordIntroducida += listaTeclas[i];
                            }

                            FileStream archivo = new FileStream(@".\..\..\Archivos\usuarios.pas", FileMode.Create, FileAccess.Write);

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
            String usuarioIntroducido, passwordIntroducida = "";
            Boolean repetirNombre = true, repetirPassword = true, repetirCaracPass = true;
            Usuario datosUsuarioLeido;
            IFormatter formatear = new BinaryFormatter();            
            ConsoleKeyInfo caracPasswordIntroducida;            
            List<Char> listaTeclas = new List<char>();            
            Char teclaIntroducida;

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

                    while (repetirCaracPass)
                    {
                        caracPasswordIntroducida = Console.ReadKey(true);

                        teclaIntroducida = caracPasswordIntroducida.KeyChar;

                        if (caracPasswordIntroducida.Key == ConsoleKey.Enter)
                        {
                            repetirCaracPass = false;
                        }
                        else
                        {
                            listaTeclas.Add(teclaIntroducida);
                            Console.Write("*");
                        }
                    }

                    for (int i = 0; i < listaTeclas.Count; i++)
                    {
                        passwordIntroducida += listaTeclas[i];
                    }

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
                        FileStream archivo = new FileStream(@".\..\..\Archivos\usuarios.pas", FileMode.Open, FileAccess.Read);

                        while (archivo.Position < archivo.Length)
                        {
                            datosUsuarioLeido = (Usuario)formatear.Deserialize(archivo);

                            if (datosUsuarioLeido.Nombre == usuarioIntroducido && datosUsuarioLeido.Password == passwordIntroducida)
                            {                                
                                archivo.Close();

                                File.Delete(@".\Archivos\usuarios.pas");
                                FileStream archivo1 = new FileStream(@".\Archivos\usuarios.pas", FileMode.Create, FileAccess.Write);

                                formatear.Serialize(archivo1, datosUsuarioLeido);

                                archivo1.Close();
                                Console.Clear();

                                Console.WriteLine("Usuario Eliminado.");

                                System.Threading.Thread.Sleep(4000);
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
            Boolean repetirPrograma = true;

            while (repetirPrograma)
            {
                try
                {
                    AnnadirUsuariosClinica();
                    Login();







                    Console.ReadKey();
                    repetirPrograma = false;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido algo mal. Introduce de nuevo los datos.");
                    System.Threading.Thread.Sleep(5000);

                    Console.Clear();
                }
            }
        }
    }
}
