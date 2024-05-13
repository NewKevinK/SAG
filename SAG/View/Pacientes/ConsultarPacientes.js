let dataTable;
let dataTableIsInitialized = false;

const dataTableOptions = {
    pageLength: 9,
    destroy: true,
   language: {
       lengthMenu: "Mostrar _MENU_ registros por página",
       zeroRecords: "Ningún Paciente encontrado",
       info: "Mostrando de _START_ a _END_ de un total de _TOTAL_ registros",
       infoEmpty: "Ningún Paciente encontrado",
       infoFiltered: "(filtrados desde _MAX_ registros totales)",
       search: "Buscar:",
       loadingRecords: "Cargando...",
       paginate: {
           first: "Primero",
           last: "Último",
           next: "Siguiente",
           previous: "Anterior"
       }
    }
};
/*
const initDataTable = async () => {
    if (dataTableIsInitialized) {
        dataTable.destroy();
    }

    await listUsers();

    dataTable = $("#datatable_users").DataTable(dataTableOptions);

    dataTableIsInitialized = true;
};

const listUsers = async () => {
    try {
        const response = await fetch("https://jsonplaceholder.typicode.com/users");
        const users = await response.json();

        let content = ``;
        users.forEach((user, index) => {
            content += `
                <tr>
                    <td>${index + 1}</td>
                    <td>${user.name}</td>
                    <td>${user.email}</td>
                    <td>${user.address.city}</td>
                    <td>${user.company.name}</td>
                    <td><i class="fa-solid fa-check" style="color: green;"></i></td>
                    <td>
                        <button class="btn btn-sm btn-primary"><i class="fa-solid fa-pencil"></i></button>
                        <button class="btn btn-sm btn-danger"><i class="fa-solid fa-trash-can"></i></button>
                    </td>
                </tr>`;
        });
        tableBody_users.innerHTML = content;
    } catch (ex) {
        alert(ex);
    }
}
*/



function dtUsers() {
    var table = $('#datatable_users').DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: 'ConsultarPacientes.aspx/ConsultarPacientesSAG',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "IdPaciente" },
            { "data": "FechaRegistro" },
            { "data": "CURP" },
            { "data": "ApellidoPaterno" },
            { "data": "ApellidoMaterno" },
            { "data": "Nombres" },
            { "data": "Diagnostico" },
            { "data": "correo" }
        ]



    });

}
function test() {
    $.ajax({
        method: "POST",
        url: "ConsultarPacientes.aspx/ConsultarPacientesSAG",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (info) {
        console.log(info);
    });
}








window.addEventListener("load", async () => {
    await initDataTable();
});

