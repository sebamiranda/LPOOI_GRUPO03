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
    public partial class FrmAltaVehiculo : Form
    {
        public FrmAltaVehiculo()
        {
            InitializeComponent();
        }

        private void txtAModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.soloNumeros(e);
        }

        private void txtAPuertas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.soloNumeros(e);
        }

        private void txtAPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerosDecimales(e);
        }

        private void btnAltaVeh_Click(object sender, EventArgs e)
        {
            int m = Convert.ToInt32(txtAModelo.Text);
            int p = Convert.ToInt32(txtAPuertas.Text);
            decimal pre = Convert.ToDecimal(txtAPrecio.Text);
            Vehiculo vehiculo = new Vehiculo(txtAMatricula.Text,txtAMarca.Text,txtALinea.Text,m,txtAColor.Text,p,checkGps.Checked,txtATipo.Text,txtAClase.Text,pre);


            DialogResult result = MessageBox.Show("Los Datos ingresados son correctos? " + "\n" +
                                                   "Matricula: " + vehiculo.Veh_Matricula + "\n" + 
                                                   "Marca: " + vehiculo.Veh_Marca + "\n" + 
                                                   "Linea: " + vehiculo.Veh_Linea + "\n" + 
                                                   "Modelo: " + vehiculo.Veh_Modelo + "\n" + 
                                                   "Color: " + vehiculo.Veh_Color + "\n" +
                                                   "Puertas: " + vehiculo.Veh_Puertas + "\n" +
                                                   "GPS: " + vehiculo.Veh_GPS + "\n" +
                                                   "Tipo de Vehiculo: " + vehiculo.Veh_TipoVehiculo + "\n" +
                                                   "Clase de Vehiculo: " + vehiculo.Veh_ClaseVehiculo + "\n" +
                                                   "Precio: " + vehiculo.Veh_Precio, "Agregar Cliente", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                vehiculo = new Vehiculo();
            }
            else
            {
                MessageBox.Show("Se cancelo el alta del cliente", "Cancelado");
                result = new DialogResult();
            }
        }

        private void txtAMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.soloLetra(e);
        }

        private void txtAColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.soloLetra(e);
        }

        private void txtATipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.soloLetra(e);
        }

        private void txtAClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.soloLetra(e);
        }
    }
}
