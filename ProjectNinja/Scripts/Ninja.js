var NinjaFunctions = (function () {

    function GetAllDetailsByName() {

        var frontArrayParam = new Array();
        frontArrayParam[0] = 'Rico';

        $.ajax({

            type: "POST",
            url: "Ninja.aspx/GetAllDetailsByName",
            data: JSON.stringify({ backArrayParam: frontArrayParam }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function AjaxSucceded(response) {

                var xmlDoc = $.parseXML(response.d);
                var xml = $(xmlDoc);
                var students = xml.find("Table1");

                $.each(students, function () {

                    alert($(this).find("RollNo").text());

                });

            },//function AjaxSucceded(response)

                error: function AjaxError(response) { alert(response.status + ' ' + response.responseText); },
                failure: function AjaxFailure(response) { alert(response.status + ' ' + response.responseText); }

            });//$.ajax

        }//function GetAllDetailsByName()

    function InsertData() {

        var frontArrayParam = new Array();
        

        $.ajax({

            type: "POST",
            url: "Ninja.aspx/InsertData",
            data: JSON.stringify({ backArrayParam: frontArrayParam }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function AjaxSucceded(response) {

                alert(response.d);

            },//function AjaxSucceded(response)

            error: function AjaxError(response) { alert(response.status + ' ' + response.responseText); },
            failure: function AjaxFailure(response) { alert(response.status + ' ' + response.responseText); }

        });//$.ajax

    }

    function InsertData2() {

        var frontArrayParam = new Array();
        frontArrayParam[0] = 'YR08';
        frontArrayParam[1] = 'Rico';
        frontArrayParam[2] = 'EE';
        frontArrayParam[3] = 'D2';

        $.ajax({

            type: "POST",
            url: "Ninja.aspx/InsertData2",
            data: JSON.stringify({ backArrayParam: frontArrayParam }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function AjaxSucceded(response) {

                alert(response.d);

            },//function AjaxSucceded(response)

            error: function AjaxError(response) { alert(response.status + ' ' + response.responseText); },
            failure: function AjaxFailure(response) { alert(response.status + ' ' + response.responseText); }

        });//$.ajax

    }


    return {

        GetAllDetailsByName: function () {

            GetAllDetailsByName();

        },

        InsertData: function () {

            InsertData();

        },

        InsertData2: function () {

            InsertData2();

        }

    }

})();//var NinjaFunction
    

    function ShowName() {
    // alert("start");

    $.ajax({
        type: "POST",
        url: "Ninja.aspx/GetName",
        data: JSON.stringify({ name: 'Ricom' }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }

    });

    }

    function OnSuccess(response) {
        alert(response.d);
    }

    function TestRico() {
        alert("OK");

    }

    function GetAllDetails() {
        var frontArrayParam = new Array();
    frontArrayParam[0] = 'first';
    alert("hello");
    $.ajax({
        type: "POST",
        url: "Ninja.aspx/GetAllDetails",
        data: JSON.stringify({ backArrayParam: frontArrayParam }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function AjaxSucceded(response) {

            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var students = xml.find("Table1");

            $.each(students, function () {

                alert($(this).find("RollNo").text());
            });

        },
        failure: function (response) {
            alert(response.d);
        }

    });

    }

    