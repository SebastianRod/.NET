<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="panel">
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="userInput" class="col-md-6 control-label">Nombre: </label>
                        <div class="col-md-6 controls">
                            <input id="userInput" runat="server" type="text"/>
                        </div>
                    </div>
                    <div class="form-group">
                            <label for="dateInput" class="col-md-6 control-label">Fecha de nacimiento: </label>
                            <div class="col-md-6 controls">
                                <input id="dateInput" runat="server" type="date">
                            </div>
                    </div>
                    <div class="form-group">
                        <label for="sexoInput" class="col-md-6 control-label">Sexo: </label>
                        <div class="col-md-6 controls">
                            <select id="sexoInput">
                                <option value="F">Femenino</option>
                                <option value="M">Masculino</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-6">
                            <button id="crearButton" type="button" onclick="createUser()" class="btn btn-primary">Crear Usuario</button>
                            <a href="Pages/UsuarioConsulta.aspx" class="btn btn-warning">Usuario Consulta</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <script type="text/javascript">
        function createUser() {

            if ($("[id*=userInput]").val() == '' || $("[id*=dateInput]").val() == '') {
                alert("Favor llenar los campos del formulario");
                return;
            }

            var params = '{' +
                'usuario: "' + $("[id*=userInput]").val() + '",' +
                'fecha: "' + $("[id*=dateInput]").val() + '",' +
                'sexo: "' + $("[id*=sexoInput]  option:selected").val() +'"}';
            $.ajax({
                url: "Default.aspx/CrearUsuario",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                type: "POST",
                cache: false,
                async: true,
                success: function (data) {
                    alert('Usuario creado exitosamente');
                },
                error: function () {
                    console.log("No sirvio")
                }
            })
        }
    </script>
</asp:Content>
