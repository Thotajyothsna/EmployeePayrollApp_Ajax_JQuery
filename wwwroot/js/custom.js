$(document).ready(function () {
    ShowEmployeeData();
});

function ShowEmployeeData() {
    $.ajax({
        url: 'Employee/EmployeeList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.name + '</td>';
                object += '<td>' + item.state + '</td>';
                object += '<td>' + item.city + '</td>';
                object += '<td>' + item.salary + '</td>';                                                                                                                             
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit('+item.id+');">Edit</a> | <a href="#" class="btn btn-danger" onclick="Delete('+item.id+')">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);

        },
        error: function () {
            alert("Data Can't get");
        }
    });
};

$('#btnAddEmployee').click(function () {
    ClearTextBox();
    $('#EmployeeModel').modal('show');
    $('#EmploId').hide();
    $('#AddEmployee').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#EmpHead').text('Add Employee');
});

function AddEmployee() {
    var objData = {
        Name: $('#Name').val(),
        State: $('#State').val(),
        City: $('#City').val(),
        Salary: $('#Salary').val()
    }
    $.ajax({
        url: '/Employee/AddEmployee',
        type: 'POST',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data Saved');
            ClearTextBox();
            HideModalPopUp();
            ShowEmployeeData();    

        },
        error: function () {
            alert('Data is not Saved');
        }
    });
}

function HideModalPopUp() {
    $('#EmployeeModel').modal('hide');
}

function ClearTextBox() {
    $('#EmpId').val('');
    $('#Name').val('');
    $('#State').val('');
    $('#City').val('');
    $('#Salary').val('');
}

function Delete(id)
{
    if (confirm('Are you sure to Delete It')) {
        $.ajax(
            {
                url: '/Employee/Delete?id=' + id,
                success: function () {
                    alert('Record Deleted');
                    ShowEmployeeData();
                },
                error: function () {
                    alert("Data Can't be Deleted!");
                }
            });
    }
}

function Edit(id) {
    $.ajax({
        url: '/Employee/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#EmployeeModel').modal('show');
            $('#EmpId').val(response.id);
            $('#Name').val(response.name);
            $('#State').val(response.state);
            $('#City').val(response.city);
            $('#Salary').val(response.salary);
            $('#AddEmployee').css('display', 'none');
            $('#btnUpdate').css('display', 'block');
            $('#EmpHead').text('Update Record');
        },
        error: function () {
            alert("Data Not Found");
        }
    })
}

function UpdateEmployee() {
    var objData = {
        Id: $('#EmpId').val(),
        Name: $('#Name').val(),
        State: $('#State').val(),
        City: $('#City').val(),
        Salary:$('#Salary').val()
    }
    $.ajax({
        url: '/Employee/Update',
        type: 'POST',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data Updated');
            ClearTextBox();
            HideModalPopUp();
            ShowEmployeeData();

        },
        error: function () {
            alert('Data is not Updated');
        }
    })
}