<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="UserApplication.Pages.UsuarioConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table id="userTable" class="table table-striped table-bordered" style="width:100%">
        <thead>
            <tr>
                <th>Usuario</th>
                <th>Fecha</th>
                <th>Sexo</th>
                <th>Accion</th>
            </tr>
        </thead>
    </table>

    <script>
        $(document).ready(function () {
            TABLA = $('#userTable').DataTable();
            getUsers();
        });

        function getUsers() {
            var params = '{}';
            $.ajax({
                url: "UsuarioConsulta.aspx/GetUsers",
                data: null,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                type: "POST",
                cache: false,
                async: true,
                success: function (data) {
                    var datos = data.d.result;
                    //console.log(data.d.result)
                    if (datos.length > 0) {
                        for (var user of datos) {
                            console.log(user.BirthDate)
                            var fecha = user.BirthDate.substring(user.BirthDate.indexOf("(") + 1, user.BirthDate.indexOf(")"));
                            var fechaRes = new Date(parseInt(fecha)).toISOString().substring(0, 10);
                            TABLA.row.add(
                                [
                                    '<input id="userInput" value="' + user.Name + '" disabled fila="' + user.Ide + '"></input>',
                                    '<input id="dateInput" type="date" disabled value="' + fechaRes + '" fila="' + user.Ide + '"></input>',
                                    '<input id="sexInput" maxlength="1" disabled value="' + user.Sex + '" fila="' + user.Ide + '"></input>',
                                    '<button type="button" onclick="editUser(this, ' + user.Ide + ')">Editar</button> <button type="button" onclick="deleteUser(this,' + user.Ide +')">Eliminar</button>'
                                ]
                            ).draw(false);
                        }
                    }
                },
                error: function () {
                    console.log("No sirvio")
                }
            })
        }

        $('#userTable tbody').on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        })

        function editUser(boton, row) {

            if ($(boton).text() == "Editar") {
                $("input[fila]").attr("disabled", "disabled");
                $("input[fila]").each(function () {
                    if ($(this).attr("currentValue")) {
                        $(this).val($(this).attr("currentValue"));
                        $(this).removeAttr("currentValue");
                    }
                })
                $("[fila='" + row + "']").removeAttr("disabled");
                $("[fila='" + row + "']").each(function () {
                    $(this).attr("currentValue", $(this).val());
                });
                $("button:contains(Guardar)").text("Editar");
                $(boton).text("Guardar");
            } else {
                var params = '{' +
                    'id: "' + row + '",' +
                    'usuario: "' + $("[id*=userInput]:enabled").val() + '",' +
                    'fecha: "' + $("[id*=dateInput]:enabled").val() + '",' +
                    'sexo: "' + $("[id*=sexInput]:enabled").val() + '"}';

                $.ajax({
                    url: "UsuarioConsulta.aspx/SaveUser",
                    data: params,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    type: "POST",
                    cache: false,
                    async: true,
                    success: function () {
                        $("input[fila]").attr("disabled", "disabled");
                        $("input[fila]").each(function () {
                            if ($(this).attr("currentValue")) {
                                $(this).removeAttr("currentValue");
                            }
                        })
                        alert("Modificacion realizada exitosamente");
                    },
                    error: function () {
                        alert("Error al guardar el usuario, intente nuevamente")
                    }
                })
                $(boton).text("Editar");
            }
        }

        function deleteUser(boton, row) {
            var params = '{' +
                'id: "' + row + '"}';

            $.ajax({
                url: "UsuarioConsulta.aspx/DeleteUser",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                type: "POST",
                cache: false,
                async: true,
                success: function () {
                    alert("Usuario eliminado correctamente");
                    refreshTable();
                },
                error: function () {
                    alert("Error al eliminar el usuario");
                }
            })
        }

        function refreshTable() {
            TABLA.clear().draw();
            getUsers();
        }
    </script>

</asp:Content>
