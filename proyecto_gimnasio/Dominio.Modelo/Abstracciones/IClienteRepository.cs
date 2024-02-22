﻿using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        IEnumerable<ClienteTipoCliente> ListarClienteNombre(String nombre);
        IEnumerable<ClienteTipoCliente> ListarClienteMembresia(String membresia);
        IEnumerable<ClienteTipoCliente> ListarClientesActivos();
        IEnumerable<ClienteMembresiaCosto> ListarClientesActivosMiembros();
        IEnumerable<ClienteMembresiaCosto> ClientesActivos();


        bool ElminarCliente(int id);
        IEnumerable<ClienteTipoCliente> ListarClientesTipo(string tipo);
        IEnumerable<ClienteTipoCliente> ListarClientesCedula(string cedula);
        IEnumerable<ClienteMembresiaCosto> ListarClientesCedulaMiembros(string cedula);
        void Guardarfoto(int idCliente, byte[] foto);
    }
}

