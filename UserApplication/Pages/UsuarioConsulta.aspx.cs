using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserApplication.Pages
{
    public partial class UsuarioConsulta : System.Web.UI.Page
    {
        private static CrudOperations.Service1Client service = new CrudOperations.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod()]
        public static object GetUsers()
        {
            var result = service.GetUsers();

            return new { result = result != null ? result : null };
        }

        [WebMethod()]
        public static object SaveUser(string id, string usuario, string fecha, string sexo)
        {
            CrudOperations.Usuario user = new CrudOperations.Usuario
            {
                Ide = Convert.ToInt32(id),
                Name = usuario,
                BirthDate = Convert.ToDateTime(fecha),
                Sex = sexo
            };
            var result = service.EditUser(user);

            return new
            {
                result = "OK"
            };
        }

        [WebMethod()]
        public static object DeleteUser(string id)
        {
            var result = service.DeleteUser(Convert.ToInt32(id));

            return new
            {
                result = "OK"
            };
        }
    }
}