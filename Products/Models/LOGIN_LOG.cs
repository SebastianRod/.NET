//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Products.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOGIN_LOG
    {
        public int ID_LOGIN_LOG { get; set; }
        public System.DateTime FECHA_LOGIN { get; set; }
        public int USUARIO_ID_USUARIO { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
