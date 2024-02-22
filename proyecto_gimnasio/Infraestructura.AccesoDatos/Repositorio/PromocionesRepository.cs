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
        public bool ElminarPromocion(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var promocion = context.Promociones.FirstOrDefault(c => c.id_promocion == id);
                    if (promocion != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        promocion.estado = false;


                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de cliente es nulo");

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo actualizar el registro del cliente.", ex);

            }
        }
        public void ModificarPromocion(Promociones promocionActualizada)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var promocion = context.Promociones.FirstOrDefault(c => c.id_promocion == promocionActualizada.id_promocion);
                    if (promocion != null)
                    {
                        // 2.- Actualizar los campos necesarios
                        promocion.fecha_registro = promocionActualizada.fecha_registro;
                        promocion.descripcion = promocionActualizada.descripcion;
                        promocion.fecha_inicio = promocionActualizada.fecha_inicio;
;                       promocion.fecha_fin = promocionActualizada.fecha_fin;

                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();

                    }
                    else
                    {
                        throw new Exception("El valor de cliente es nulo");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el registro del cliente.", ex);
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
                                          where e.descripcion == tipo && e.estado == true
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

        public IEnumerable<Promociones> ListarPromocionesVigentes(DateTime fechaActual)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var promocionesActivas = from e in context.Promociones
                                             where e.estado == true && e.fecha_fin >= fechaActual
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
    }
}
