using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace Sistema_Supervisório
{
    public partial class Login : System.Web.UI.Page
    {
        OpcClient client;   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack){
                if (Request.Form["btnEntrar"] != null)
                {
                    if ((Request.Form["inputUsuario"] == "felipe") && Request.Form["inputSenha"] == "felipe")
                    {
                        Response.Redirect("Dashboard.aspx");

                    }
                    
                }
            }
        }
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Teste.aspx");
        }
        
    }
}