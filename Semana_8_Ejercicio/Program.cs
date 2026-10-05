using System;

using System.CodeDom;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Security.Cryptography.X509Certificates;

using System.Text;

using System.Threading.Tasks;



namespace caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("-----------> Sistemas de notas <---------");
            Console.WriteLine("*****************************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("--> Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("--> Llegamos a la capacidad máxima");
                return;
            }
            Console.Write("--> Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("--> Ingresar nota: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("*****************************************");
                Console.WriteLine("-------------> Nota Invalida <-----------");
                Console.WriteLine("*****************************************");
                Console.WriteLine("Error: La nota debe ser [0-20]:");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }
        static public void mostrar()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("--------> Listado de Estudiantes <-------");
            Console.WriteLine("*****************************************");
            if (contador == 0)
            {
                Console.WriteLine("--> No hay datos por mostrar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("-->i"+ (i + 1) + ".-" + nombres[i] + "-Nota:" + notas[i]);
            }
        }
        static public void buscar_estudiante()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("--------> BUSCAR ESTUDIANTE <-------");
            Console.WriteLine("************************************");
            if (contador == 0)
            {
                Console.WriteLine("--> No hay estudiantes registrados");
                return;
            }
            Console.Write("--> Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("--> Estudiante encontrado: ");
                    Console.WriteLine("-->"+nombres[i] + "tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("--> Estudiante no encontrado...");
        }
        static public void modificar_nota()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("---------> Modificar Nota <---------");
            Console.WriteLine("************************************");
            if (contador == 0)
            {
                Console.WriteLine("--> No hay estudiantes registrados");
                return;
            }
            Console.Write("--> Ingresar nombre del estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("-->"+nombres[i] + "tiene " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("--> Ingresar la nueva nota: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("************************************");
                            Console.WriteLine("--> Nota modificada correctamente <--");
                            Console.WriteLine("************************************");
                            return;
                        }
                        Console.WriteLine("************************************");
                        Console.WriteLine("--> Nota fuera de rango [0-20] <--");
                        Console.WriteLine("************************************");
                    }
                }
                Console.WriteLine("--> Estudiante no encontrado...");
            }
        }
        static public void Mostrar()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("--------> LISTADO ORIGINAL <--------");
            Console.WriteLine("************************************");
            if (contador == 0)
            {
                Console.WriteLine("--> No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("--> "+"\t NOMBRE \t\tNOTAS");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("--> "+"\t" + nombres[i] + "\t\t" + notas[i]);
            }
        }
        static public void Seleccion()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("-> ORDENAMIENTO POR SELECCIÓN ASCENDENTE <-");
            Console.WriteLine("************************************");
            for (int i = 0; i < contador - 1; i++)
            {
                int posicionMenor = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] < notas[posicionMenor])
                    {
                        posicionMenor = j;
                    }
                }
                if (posicionMenor != i)
                {
                    double tempNota = notas[i];
                    notas[i] = notas[posicionMenor];
                    notas[posicionMenor] = tempNota;

                    string tempNombre = nombres[i];
                    nombres[i] = nombres[posicionMenor];
                    nombres[posicionMenor] = tempNombre;
                }
            }
            Mostrar();
        }
        static public void SeleccionDescendente()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("-> ORDENAMIENTO POR SELECCIÓN DESCENDENTE <-");
            Console.WriteLine("************************************");
            for (int i = 0; i < contador - 1; i++)
            {
                int posicionMayor = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[posicionMayor])
                    {
                        posicionMayor = j;
                    }
                }
                if (posicionMayor != i)
                {
                    double tempNota = notas[i];
                    notas[i] = notas[posicionMayor];
                    notas[posicionMayor] = tempNota;

                    string tempNombre = nombres[i];
                    nombres[i] = nombres[posicionMayor];
                    nombres[posicionMayor] = tempNombre;
                }
            }
            Mostrar();
        }
        static public void MostrarNotaMaxima()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("-----------> Nota Maxima <----------");
            Console.WriteLine("************************************");
            if (contador == 0)
            {
                Console.WriteLine("--> No hay estudiantes registrados");
                return;
            }
            double notaMaxima = notas[0];
            for (int i = 1; i < contador; i++)
            {
                if (notas[i] > notaMaxima)
                {
                    notaMaxima = notas[i];
                }
            }
            Console.WriteLine("--> La nota máxima es: " + notaMaxima);
            Console.WriteLine("--> Estudiantes con la nota máxima:");
            for (int i = 0; i < contador; i++)
            {
                if (notas[i] == notaMaxima)
                {
                    Console.WriteLine("--> " + nombres[i]);
                }
            }
        }
        static public void MostrarPromedio()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("--------> Promedio General <--------");
            Console.WriteLine("************************************");
            if (contador == 0)
            {
                Console.WriteLine("--> No hay estudiantes registrados");
                return;
            }
            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];
            }
            double promedio = suma / contador;
            Console.WriteLine("--> El promedio general es: " + promedio);
        }
        static public void burbuja()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("-> ORDENAMIENTO POR SELECCIÓN ASCENDENTE <-");
            Console.WriteLine("************************************");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - 1 - i; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;
                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 10)
            {
                Console.WriteLine("************************************");
                Console.WriteLine("--------> MENU PRINCIPAL <----------");
                Console.WriteLine("************************************");
                Console.WriteLine("--> [1]Registrar estudiante");
                Console.WriteLine("--> [2]Buscar estudiantes");
                Console.WriteLine("--> [3]Modificar nota");
                Console.WriteLine("--> [4]Mostrar lista sin ordenar");
                Console.WriteLine("--> [5]Modificar nota");
                Console.WriteLine("--> [6]Mostrar reporte ordenado por selección ascendente");
                Console.WriteLine("--> [7]Mostrar reporte ordenado por selección descendente");
                Console.WriteLine("--> [8]Mostrar nota máxima");
                Console.WriteLine("--> [9] Mostrar promedio general");
                Console.WriteLine("--> [10]Mostrar reporte ordenado por burbuja");
                Console.WriteLine("--> [11]Salir");
                Console.Write("--> Ingresar opcion: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        modificar_nota();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        modificar_nota();
                        break;
                    case 6:
                        Seleccion();
                        break;
                    case 7:
                        SeleccionDescendente();
                        break;
                    case 8:
                        MostrarNotaMaxima();
                        break;
                    case 9:
                        MostrarPromedio();
                        break;
                    case 10:
                        burbuja();
                        break;
                    case 11:
                        Console.WriteLine("--> Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("--> Opcion incorrecta..!!");
                        break;
                }
            }
        }
    }
}
