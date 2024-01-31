using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class MembresiasRepository : BaseRepository<Membresias>, IMembresiasRepository
    {
        public bool ElminarMmebresia(int id)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    var membresia = context.Membresias.FirstOrDefault(c => c.id_membresia == id);
                    if (membresia != null)
                    {
                        membresia.estado = false;
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("El valor de membresia es nulo");

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se pudo actualizar el registro del cliente.", ex);

            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> ListarMembresiasActivas()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasActivas = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,
                                
                        }).Where(membresia => membresia.estado.Equals(true)).ToList();
                    //3.- retorno resultado
                    return membresiasActivas.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> MembresiaCosto(decimal valor)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasCosto = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,

                            }).Where(membresia => membresia.estado.Equals(true) && membresia.costo.Equals(valor)).ToList();
                    //3.- retorno resultado
                    return membresiasCosto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> MembresiaFechaFin(DateTime fecha_fin)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasFecha = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,

                            }).Where(membresia => membresia.estado.Equals(true) && membresia.fecha_fin.Equals(fecha_fin)).ToList();
                    //3.- retorno resultado
                    return membresiasFecha.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> MembresiaFechaInicio(DateTime fecha_inicio)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasFecha = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,

                            }).Where(membresia => membresia.estado.Equals(true) && membresia.fecha_inicio.Equals(fecha_inicio)).ToList();
                    //3.- retorno resultado
                    return membresiasFecha.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> MembresiaFechaRegistro(DateTime fecha_registro)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasFecha = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,

                            }).Where(membresia => membresia.estado.Equals(true) && membresia.fecha_registro.Equals(fecha_registro)).ToList();
                    //3.- retorno resultado
                    return membresiasFecha.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> MembresiaPromocion(string promociones)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasPromocion = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,

                            }).Where(membresia => membresia.estado.Equals(true) && membresia.promocion.Equals(promociones)).ToList();
                    //3.- retorno resultado
                    return membresiasPromocion.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }

        public IEnumerable<MembresiaTipoCostoPromocion> MembresiaTipos(string tipos)
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasTipos = context.Membresias.
                        Join(context.Tipo_Membresia,
                            membresia => membresia.id_tipo_membresia,
                            tipo => tipo.id_tipo_membresia,
                            (membresia, tipo) => new { Membresia = membresia, Tipo = tipo })
                       .Join(context.Costo_Membresia,
                            membresiaTipo => membresiaTipo.Membresia.id_costo_membresia,
                            costo => costo.id_costo_membresia,
                            (membresiaTipo, costo) => new { MembresiaTipo = membresiaTipo, Costo = costo })
                       .Join(context.Promociones,
                            membresiaTipoCosto => membresiaTipoCosto.MembresiaTipo.Membresia.id_promocion,
                            promocion => promocion.id_promocion,
                            (membresiaTipoCosto, promocion) => new MembresiaTipoCostoPromocion
                            {
                                id_membresia = membresiaTipoCosto.MembresiaTipo.Membresia.id_membresia,
                                fecha_registro = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_registro,
                                descripcion = membresiaTipoCosto.MembresiaTipo.Membresia.descripcion,
                                fecha_inicio = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_inicio,
                                fecha_fin = (DateTime)membresiaTipoCosto.MembresiaTipo.Membresia.fecha_fin,
                                estado = membresiaTipoCosto.MembresiaTipo.Membresia.estado,
                                tipoMembresia = membresiaTipoCosto.MembresiaTipo.Tipo.descripcion,
                                costo = (decimal)membresiaTipoCosto.Costo.valor,
                                promocion = promocion.descripcion,

                            }).Where(membresia => membresia.estado.Equals(true) && membresia.tipoMembresia.Equals(tipos)).ToList();
                    //3.- retorno resultado
                    return membresiasTipos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
            }
        }
    }
}
