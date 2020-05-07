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
using System.Data.SqlClient;

namespace Vistas
{



    public partial class FrmLogin : Form
    {

        private String cargarCapcha;
        FrmMain formMain = new FrmMain();
        FrmSistema frmSistema = new FrmSistema();
       public Usuario user = new Usuario();

        public FrmLogin()
        {
            InitializeComponent();

            cargarCapcha = generarCapcha();

            lblCapcha.Text = cargarCapcha;
        }
      
        public String generarCapcha()
        {

            Random rdm = new Random();
            int opcion = rdm.Next(0, 5);
            String resultado = null;
            String[] capcha;
            capcha = new string[5];

            capcha[0] = "AuTmcK";
            capcha[1] = "bdpXAa";
            capcha[2] = "aniycp";
            capcha[3] = "MkpatW";
            capcha[4] = "ertyui";

            resultado = capcha[opcion];

            return resultado;
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            
            dataTable = ConectionLog.ingresar(txtUsuario.Text, txtContra.Text);
           
            if (dataTable.Rows.Count!=0)
                {
                    this.Hide();
                    formMain.Show();
                    guardarUser(dataTable);
                    formMain.lblNom.Text = "BIENVENIDO:"+dataTable.Rows[0][1].ToString();
                    restringirAcceso(dataTable);
                    
            }
                
              else
            {
                MessageBox.Show("Datos incorrectos");
            }

           

        }
        public void restringirAcceso(DataTable dt)
        {
            if (dt.Rows[0][1].ToString() == "admin")
            {
                formMain.btnCliente.Visible = false;
            }
            else if (dt.Rows[0][1].ToString() == "vendedor")
            {
                formMain.btnVehiculos.Visible = false;

            }
        }
        public void guardarUser(DataTable dt)
        {
          
            user.Usu_NombreUsuario = dt.Rows[0]["USU_NombreUsuario"].ToString();
            user.Usu_Contraseña = dt.Rows[0]["USU_Password"].ToString();
            user.Usu_ApellidoNombre = dt.Rows[0]["USU_ApellidoNombre"].ToString();
            user.Rol_Codigo = dt.Rows[0]["ROL_Codigo"].ToString();
            user.Usu_ID = Convert.ToInt32(dt.Rows[0]["USU_ID"].ToString());
        }

        private void txtUsuario_MouseHover(object sender, EventArgs e)
        {
            lblnfoUsu.Text = "Ingresar Usuario";
        }

        private void txtUsuario_MouseLeave(object sender, EventArgs e)
        {
            lblnfoUsu.Text = " ";
        }

        private void txtContra_MouseHover(object sender, EventArgs e)
        {
            lblInfoContra.Text = "Ingrese Contraseña";
        }

        private void txtContra_MouseLeave(object sender, EventArgs e)
        {
            lblInfoContra.Text = " ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCapcha_Click(object sender, EventArgs e)
        {

        }
    }
}
