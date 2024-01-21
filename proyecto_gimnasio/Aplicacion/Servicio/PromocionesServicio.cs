using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class PromocionesServicio
    {
        readonly IPromocionesRepository promocionesRepository;
        public PromocionesServicio()
        {
            this.promocionesRepository = new PromocionesRepository();
        }
        public IEnumerable<Promociones> ListarPromociones()
        {
            return this.promocionesRepository.GetAll();
        }
        public void InsertarPromociones(Promociones nuevaPromocion)
        {
            this.promocionesRepository.Add(nuevaPromocion);
        }
        public void ModificarPromociones(Promociones modificadoPromocion)
        {
            this.promocionesRepository.Modify(modificadoPromocion);
        }
        public IEnumerable<Promociones> ListarPromocionesTipo(String tipo)
        {
            return this.promocionesRepository.ListarPromocionesTipo(tipo);
        }
        public IEnumerable<Promociones> ListarPromocionesActivas()
        {
            return this.promocionesRepository.ListarPromocionesActivas();
        }
        public IEnumerable<Promociones> ListarPromocionesEstado(Boolean estado)
        {
            return this.promocionesRepository.ListarPromocionesEstados(estado);
        }
    }
}
