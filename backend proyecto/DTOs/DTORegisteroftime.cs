﻿using System.Threading;
using backend_proyecto.model;

namespace backend_proyecto.DTOs
{
        public class DTORegisteroftime
        {
            public int Id { get; set; }
            public int EmpleadoId { get; set; }
            public int TareaId { get; set; }
             public bool IsDeleted { get; set; }
              public DateTime Fecha { get; set; }
            public DateTime HoraInicio { get; set; }
            public DateTime HoraFin { get; set; }
            public  string Descripcion { get; set; }

        }
    }
