using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDOperations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Usuario> GetUsers();

        [OperationContract]
        bool CreateUser(Usuario user);

        [OperationContract]
        bool EditUser(Usuario user);

        [OperationContract]
        bool DeleteUser(int userId);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class Usuario
    {
        int Id = 0;
        string Nombre = string.Empty;
        DateTime FechaNacimiento = new DateTime();
        string Sexo = string.Empty;

        [DataMember]
        public int Ide
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return Nombre;
            }

            set
            {
                Nombre = value;
            }
        }

        [DataMember]
        public DateTime BirthDate
        {
            get
            {
                return FechaNacimiento;
            }
            set
            {
                FechaNacimiento = value;
            }
        }

        [DataMember]
        public string Sex
        {
            get
            {
                return Sexo;
            }
            set
            {
                Sexo = value;
            }
        }
    }
}
