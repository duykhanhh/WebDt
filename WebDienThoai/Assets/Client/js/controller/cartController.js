﻿var cart = {
    init: function () {
        cart.registerEvent();
    },
    registerEvent: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listsp = $('.txtquantity');
            var cartList = [];
            $.each(listsp, function (i, item) {
                cartList.push({
                    quantity: $(item).val(),
                    SanPham: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                    
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            

            $.ajax({
                url: '/Cart/DeleteAll',               
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }

                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();

            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }

                }
            })
        });
    }
}
cart.init();