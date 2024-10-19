using System.Threading;
namespace backend_proyecto.model
{
        public class RegistroDeTiempo
        {
            public int Id { get; set; }
            public int EmpleadoId { get; set; }
            public int TareaId { get; set; }
            public DateTime Fecha { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
            public required string Descripcion { get; set; }
            public required Empleado Empleado { get; set; }
            public required Tarea Tarea { get; set; }
        }
    }
