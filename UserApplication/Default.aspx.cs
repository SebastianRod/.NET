using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static object CrearUsuario(string usuario, string fecha, string sexo)
        {
            CrudOperations.Service1Client service = new CrudOperations.Service1Client();

            //CrudOperations.Usuario user = new CrudOperations.Usuario();
            
            bool result = service.CreateUser(new CrudOperations.Usuario
            {
                Name = usuario,
                Sex = sexo,
                BirthDate = Convert.ToDateTime(fecha)
            });


            return new { respons = result ? "OK" : "Error" };
        }
    }
}