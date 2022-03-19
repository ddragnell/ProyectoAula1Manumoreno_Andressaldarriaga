
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1manumoreno_andressaldarriaga
{
    class Program
    {
        string sura = "Sura";
        string nuevaEPS = "NuevaEPS";
        string saludTotal = "Saludtotal";
        string sanitas = "Sanitas";
        string savia = "Savia";
        string contributivo = " contributivo";
        string subsidiado = "subsidiado";
        string cotizante = "cotizante";
        string beneficiario = "beneficiario";
        string cancer = "Cáncer";
        List<Paciente> pacientes = new List<Paciente>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();
        }
        public void Menu()
        {
            Boolean menu = true;
            while (menu)
            {
                Console.WriteLine("Seleccione la opción que desea: ");
                Console.WriteLine("1. Ingresar paciente \n 2. Cambiar de EPS \n 3. Mostrar estadísticas \n 4.Salir");
                int opcion = Convert.ToInt16(Console.ReadLine());
                do
                {
                    switch (opcion)
                    {
                        case 1:
                            CrearPaciente();
                            opcion = 4;
                            break;
                        case 2:
                            CambiarEPS();

                            opcion = 4;
                            break;
                        case 3:
                            Console.WriteLine("El total de costos por EPS es igual a: ");
                            PorcentajeCostosEps();
                            TotalCostosPorEps();
                            Console.WriteLine("El porcentaje de pacientes sin enfermedades es igual a "
                                + PorcentajePacSinEnfermedades() + "%");
                            PacienteConMayoresCostos();
                            PorcentajePacientesPorRangoEdad();
                            PorcentajePorTipoRegimen();
                            PorcentajePorTipoAfiliacion();
                            Console.WriteLine("El total de pacientes cuya enfermedad relevante es cáncer es "
                                + TotalPacientesEnfermedadRelevanteCancer());

                            opcion = 4;
                            break;
                        case 4:
                            menu = false;
                            Console.WriteLine("Usted va a salir del programa ");
                            break;
                        default:
                            Console.WriteLine("Seleccione la opción que desea: ");
                            Console.WriteLine("1. Ingresar paciente \n 2. Cambiar de EPS \n 3. Mostrar estadísticas \n 4.Salir");
                            break;
                    }
                } while (opcion != 4);
            }
            Console.ReadKey();
        }

        public void CrearPaciente()
        {
            string id, nombre, apellido, tipoRegimen, EPS;
            string historiaclinica, enfermedadRelevante, tipoAfiliacion;
            DateTime fechaIngresoSistem, fechaIngresoEps, fechaNacimiento;
            int cantidadEnfermedades, semanasCotizadas;
            double costosTratamientos;


            Console.WriteLine("ingrese el id del paciente");
            id = Console.ReadLine();
            Console.WriteLine("ingrese el nombre del paciente ");
            nombre = Console.ReadLine();
            Console.WriteLine("ingrese el apellido del paciente ");
            apellido = Console.ReadLine();
            Console.WriteLine("ingrese el tipo de regimen del paciente ");
            tipoRegimen = Console.ReadLine();
            Console.WriteLine("ingrese la EPS del paciente ");
            EPS = Console.ReadLine();
            Console.WriteLine("ingrese la historia clínica del paciente ");
            historiaclinica = Console.ReadLine();
            Console.WriteLine("ingrese la enfermedad mas relevante del paciente ");
            enfermedadRelevante = Console.ReadLine();
            Console.WriteLine("ingrese el tipo de afiliacion del paciente ");
            tipoAfiliacion = Console.ReadLine();
            Console.WriteLine("ingrese la fecha de nacimiento del paciente ");
            fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("ingrese la fecha de ingreso del paciente al sistema ");
            fechaIngresoSistem = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("ingrese la fecha de ingreso del paciente a la EPS ");
            fechaIngresoEps = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("ingrese cantidad de enfermedades del paciente ");
            cantidadEnfermedades = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ingrese el numero de semanas cotizadas del paciente ");
            semanasCotizadas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ingrese el total de costos en tratamientos del paciente ");
            costosTratamientos = Convert.ToDouble(Console.ReadLine());
            Paciente paciente = new Paciente(apellido, fechaIngresoEps, enfermedadRelevante, costosTratamientos, tipoRegimen,
                cantidadEnfermedades, EPS, tipoAfiliacion, id, nombre, historiaclinica, fechaNacimiento, fechaIngresoSistem, semanasCotizadas);
            pacientes.Add(paciente);

        }
        public void CambiarEPS()
        {
            string id, epsCambio;
            Console.WriteLine("Ingrese la identificacion del paciente a cambiar EPS");
            id = Console.ReadLine();
            Console.WriteLine("Ingrese la EPS a la que desea cambiarse");
            epsCambio = Console.ReadLine();
            Boolean contEntro = false;
            foreach (Paciente pac in pacientes)
            {
                var tiempo = (DateTime.Now - pac.FechaIngresoEps).TotalDays;
                if (pac.Id == id)
                {
                    if (tiempo > 90)
                    {
                        contEntro = true;
                        pac.Eps = epsCambio;
                        Console.WriteLine("La EPS del usuario de id {0} se ha cambiado a la EPS {1}", id, epsCambio);
                        break;
                    }
                    else
                    {
                        contEntro = true;
                        Console.WriteLine("No es posible realizar cambio de EPS a un usuario que lleve menos de " +
                            "tres meses como miembro de una EPS");
                        break;
                    }
                }
            }
            if (contEntro == false)
            {
                Console.WriteLine("La id ingresa no se encuentra registarada en el sistema");
            }
        }
        public double CostosEps(string eps)
        {
            double contTotalEps = 0;
            foreach (Paciente pac in pacientes)
            {
                if (pac.Eps == eps)
                {
                    contTotalEps += pac.CostosTratamientos;
                }

            }
            return contTotalEps;
        }
        public double TotalCostosEPS()
        {
            double contNuevaEps = 0, contSaludTotal = 0, contSanitas = 0, contSavia = 0, contSura = 0;
            contNuevaEps = CostosEps(nuevaEPS);
            contSaludTotal = CostosEps(saludTotal);
            contSanitas = CostosEps(sanitas);
            contSavia = CostosEps(savia);
            contSura = CostosEps(sura);
            return contNuevaEps + contSaludTotal + contSanitas + contSavia + contSura;
        }
        public void PorcentajeCostosEps()
        {
            double total = TotalCostosEPS();
            Console.WriteLine("El porcentaje de costos de Sura es :", (CostosEps(sura) / total) * 100, "%");
            Console.WriteLine("El porcentaje de costos de Salud Total es :", (CostosEps(saludTotal) / total) * 100, "%");
            Console.WriteLine("El porcentaje de costos de Nueva EPS es :", (CostosEps(nuevaEPS) / total) * 100, "%");
            Console.WriteLine("El porcentaje de costos de Sanitas es :", (CostosEps(sanitas) / total) * 100, "%");
            Console.WriteLine("El porcentaje de costos de Savia es :", (CostosEps(savia) / total) * 100, "%");
        }
        public void TotalCostosPorEps()
        {
            Console.WriteLine("El total de costos de Sura es : ", (CostosEps(sura)));
            Console.WriteLine("El total de costos de Salud Total es : ", (CostosEps(saludTotal)));
            Console.WriteLine("El total de costos de Nueva EPS es : ", (CostosEps(nuevaEPS)));
            Console.WriteLine("El total de costos de Sanitas es : ", (CostosEps(sanitas)));
            Console.WriteLine("El total de costos de Savia es : ", (CostosEps(savia)));
        }
        public int TotalPacientes()
        {
            int contPacientes = 0;
            foreach (Paciente pac in pacientes)
            {
                contPacientes += 1;
            }
            return contPacientes;
        }
        public double PorcentajePacSinEnfermedades()
        {
            int contPacSinEnfermedades = 0;
            foreach (Paciente pac in pacientes)
            {
                if (pac.CantidadEnfermedades is 0)
                {
                    contPacSinEnfermedades += 1;
                }

            }
            return (contPacSinEnfermedades / TotalPacientes()) * 100;
        }
        public void PacienteConMayoresCostos()
        {
            var orderAsc = pacientes.OrderBy(x => x.CostosTratamientos).ToList();   
            var primero = orderAsc.First();
            Console.WriteLine("El paciente con mayor costo en los tratamientos es {0} con id:{1} " +
                "y un total de costos de", primero.Nombre, primero.Id, primero.CostosTratamientos);
        }
        public int CalcularEdad(DateTime edad)
        {
            var tiempo = (DateTime.Now.Year - edad.Year);
            return tiempo;
        }
        public int ConteoPorRangoEdad(int inicioRango, int limitRango)
        {
            var rango = pacientes.Where(x => limitRango > CalcularEdad(x.FechaNacimiento)).ToList();
            return rango.Where(x => inicioRango <= CalcularEdad(x.FechaNacimiento)).Count();


        }
        public void PorcentajePacientesPorRangoEdad()
        {
            Console.WriteLine("Porcentaje de pacientes niños es " + (ConteoPorRangoEdad(0, 12) / TotalPacientes()) * 100);
            Console.WriteLine("Porcentaje de pacientes adolescente es " + (ConteoPorRangoEdad(12, 18) / TotalPacientes()) * 100);
            Console.WriteLine("Porcentaje de pacientes joven es " + (ConteoPorRangoEdad(18, 30) / TotalPacientes()) * 100);
            Console.WriteLine("Porcentaje de pacientes adulto es " + (ConteoPorRangoEdad(30, 55) / TotalPacientes()) * 100);
            Console.WriteLine("Porcentaje de pacientes adulto mayor es " + (ConteoPorRangoEdad(55, 75) / TotalPacientes()) * 100);
            Console.WriteLine("Porcentaje de pacientes ancianos es " + (ConteoPorRangoEdad(75, 200) / TotalPacientes()) * 100);

        }
        public int ConteoTipoRegimen(string regimen)
        {
            int contRegimen = 0;
            foreach (Paciente pac in pacientes)
            {
                if (pac.TipoRegimen == regimen)
                {
                    contRegimen += 1;
                }
            }
            return contRegimen;
        }
        public void PorcentajePorTipoRegimen()
        {
            Console.WriteLine("El porcentaje de pacientes con regimen tipo contributivo es igual a " 
                + (ConteoTipoRegimen(contributivo)/TotalPacientes())*100);
            Console.WriteLine("El porcentaje de pacientes con regimen tipo subsidiado es igual a "
                + (ConteoTipoRegimen(subsidiado) / TotalPacientes()) * 100);
        }
        public int ConteoTipoAfiliacion(string afiliacion)
        {
            int contAfiliacion = 0;
            foreach (Paciente pac in pacientes)
            {
                if (pac.TipoAfiliacion == afiliacion)
                {
                    contAfiliacion += 1;
                }
            }
            return contAfiliacion;
        }
        public void PorcentajePorTipoAfiliacion()
        {
            Console.WriteLine("El porcentaje de pacientes con afiliación tipo cotizante es igual a "
                + (ConteoTipoAfiliacion(cotizante) / TotalPacientes()) * 100);
            Console.WriteLine("El porcentaje de pacientes con afiliación tipo beneficiario es igual a "
                + (ConteoTipoAfiliacion(beneficiario) / TotalPacientes()) * 100);
        }
        public int TotalPacientesEnfermedadRelevanteCancer()
        {
            return pacientes.Where(x => cancer == x.EnfermedadRelevante).Count();
        }       
    }
}
