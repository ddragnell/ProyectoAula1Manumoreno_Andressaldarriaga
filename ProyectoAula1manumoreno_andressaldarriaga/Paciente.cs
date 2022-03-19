using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1manumoreno_andressaldarriaga
{
    class Paciente
    {
        private string apellido;
        private DateTime fechaIngresoEps;
        private string enfermedadRelevante;
        private Double costosTratamientos;
        private string tipoRegimen;
        private int cantidadEnfermedades;
        private string eps;
        private string tipoAfiliacion;
        private string id;
        private string nombre;
        private string historiaClinica;
        private DateTime fechaNacimiento;
        private DateTime fechaIngresoSistem;
        private int semanasCotizadas;

        public Paciente(string apellido, DateTime fechaIngresoEps, string enfermedadRelevante, 
            double costosTratamientos, string tipoRegimen, int cantidadEnfermedades, string eps, 
            string tipoAfiliacion, string id, string nombre, string historiaClinica, DateTime fechaNacimiento, 
            DateTime fechaIngresoSistem, int semanasCotizadas)
        {
            this.apellido = apellido;
            this.fechaIngresoEps = fechaIngresoEps;
            this.enfermedadRelevante = enfermedadRelevante;
            this.costosTratamientos = costosTratamientos;
            this.tipoRegimen = tipoRegimen;
            this.cantidadEnfermedades = cantidadEnfermedades;
            this.eps = eps;
            this.tipoAfiliacion = tipoAfiliacion;
            this.id = id;
            this.nombre = nombre;
            this.historiaClinica = historiaClinica;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaIngresoSistem = fechaIngresoSistem;
            this.semanasCotizadas = semanasCotizadas;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string HistoriaClinica { get => historiaClinica; set => historiaClinica = value; }
        public string EnfermedadRelevante { get => enfermedadRelevante; set => enfermedadRelevante = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public DateTime FechaIngresoSistem { get => fechaIngresoSistem; set => fechaIngresoSistem = value; }
        public DateTime FechaIngresoEps { get => fechaIngresoEps; set => fechaIngresoEps = value; }
        public double CostosTratamientos { get => costosTratamientos; set => costosTratamientos = value; }
        public string TipoRegimen { get => tipoRegimen; set => tipoRegimen = value; }
        public int SemanasCotizadas { get => semanasCotizadas; set => semanasCotizadas = value; }
        public int CantidadEnfermedades { get => cantidadEnfermedades; set => cantidadEnfermedades = value; }
        public string Eps { get => eps; set => eps = value; }
        public string TipoAfiliacion { get => tipoAfiliacion; set => tipoAfiliacion = value; }
    }

}
