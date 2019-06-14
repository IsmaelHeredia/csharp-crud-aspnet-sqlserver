﻿// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Sistema.Forms.Login
{

    public partial class LogOut : System.Web.UI.Page
    {

        Funciones funcion = new Funciones();

        string session_name = ConfigurationManager.AppSettings["session_name"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[session_name] != null)
                {
                    string contenido = Session[session_name].ToString();
                    if (funcion.valid_cookie(contenido))
                    {
                        Session[session_name] = null;
                        string texto = "La sesión ha sido cerrada";
                        lblMensaje.Text = funcion.mensaje_con_redireccion(texto, "/Forms/Login/Index.aspx");
                    }
                }
            }
        }
    }
}