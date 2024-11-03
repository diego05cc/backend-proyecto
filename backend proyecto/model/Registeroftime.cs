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
            public DateTime HoraInicio { get; set; }
            public DateTime HoraFin { get; set; }
            public  string Descripcion { get; set; }
            public virtual Employed Employed { get; set; }
            public virtual Tasks Tasks { get; set; }
        }
    }
