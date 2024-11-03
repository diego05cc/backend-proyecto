using System.Threading;
namespace backend_proyecto.model
{
        public class Registeroftime
        {
            public int Id { get; set; }
            public int EmpleadoId { get; set; }
            public int TareaId { get; set; }
             public bool IsDeleted { get; set; }
              public DateTime Fecha { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
            public  string Descripcion { get; set; }
            public  Employed Employed { get; set; }
            public  Tasks Tasks { get; set; }
        }
    }
