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
        public IEnumerable<Membresias> ListarMembresiasEstados(bool estado)
        {
            //1.- conectar a la base
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasEstados = from e in context.Membresias
                                          where e.estado == estado
                                          select e;
                    //3.- retorno resultado
                    return membresiasEstados.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registro.", ex);
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

        //public IEnumerable<Membresias> ListarMembresiasTipo(string tipo)
        //{
            //1.- conectar a la base
            //try
            //{
                //using (var context = new gestion_membresiasEntities())
               // {
                    //2.- escribil la consulta
                   // var membresiasTipo = from e in context.Membresias
                                         //where e.tipo == tipo
                                         //select e;
                    ////3.- retorno resultado
                    //return membresiasTipo.ToList();
                //}
            //}
            //catch (Exception ex)
            //{
                //throw new Exception("No se pudieron recuperar los registro.", ex);
            //}
        //}
    }
}
