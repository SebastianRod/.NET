using CRUDOperations.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDOperations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly DbOps db = new DbOps();

        public List<Usuario> GetUsers()
        {
            List<Usuario> result = db.GetUsuarios();
            return result;
        }

        public bool CreateUser(Usuario user)
        {
            bool result = db.CreateUser(user);

            return result;
        }

        public bool EditUser(Usuario user)
        {
            bool result = db.EditUser(user);

            return result;
        }

        public bool DeleteUser(int userId)
        {
            bool result = db.DeleteUser(userId);

            return result;
        }
    }
}
