using System;
using System.Collections.Generic;
using System.IO;

// Definición de la clase Estudiante
class Estudiante
{
    public string Nombre { get; set; }
    public Estudiante Siguiente { get; set; }
    public Calificaciones Calificaciones { get; set; }

    public Estudiante(string nombre)
    {
        Nombre = nombre;
        Siguiente = null;
        Calificaciones = new Calificaciones();
    }
}

// Definición de la clase Calificaciones
class Calificaciones
{
    public List<double> Notas { get; set; }

    public Calificaciones()
    {
        Notas = new List<double>();
    }
}

class Program
{
    static void Main()
    {
        // Lee el archivo con información de estudiantes (cada línea contiene el nombre)
        string rutaArchivo = @"C:\Users\alexa\OneDrive\estudiantes.txt"; // Cambia esto por la ruta correcta
        List<Estudiante> listaEstudiantes = new List<Estudiante>();

        try
        {
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    // Crea un nuevo estudiante y agrega a la lista
                    Estudiante nuevoEstudiante = new Estudiante(linea);
                    listaEstudiantes.Add(nuevoEstudiante);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo no existe o no se puede abrir.");
            return;
        }

        // Agrega calificaciones ficticias a cada estudiante (cinco calificaciones por estudiante)
        foreach (Estudiante estudiante in listaEstudiantes)
        {
            for (int i = 0; i < 5; i++)
            {
                double nota = GenerarNotaAleatoria(); // Función para generar notas aleatorias
                estudiante.Calificaciones.Notas.Add(nota);
            }
        }

        // Imprime la información de los estudiantes
        foreach (Estudiante estudiante in listaEstudiantes)
        {
            Console.WriteLine($"Estudiante: {estudiante.Nombre}");
            Console.WriteLine("Calificaciones:");
            foreach (double nota in estudiante.Calificaciones.Notas)
            {
                Console.WriteLine($"  - {nota}");
            }
            Console.WriteLine();
        }
    }

    // Función para generar notas aleatorias (solo para ejemplo)
    static double GenerarNotaAleatoria()
    {
        Random rand = new Random();
        return rand.NextDouble() * 10; // Notas entre 0 y 10
    }
}

