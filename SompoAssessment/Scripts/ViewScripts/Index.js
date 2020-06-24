var vm = {
    InsertToTable: function (tableID, cellList) {
        var row = "<tr>";

        $.each(cellList, function (index, value) {
            row = row + "<td>" + value + "</td>";
        });

        row = row + "</tr>";

        if ($("#" + tableID).has("tr")) {
            $("#" + tableID + " tr:last").after(row);
        } else {
            $("#" + tableID + " > tbody").html(row);
        }
    },
    
    GetPolicyStatus: function () {

        if ($("#txtProductNo").val() == "") {
            alert("Ürün Numarası Girilmedi");
            return;
        }

        if ($("#txtRenewalNo").val() == "") {
            alert("Yenileme Numarası Girilmedi");
            return;
        }

        if ($("#txtProposalNo").val() == "") {
            alert("Teklif Numarası Girilmedi");
            return;
        }

        if ($("#txtEndorsNo").val() == "") {
            alert("Zeyil Numarası Girilmedi");
            return;
        }

        var _request = {
            Object: {
                ProposalNo: $("#txtProposalNo").val(),
                RenewalNo: $("#txtRenewalNo").val(),
                EndorsNo: $("#txtEndorsNo").val(),
                ProductNo: $("#txtProductNo").val(),
            }
        }

        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: '/Home/GetPolicyStatus',
            type: 'POST',
            data: {
                __RequestVerificationToken: token, 
                request: _request
            },
            dataType: "json",
            success: function (response) {
                if (response.IsSucccess == true) {
                    $.each(response.data.Results, function (index, value) {
                        if (value.Status.Value == 1) {
                            var cellList = [$('#tblPositives tr').length + 1, value.Description]
                            vm.InsertToTable("tblPositives", cellList)
                        }
                        if (value.Status.Value == 2) {
                            var cellList = [$('#tblInformation tr').length + 1, value.Description]
                            vm.InsertToTable("tblInformation", cellList)
                        }
                        if (value.Status.Value == 3) {
                            var cellList = [$('#tblNegatives tr').length + 1, value.Description]
                            vm.InsertToTable("tblNegatives", cellList)
                        }
                    });
                } else {
                    alert("İstek başarısız oldu");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.responseText);
            }
        });
        
    }
}

$(document).ready(function () {

});

$(document).on("click", "#btnSearch", function () {
    vm.GetPolicyStatus();
});