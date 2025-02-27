using System;
using System.IO;

class Program
{
    static void Main()
    {
        CrearCarpetasIniciales();  // Crear las carpetas iniciales necesarias para el programa
        Console.WriteLine("\n\t*********************************************");
        Console.WriteLine("\t¡Bienvenido a la base de datos de Tony Stark!");
        Console.WriteLine("\t***********************************************\n");

        // Menú interactivo
        while (true)
        {
            Console.Clear();  // Limpiar la consola antes de mostrar el menú
            Console.WriteLine("\t-=-=-=-=-= ¿COMO PUEDO AYUDARTE EL DIA HOY? -=-=-=-=-=\n");
            // Mostrar opciones del menú sin colores
            Console.WriteLine("1. Crear Archivo");
            Console.WriteLine("2. Agregar Inventos");
            Console.WriteLine("3. Leer Archivo Línea por Línea");
            Console.WriteLine("4. Leer Todo el texto");
            Console.WriteLine("5. Copiar y Eliminar Archivo");
            Console.WriteLine("6. Mover Archivo");
            Console.WriteLine("7. Crear Carpeta 'ProyectosSecretos'");
            Console.WriteLine("8. Listar Archivos y Carpetas");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();  // Leer la opción ingresada por el usuario
            Console.Clear();  // Limpiar la consola después de seleccionar una opción

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("1. Crear Archivo\n");
                    CrearArchivo();  // Llamar a la función para crear un archivo
                    break;
                case "2":
                    Console.WriteLine("2. Agregar Inventos\n");
                    if (VerificarExistenciaArchivo())  // Verificar si el archivo existe
                        AgregarInventos();  // Llamar a la función para agregar inventos
                    break;
                case "3":
                    Console.WriteLine("3. Leer Archivo Línea por Línea\n");
                    if (VerificarExistenciaArchivo())  // Verificar si el archivo existe
                        LeerLineaPorLinea();  // Llamar a la función para leer el archivo línea por línea
                    break;
                case "4":
                    Console.WriteLine("4. Leer Todo el texto\n");
                    if (VerificarExistenciaArchivo())  // Verificar si el archivo existe
                        LeerTodoElTexto();  // Llamar a la función para leer todo el texto del archivo
                    break;
                case "5":
                    Console.WriteLine("5. Copiar y Eliminar Archivo\n");
                    if (VerificarExistenciaArchivo())  // Verificar si el archivo existe
                        CopiarYEliminarArchivo();  // Llamar a la función para copiar y eliminar el archivo
                    break;
                case "6":
                    Console.WriteLine("6. Mover Archivo\n");
                    if (VerificarExistenciaArchivo())  // Verificar si el archivo existe
                        MoverArchivo();  // Llamar a la función para mover el archivo
                    break;
                case "7":
                    Console.WriteLine("7. Crear Carpeta 'ProyectosSecretos'\n");
                    CrearCarpetaProyectosSecretos();  // Llamar a la función para crear la carpeta 'ProyectosSecretos'
                    break;
                case "8":
                    Console.WriteLine("8. Listar Archivos y Carpetas\n");
                    ListadoDeArchivosYCarpetas();  // Llamar a la función para listar archivos y carpetas
                    break;
                case "9":
                    Console.WriteLine("\nSaliendo del programa...");
                    return;  // Salir del programa
                default:
                    Console.WriteLine("\nOpción no válida, intente nuevamente.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal.");
            Console.ReadKey();  // Esperar a que el usuario presione una tecla antes de volver al menú
        }
    }

    static void CrearCarpetasIniciales()
    {
        try
        {
            // Crear directorios iniciales necesarios para el programa
            Directory.CreateDirectory("c:/LaboratorioAvengers");
            Directory.CreateDirectory("c:/LaboratorioAvengers/Backup");
            Directory.CreateDirectory("c:/LaboratorioAvengers/ArchivosClasificados");
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al crear los directorios y mostrar un mensaje de error
            Console.WriteLine("Error al crear los directorios iniciales: " + ex.Message);
        }
    }

    static void CrearArchivo()
    {
        string path = "c:/LaboratorioAvengers/inventos.txt";

        try
        {
            // Crear un archivo si no existe y escribir un contenido inicial
            if (!File.Exists(path))  // Verificar si el archivo no existe
            {
                File.WriteAllText(path, "Este archivo fue creado por Tony Stark.\n");
                Console.WriteLine("\nArchivo creado con éxito. - Tony Stark");
            }
            else
            {
                Console.WriteLine("\nEl archivo ya existe.");
            }
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al crear el archivo y mostrar un mensaje de error
            Console.WriteLine("\nError al crear el archivo: " + ex.Message);
        }
    }

    static void AgregarInventos()
    {
        string path = "c:/LaboratorioAvengers/inventos.txt";
        Console.Write("\nIngrese el número de inventos que desea agregar: ");
        int numeroDeInventos = int.Parse(Console.ReadLine());  // Leer el número de inventos a agregar

        try
        {
            // Usar un bucle for para agregar múltiples inventos al archivo
            for (int i = 0; i < numeroDeInventos; i++)
            {
                Console.WriteLine("*********************************************");
                Console.Write($"Ingrese el nombre del invento {i + 1}: ");
                string invento = Console.ReadLine();  // Leer el nombre del invento
                File.AppendAllText(path, invento + "\n");  // Agregar el invento al archivo
            }
            Console.WriteLine("\nInventos agregados.");
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al agregar los inventos y mostrar un mensaje de error
            Console.WriteLine("\nError al agregar los inventos: " + ex.Message);
        }
    }

    static void LeerLineaPorLinea()
    {
        string path = "c:/LaboratorioAvengers/inventos.txt";

        try
        {
            Console.WriteLine("\n************************************************");
            Console.WriteLine("\nEl archivo ha sido leído línea por línea:\n");
            string[] lineas = File.ReadAllLines(path);  // Leer todas las líneas del archivo
            // Usar un bucle for para mostrar cada línea del archivo con su número
            for (int i = 1; i < lineas.Length; i++)  // Empezar desde 1 para omitir el título
            {
                Console.WriteLine((i) + ". " + lineas[i]);  // Mostrar cada línea con su número
            }
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al leer el archivo y mostrar un mensaje de error
            Console.WriteLine("\nError al leer el archivo: " + ex.Message);
        }
    }

    static void LeerTodoElTexto()
    {
        string path = "c:/LaboratorioAvengers/inventos.txt";

        try
        {
            Console.WriteLine("\n**********************************************");
            Console.WriteLine("\nEl archivo ha sido leído completamente:\n");
            string contenido = File.ReadAllText(path);  // Leer todo el contenido del archivo
            Console.WriteLine(contenido);  // Mostrar el contenido del archivo
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al leer el archivo y mostrar un mensaje de error
            Console.WriteLine("\nError al leer el archivo: " + ex.Message);
        }
    }

    static void CopiarYEliminarArchivo()
    {
        string origen = "c:/LaboratorioAvengers/inventos.txt";
        string destino = "c:/LaboratorioAvengers/Backup/inventos(copia).txt";

        try
        {
            // Copiar el archivo a la carpeta de respaldo y luego eliminar el archivo original
            File.Copy(origen, destino, true);
            File.Delete(origen);
            Console.WriteLine("\nAlerta: Parece que alguien ha robado el archivo principal 'inventos.txt', ¡pero no te preocupes! Tenemos una copia de seguridad en 'Backup'. - Tony Stark");
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al copiar y eliminar el archivo y mostrar un mensaje de error
            Console.WriteLine("\nError al copiar y eliminar el archivo: " + ex.Message);
        }
    }

    static void MoverArchivo()
    {
        string origen = "c:/LaboratorioAvengers/inventos.txt";
        string destinoDirectorio = "c:/LaboratorioAvengers/ArchivosClasificados";  // Carpeta de destino
        string destinoArchivo = Path.Combine(destinoDirectorio, "inventos.txt");  // Ruta completa del archivo de destino

        try
        {
            // Mover el archivo a la carpeta de archivos clasificados
            File.Move(origen, destinoArchivo);
            Console.WriteLine("\nArchivo movido a " + destinoArchivo + " - Tony Stark");
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al mover el archivo y mostrar un mensaje de error
            Console.WriteLine("\nError al mover el archivo: " + ex.Message);
        }
    }

    static void CrearCarpetaProyectosSecretos()
    {
        try
        {
            // Crear la carpeta 'ProyectosSecretos'
            Directory.CreateDirectory("c:/LaboratorioAvengers/ProyectosSecretos");
            Console.WriteLine("\n******************************************************");
            Console.WriteLine("Carpeta 'ProyectosSecretos' creada exitosamente.");
            Console.WriteLine("******************************************************\n");
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al crear la carpeta y mostrar un mensaje de error
            Console.WriteLine("\nError al crear la carpeta 'ProyectosSecretos': " + ex.Message);
        }
    }

    static void ListadoDeArchivosYCarpetas()
    {
        string path = "c:/LaboratorioAvengers";

        try
        {
            if (Directory.Exists(path))  // Verificar si el directorio existe
            {
                Console.WriteLine("\nArchivos y carpetas en " + path + ":\n");

                // Listar todos los archivos en el directorio
                string[] archivos = Directory.GetFiles(path);
                Console.WriteLine("Archivos:");
                // Usar un bucle for para mostrar cada archivo con su número
                for (int i = 0; i < archivos.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Path.GetFileName(archivos[i]));
                }

                // Listar todas las carpetas en el directorio
                string[] carpetas = Directory.GetDirectories(path);
                Console.WriteLine("\nCarpetas:");
                // Usar un bucle for para mostrar cada carpeta con su número
                for (int i = 0; i < carpetas.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Path.GetFileName(carpetas[i]));
                }
            }
            else
            {
                // Mensaje de error si el directorio no existe
                Console.WriteLine("\nError: La base de datos fue analizada y no se pudo encontrar el directorio. - Tony Stark");
            }
        }
        catch (Exception ex)
        {
            // Capturar cualquier excepción que ocurra al listar archivos y carpetas y mostrar un mensaje de error
            Console.WriteLine("\nError al listar archivos y carpetas: " + ex.Message);
        }
    }

    static bool VerificarExistenciaArchivo()
    {
        string path = "c:/LaboratorioAvengers/inventos.txt";

        if (File.Exists(path))  // Verificar si el archivo existe
        {
            return true;  // El archivo existe
        }
        else
        {
            // Mensaje interactivo cuando el archivo no existe
            Console.WriteLine("\nUps, parece que el archivo 'inventos.txt' no existe. ¡Tony Stark debe haber olvidado crearlo!");
            return false;  // El archivo no existe
        }
    }
}