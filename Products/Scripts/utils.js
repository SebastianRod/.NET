function ClearLoginInputs() {
    $("#inputUsuario").val("")
}

function ShowCreateUserModal() {
    $.ajax({
        url: "/User/ShowCreateUser",
        dataType: "html",
        data: null,
        success: function (data) {
            $('#FormModal').modal({ backdrop: 'static', keyboard: false });
            $('#modalContent').html(data);
        },
        error: function () {
            console.log("no");
        }
    })
}

function ShowEditUserModal(userName) {
    var data = {
        userName: userName
    };

    $.ajax({
        url: "/User/ShowEditUser",
        dataType: 'html',
        data: data,
        success: function (data) {
            $('#FormModal').modal({ backdrop: 'static', keyboard: false });
            $('#modalContent').html(data);
        },
        error: function (data) {
            console.log(data);
        }
    })
}

function CreateUser() {
    if (ValidateUserForm()) {

        var data = {
            userName: $('#NOMBRE_USUARIO').val(),
            userPwd: $('#PWD_USUARIO').val(),
            userAge: $('#EDAD_USUARIO').val(),
            userGender: $('#GENERO_USUARIO').val(),
            userNationality: $('#NACIONALIDAD_USUARIO').val(),
            userRol: $('#ROL_ID_ROL').val() 
        }

        $.ajax({
            url: "/User/CreateUser",
            dataType: 'json',
            data: data,
            type: 'POST',
            success: function (data) {
                if (data.response == "OK") {
                    $('#FormModal').modal('hide')
                    alert(data.description)
                    location.reload();
                } else {
                    alert(data.description)
                }
            },
            error: function (data) {
                alert(data.description)
            }
        })
    } else {
        alert("Please fill the inputs.")
    }
}

function DeleteUser(userName) {
    var data = {
        userName : userName
    };

    $.ajax({
        url: "/User/DeleteUser",
        dataType: 'json',
        data: data,
        type: 'POST',
        success: function (data) {
            if (data.response == "OK") {
                alert(data.description)
                location.reload();
            } else {
                alert(data.description)
            }
        }
    })
}

function EditUser() {
    if (ValidateUserForm) {
        var data = {
            userName: $('#NOMBRE_USUARIO').val(),
            userPwd: $('#PWD_USUARIO').val(),
            userAge: $('#EDAD_USUARIO').val(),
            userGender: $('#GENERO_USUARIO').val(),
            userNationality: $('#NACIONALIDAD_USUARIO').val(),
            userRol: $('#ROL_ID_ROL').val()
        }

        $.ajax({
            url: "/User/EditUser",
            dataType: 'json',
            data: data,
            type: 'POST',
            success: function (data) {
                if (data.response == "OK") {
                    $('#FormModal').modal('hide')
                    alert(data.description)
                    location.reload();
                } else {
                    alert(data.description)
                }
            },
            error: function (data) {
                alert(data.description)
            }
        })
    }
}

function ValidateUserForm() {
    var valid = true;

    var inputUsuario = $('#NOMBRE_USUARIO').val();
    var inputPwd = $('#PWD_USUARIO').val();
    var inputAge = $('#EDAD_USUARIO').val();
    var inputGender = $('#GENERO_USUARIO').val();
    var inputNationality = $('#NACIONALIDAD_USUARIO').val();
    var inputRol = $('#ROL_ID_ROL').val();

    if (inputUsuario == "" || inputPwd == "" || inputAge == "" || inputGender == "" || inputNationality == "" || inputRol == "") {
        valid = false;
    }

    return valid;
}

function AddReservationProduct(productName) {
    
}