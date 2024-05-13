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

const initDataTable = async () => {
    if (dataTableIsInitialized) {
        dataTable.destroy();
    }
    alert("hola2");
    await listUsers();

    dataTable = $("#datatable_users").DataTable(dataTableOptions);

    dataTableIsInitialized = true;
};

const listUsers = async () => {
    try {
        const response = await fetch("ConsultarPacientes.aspx/ConsultarPacientesSAG", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({})
        });
        const { d: users } = await response.json();

        let content = ``;
        users.forEach((user, index) => {
            content += `
                <tr>
                    <td>${user.IdPaciente}</td>
                    <td>${new Date(parseInt(user.FechaRegistro.substr(6)))}</td>
                    <td>${user.CURP}</td>
                    <td>${user.ApellidoPaterno}</td>
                    <td>${user.ApellidoMaterno}</td>
                    <td>${user.Nombres}</td>
                    <td>${user.Diagnostico}</td>
                    <td>
                        <button class="btn btn-sm btn-primary"><i class="fa-solid fa-pencil"></i></button>
                        <button class="btn btn-sm btn-danger"><i class="fa-solid fa-trash-can"></i></button>
                    </td>
                </tr>`;
        });
        alert("hola");
        $("#tableBody_users").html(content);
    } catch (ex) {
        alert(ex);
    }
}
