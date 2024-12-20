﻿namespace backend_proyecto.model
{
    public class Employed
    {
        public int Employed_Id { get; set; }
        public  string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime FechaIngreso{ get; set; }
        public List<Employedproject> Employedprojects { get; set; }
        public List<Registeroftime> RegistrosDeTiempo { get; set; }
    }
}

