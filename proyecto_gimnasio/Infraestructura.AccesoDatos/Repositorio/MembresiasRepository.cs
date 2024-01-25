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

        public IEnumerable<Membresias> ListarMembresiasActivas()
        {
            try
            {
                using (var context = new gestion_membresiasEntities())
                {
                    //2.- escribil la consulta
                    var membresiasActivas = from e in context.Membresias
                                          where e.estado == true
                                          select e;
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
