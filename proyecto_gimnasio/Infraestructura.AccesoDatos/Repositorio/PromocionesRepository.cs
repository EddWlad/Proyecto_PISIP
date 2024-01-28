using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class PromocionesRepository : BaseRepository<Promociones>, IPromocionesRepository
    {
        public IEnumerable<Promociones> ListarPromocionesEstados(bool estado)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var promocionesEstados = from e in context.Promociones
                                            where e.estado == estado
                                            select e;
                    //3.- retorno resultado
                    return promocionesEstados.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Promociones> ListarPromocionesActivas()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var promocionesActivas = from e in context.Promociones
                                            where e.estado == true
                                            select e;
                    //3.- retorno resultado
                    return promocionesActivas.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Promociones> ListarPromocionesTipo(string tipo)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var promocionesTipo = from e in context.Promociones
                                          where e.descripcion == tipo
                                         select e;
                    //3.- retorno resultado
                    return promocionesTipo.ToList();
                }
            }
            catch (Exception ex)
            {
               throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
