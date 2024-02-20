using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class CostoMembresiasRepository : BaseRepository<Costo_Membresia>, ICostoMembresiaRepository
    {
        public bool EliminarCostoMembresia(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    // 1.- Buscar el cliente a actualizar
                    var costoMembresia = context.Costo_Membresia.FirstOrDefault(c => c.id_costo_membresia == id);
                    if (costoMembresia != null)
                    {
                        // 2.- Actualizar los campos necesarios

                        costoMembresia.estado = false;

                        // 3.- Guardar los cambios en la base de datos
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de tipo es nulo");

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo borrar el registro del tipo.", ex);

            }
        }

        public IEnumerable<MembresiaTipoCosto> ListarCosto(decimal valor)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiaTipoCosto = context.Costo_Membresia.
                        Join(context.Tipo_Membresia,
                            costo => costo.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (costos, membresias) => new MembresiaTipoCosto
                            {
                                id_costo_membresia = costos.id_costo_membresia,
                                tipo_membresia = membresias.descripcion,
                                costo = (decimal)costos.valor,
                                estado = (bool)costos.estado
                            }).Where(p => p.estado.Equals(true) && p.costo.Equals(valor)).ToList();
                    //3.- retorno resultado
                    return membresiaTipoCosto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCosto> ListarCostoMembresia(string descripcion)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiaTipoCosto = context.Costo_Membresia.
                        Join(context.Tipo_Membresia,
                            costo => costo.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (costos, membresias) => new MembresiaTipoCosto
                            {
                                id_costo_membresia = costos.id_costo_membresia,
                                tipo_membresia = membresias.descripcion,
                                costo = (decimal)costos.valor,
                                estado = (bool)costos.estado
                            }).Where(p => p.estado.Equals(true) && p.tipo_membresia.Equals(descripcion)).ToList();
                    //3.- retorno resultado
                    return membresiaTipoCosto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<Costo_Membresia> ListarCostosMembresiasActivas()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var tiposActivos = from e in context.Costo_Membresia
                                       where e.estado == true
                                       select e;
                    //3.- retorno resultado
                    return tiposActivos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCosto> ListarMembresiasCostoTipo()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiaTipoCosto = context.Costo_Membresia.
                        Join(context.Tipo_Membresia,
                            costo => costo.id_tipo_membresia,
                            tipo=> tipo.id_tipo_membresia,
                            (costos, membresias) => new MembresiaTipoCosto
                            {
                                id_costo_membresia = costos.id_costo_membresia,
                                tipo_membresia = membresias.descripcion,
                                costo = (decimal)costos.valor,
                                estado = (bool)costos.estado
                            }).Where(p => p.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return membresiaTipoCosto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
