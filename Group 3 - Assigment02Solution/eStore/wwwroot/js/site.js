// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('click', '.ajax-button', function (event) {
    event.preventDefault(); // Ngăn chặn hành vi mặc định của liên kết

    var url = $(this).data('url');
    var id = $(this).data('id');

    $.ajax({
        url: url + id,
        type: 'POST',
        success: function (data) {
            // Xử lý dữ liệu tải về từ máy chủ ở đây

            // Ẩn spinner container sau khi hoàn thành
            $('#spinner-container').hide();
        },
        error: function () {
            // Xử lý lỗi tại đây (nếu có)

            // Ẩn spinner container sau khi hoàn thành
            $('#spinner-container').hide();
        }
    });
});
$(document).ready(function () {
    var token = getCookie("token");
    var role = "";
    if (token != null) {
        $.ajaxSetup({
            headers: {
                "Authorization": "Bearer " + token // Gán token vào tiêu đề yêu cầu
            }
        });
        var decodedToken2 = decodeToken(token);
        role = decodedToken2["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        document.getElementById("button_add").style.display = "block";
    }
});
function addToCard(idProduct) {
    var cookieValue = $.cookie("cart");
    var cartItems = cookieValue ? JSON.parse(cookieValue) : [];
    console.log($.cookie("cart"));
    $.ajax({
        url: 'https://localhost:44342/api/Product/detailProduct', // Đường dẫn đến action trong controller để lấy dữ liệu sản phẩm
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { id: idProduct },
        success: function (data) {
            // Xử lý dữ liệu tải về từ máy chủ ở đây
            var newProduct = {
                productId: data.productId,
                productName: data.productName,
                price: data.unitPrice,
                quantity: 1
            };

            // Add the new product to the cart items array
            var existingProduct = cartItems.find(function (item) {
                return item.productId === newProduct.productId;
            });

            if (existingProduct) {
                // If the product exists, increase the quantity
                existingProduct.quantity += newProduct.quantity;
            } else {
                // If the product doesn't exist, add it to the cart items array
                cartItems.push(newProduct);
            }

            // Serialize the updated cart items array into a string
            var serializedCartItems = JSON.stringify(cartItems);

            // Update the cart cookie with the updated cart items
            $.cookie("cart", serializedCartItems);
            console.log($.cookie("cart"));
            // Ẩn spinner container sau khi hoàn thành
            $('#spinner-container').hide();
        },
        error: function () {
            // Xử lý lỗi tại đây (nếu có)

            // Ẩn spinner container sau khi hoàn thành
            $('#spinner-container').hide();
        }
    });
}
function sendAjaxRequest(method, url, data) {
    $.ajax({
        url: url,
        type: method,
        withCredentials: false,
        crossDomain: true,
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (result) {
            // Xử lý kết quả nếu cần thiết
            document.getElementById("popup-form").reset();
            $('#spinner').hide();
            $('#exampleModal').modal('hide');
        },
        error: function (error) {
            // Xử lý lỗi nếu có
            console.error(error);
        }
    });
}
function appendDataToSelectCheckbox(data) {
    var selectElement = document.getElementById('inputCategory');

    // Iterate over the data and create option elements
    data.result.forEach(function (item) {
        var option = document.createElement('option');
        option.value = item.categoryId;
        option.textContent = item.categoryName;

        selectElement.appendChild(option);
    });
}
function clearModalContent() {
    $(".productContainer").empty();
}
function calculateTotalPrice(totalPrice) {
    var $totalPriceElement = $("#totalPrice");
    $totalPriceElement.text(totalPrice.toFixed(2));
}
function updateTotalPrice(totalPrice) {
    var $totalPriceElement = $("#totalPrice");
    console.log(totalPrice);
    $totalPriceElement.text(totalPrice.toFixed(2));
}
function showCard() {
    document.getElementById('id02').style.display = 'block';
    clearModalContent();
    var cookieValue = $.cookie("cart");
    // Deserialize the products from the cookie
    var deserializedProducts = JSON.parse(cookieValue);

    // Create the table element
    var $table = $("<table>").addClass("table table-striped table-bordered");
    var $thead = $("<thead>").appendTo($table);
    var $tbody = $("<tbody>").appendTo($table);

    // Create the table header row
    $thead.append($("<tr>").append(
        $("<th>").text("Name"),
        $("<th>").text("Product Price"),
        $("<th>").text("Quantity"),
        $("<th>").text("Subtotal"),
        $("<th>").text("Actions"),
    ));
    var totalPrice = 0;
    if (deserializedProducts.length > 0) {
        // Iterate over the products and create rows for each product
        deserializedProducts.forEach(function (product) {
            var quantity = product.quantity || 1; // Default quantity is 1 if not specified
            var subtotal = product.price * quantity;
            totalPrice += subtotal;
            var $row = $("<tr>").appendTo($tbody);
            $row.append(
                $("<td>").text(product.productName),
                $("<td>").text(product.price),
                $("<td>").text(product.quantity),
                $("<td>").text(subtotal),
                $("<td>").append(
                    $("<button>").addClass("btn btn-danger btn-sm delete-btn").text("Delete").data("productId", product.productId)
                )
            );
        });
        var $totalRow = $("<tr>").appendTo($tbody);
        $totalRow.append(
            $("<td>").attr("colspan", 3).text("Total Price"),
            $("<td>").attr("id", "totalPrice").text(totalPrice.toFixed(2)),
            $("<td>")
        );

        // Append the table to the container element in the HTML
        $(".productContainer").append($table);
        var $checkoutButton = $("<button>").addClass("btn btn-primary").text("Checkout");
        $(".productContainer").append($checkoutButton);

        $(".delete-btn").click(function () {
            // Get the parent row of the clicked delete button
            var $row = $(this).closest("tr");

            // Get the productId associated with the clicked button
            var productId = $(this).data("productId");

            // Find the index of the product in the array
            var productIndex = deserializedProducts.findIndex(function (product) {
                return product.productId === productId;
            });

            // Check if the product was found
            if (productIndex !== -1) {
                // Remove the product from the array
                var deletedProduct = deserializedProducts.splice(productIndex, 1)[0];

                // Update the total price
                var quantity = deletedProduct.quantity || 1; // Default quantity is 1 if not specified
                var subtotalde = deletedProduct.price * quantity;
                totalPrice -= subtotalde;

                // Remove the row from the table
                $row.remove();

                // Update the cookie to remove the deleted product
                var serializedProducts = JSON.stringify(deserializedProducts);
                $.cookie("cart", serializedProducts);

                // Update the total price in the HTML
                updateTotalPrice(totalPrice);
            }
        });
        $checkoutButton.click(function () {
            $('#spinner').hide();
            var token = $.cookie("token");
            if (token) {

            }
        });
        calculateTotalPrice(totalPrice);
    }
    else {
        $(".productContainer").append($table);
        var $emptyCartMessage = $("<div>").addClass("text-center").text("Cart is empty");
        $(".productContainer").append($emptyCartMessage);

        var $checkoutButton = $("<button>").addClass("btn btn-primary").text("Checkout");
        $(".productContainer").append($checkoutButton);
        calculateTotalPrice(totalPrice);
    }
}
function addProduct(event) {
    event.preventDefault(); // Chặn hành vi mặc định của form

    // Gọi AJAX tại đây và xử lý kết quả
    $('#spinner').show();
    // Ví dụ:

    var data = {
        productName: document.getElementById('productName').value,
        categoryId: document.getElementById('inputCategory').value,
        unitPrice: document.getElementById('inputPrice').value,
        unitStock: document.getElementById('inputStock').value
    };
    // Gửi AJAX request
    sendAjaxRequest('POST', 'https://localhost:44342/api/Product/addProduct', data);

    getProducts();
    $('#spinner').hide();
}

function login(event) {

    event.preventDefault();
    var data = {
        userName: document.getElementById('uname').value,
        password: document.getElementById('psw').value
    };
    $('#spinner').show();
    $.ajax({
        url: "https://localhost:44342/api/User/login",
        type: "POST",
        withCredentials: false,
        crossDomain: true,
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (result) {
            // Xử lý kết quả nếu cần thiết
            $('#spinner').hide();
            document.getElementById('id01').style.display = 'none';
            document.getElementById("popup-form-login").reset();
            var expireDate = new Date();
            expireDate.setDate(result.expiration);
            document.cookie = "token=" + result.token + "; expires=" + expireDate.toUTCString() + "; path=/;";
            var token = getCookie("token");
            window.location.href = "/";
        },
        error: function (error) {
            // Xử lý lỗi nếu có
            document.getElementById("popup-form-login").reset();
            $('#spinner').hide();
            console.error(error);
        }
    });
}
function logout() {
    document.cookie = "token=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    window.location.href = "/"; // Redirect to the login page
}
function getProducts() {
    $('#spinner').show();
    var searchValue = $('#input_search').val();
    if (!searchValue) {
        searchValue = "";
    }
    var dataSearch =
    {
        name: searchValue
    }
    var token = getCookie("token");
    var role = "";
    if (token) {
        var decodedToken2 = decodeToken(token);
        role = decodedToken2["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    }
    $.ajax({
        url: 'https://localhost:44342/api/Product', // Đường dẫn đến action trong controller để lấy dữ liệu sản phẩm
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(dataSearch),
        success: function (data) {
            var tableBody = $('#productTable tbody'); // Lấy thẻ tbody của bảng
            tableBody.empty(); // Xóa dữ liệu cũ trong tbody
            // Lặp qua dữ liệu sản phẩm và thêm vào bảng
            for (var i = 0; i < data.result.length; i++) {
                var product = data.result[i];
                var row = '<tr>' +
                    '<td>' + product.productName + '</td>' +
                    '<td>' + product.categoryName + '</td>' +
                    '<td>' + product.unitPrice + '</td>' +
                    '<td>' + product.unitStock + '</td>' +
                    '<td class="actions">';
                if (role === "Admin") {
                    row +=
                        '<a id="AddtoCard" style="display: block;" title="AddToCard" data-toggle="tooltip" onclick="addToCard(' + product.productId + ')"><ion-icon name="bag-add-outline"></ion-icon></a>' +
                        '<a id="edit" style="display: block;" title="Edit" data-toggle="tooltip" class="ajax-button" data-url=""><ion-icon name="create-outline"></ion-icon></a>' +
                        '<a id="delete" style="display: block;" title="Delete" data-toggle="tooltip" class="ajax-button" data-url="/Product/delete/" data-id=' + product.productId + '><ion-icon name="trash-outline"></ion-icon></a>';
                } else {
                    row += '<a id="AddtoCard" style="display: block;" title="AddToCard" data-toggle="tooltip" onclick="addToCard(`' + product.productId + '`)"><ion-icon name="bag-add-outline"></ion-icon></a>';
                }
                row += '</td>' +
                    '</tr>';
                tableBody.append(row);
            }
            $('#spinner').hide();
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function getCategory() {
    $.ajax({
        url: 'https://localhost:44342/api/Category/categoryList', // Đường dẫn đến action trong controller để lấy dữ liệu sản phẩm
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            // Handle the response and append the data to the select checkbox
            appendDataToSelectCheckbox(response);
        },
        error: function (error) {
            console.log('Error:', error);
        }
    });
}
function getCookie(name) {
    var cookieArr = document.cookie.split(";");

    for (var i = 0; i < cookieArr.length; i++) {
        var cookiePair = cookieArr[i].split("=");

        if (name === cookiePair[0].trim()) {
            return decodeURIComponent(cookiePair[1]);
        }
    }

    return null;
}
function decodeToken(token) {
    var parts = token.split('.');
    var encodedPayload = parts[1];
    var payload = decodeURIComponent(atob(encodedPayload).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(payload);
}
