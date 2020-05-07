﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesBase;

namespace Vistas
{
    public partial class FrmAltaUsuario : Form
    {
        public FrmAltaUsuario()
        {
            InitializeComponent();
            cargarRol();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsu = new Usuario();

            nuevoUsu.Usu_NombreUsuario = txtNombreUsuario.Text;
            nuevoUsu.Usu_Contraseña = txtPass.Text;
            nuevoUsu.Usu_ApellidoNombre = txtNombreApellidoUsuario.Text;
            nuevoUsu.Rol_Codigo = cmbRol.Text;

            TrabajoUsuario.AgregarUsuario(nuevoUsu);
        }
        public void cargarRol()
        {
            cmbRol.DataSource = TrabajoRol.cargarRol();
        }
    }
}
