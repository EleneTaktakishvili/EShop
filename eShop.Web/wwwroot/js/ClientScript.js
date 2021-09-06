
function AddToCart(ProductId) {

    let Quantity = document.getElementById('inputQuantity').value;

    try {
        $.ajax({
            type: 'GET',
            url: '/Order/AddToCart',
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            data: { ProductId: ProductId, ProductQuantity: Quantity },
            success: function (response) { 
                $.notify(response.data, "info");  
                //alert(response.data);
            },
            error: function (err) {
                $.notify(err, "error");
            }
        })
        return false;
    }
    catch (ex) {
        console.log(ex)
    }

}

function ApplyOrder() {

    const rbs = document.querySelectorAll('input[name="AddressId"]');
    let selectedvalue;
    let selected = false;
    for (const rb of rbs) {
        if (rb.checked) {
            selectedvalue = rb.value;
            selected = true;
            break;
        }
    }

    if (!selected) {
        $.notify("მონიშნეთ მისამართი", "error");
    }   

    else {
        let OrderId = document.getElementById('OrderId').value;
        let AddressId = selectedvalue;
        try {
            $.ajax({
                type: 'POST',
                url: '/Order/ApplyOrder',               
                data: { OrderId: OrderId, AddressId: AddressId },
                success: function (response) {
                    $.notify(response.data, "info");
                },
                error: function (err) {
                    $.notify(err, "error");
                }
            })
            return false;
        }
        catch (ex) {
            console.log(ex)
        }
    }
}


function OrderHistory(orderId) {
    try {
        $.ajax({
            type: 'GET',
            url: '/Order/OrderDetails',
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            data: { orderId: orderId },
            success: function (response) {
                var detailsTable = $('#orderDetailsModal .modal-body tbody');
                detailsTable.empty();  

                $(response).each(function (index, det) {
                    detailsTable.append('<tr><td>' + index + '</td><td>'  + det.productName + '</td><td>'
                        + det.quantity + '</td><td>' + det.price + '</td></tr>');
                });

                $('#orderDetailsModal .modal-title').html('დეტალები');
                $('#orderDetailsModal').modal('show');
            },
            error: function (err) {
                $.notify(err, "error");
            }
        })
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

function AddNewAddress() {

    $('#addressModal input').val('');
    $('#addressModal .modal-title').html('მისამართის დამატება');
    $('#addressModal').modal('show');
}
