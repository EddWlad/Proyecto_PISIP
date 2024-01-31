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
    public class PagoDiarioServicio
    {
        readonly IPagoDiarioRepository pagosdiariosRepository;
        public PagoDiarioServicio()
        {
            this.pagosdiariosRepository = new PagoDiarioRepository();
        }
        public IEnumerable<Pago_diario> ListarPagoDiarios()
        {
            return this.pagosdiariosRepository.GetAll();
        }
        public void InsertarPagos(Pago_diario nuevoPago)
        {
            this.pagosdiariosRepository.Add(nuevoPago);
        }
        public void ModificarPago(Pago_diario modificadoPago)
        {
            this.pagosdiariosRepository.Modify(modificadoPago);
        }
        public IEnumerable<PagoDiarioRegistro> ListarPagoDiarioFecha(DateTime fecha)
        {
            return this.pagosdiariosRepository.ListarPagosFecha(fecha);
        }
        public IEnumerable<PagoDiarioRegistro> ListarPagosDiariosActivos()
        {
            return this.pagosdiariosRepository.ListarPagosActivos();
        }
        public bool EliminarPago(int id)
        {
            return this.pagosdiariosRepository.ElminarPago(id);
        }
        public IEnumerable<PagoDiarioRegistro> ListarPagosTipo(String tipo)
        {
            return this.pagosdiariosRepository.ListarPagosTipoCliente(tipo);
        }
        public IEnumerable<PagoDiarioRegistro> ListarPagosCedula(String cedula)
        {
            return this.pagosdiariosRepository.ListarPagosCedula(cedula);
        }
    }
}
