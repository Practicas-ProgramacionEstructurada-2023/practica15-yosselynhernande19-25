﻿using System;
using System.IO;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class consultaMedica
        {
            public string? NombrePaciente { get; set; }
            public DateTime FechaCita { get; set; }
            public string? RazonConsulta { get; set; }
            public double costoConsulta { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n---------CITAS PARA CLINICA DENTISTA----------");
            Console.Write("\nIngrese la cantidad de citas a crear: ");
            int cantidadCitas = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= cantidadCitas; i++)
            {
                consultaMedica consulta = new consultaMedica();

                Console.WriteLine($"Ingrese los datos para la cita {i}: ");
                Console.Write("Nombre del paciente: ");
                consulta.NombrePaciente = Console.ReadLine();

                Console.Write("Fecha de la cita (DD/MM/YYYY HH:MM): ");
                consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Razón de la consulta: ");
                consulta.RazonConsulta = Console.ReadLine();

                Console.Write("Costo de la consulta: ");
                consulta.costoConsulta = Convert.ToDouble(Console.ReadLine());

                //Crear el nombre del archivo según el formato especificado
                string nombreArchivo = $"Cita{i:D3}";
                GuardarConsultaEnArchivo(consulta, nombreArchivo);
            }

            Console.WriteLine("Citas guardadas exitosamente.\n");

        }

        static void GuardarConsultaEnArchivo(consultaMedica consulta, string nombreArchivo)
        {
            //Agregar el numero de iteraciones al nombre del archivo
            string nombreCompleto = $"{nombreArchivo}#{consulta.NombrePaciente}.txt";

            //Crear el contenido del archivo
            string contenido =  $"Nombre del Paciente: {consulta.NombrePaciente}\n" +
                                $"Fecha de Cita: {consulta.FechaCita}\n" +
                                $"Razón de Consulta: {consulta.RazonConsulta}\n" +
                                $"Costo de Consulta: {consulta.costoConsulta}\n";

            //Guardar el contenido en el archivo
            File.WriteAllText(nombreCompleto, contenido);

            Console.WriteLine($"\nCita guardada en el archivo: {nombreCompleto}");
        }
    }

}
