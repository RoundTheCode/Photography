define(["jquery"], function($) {
    "use strict";



    function Modal($element) {
        this.$element = $element;
        this.init();
    }

    Modal.prototype = {
        init: function() {
            this.$element.find(".imageLink").on("click", $.proxy(this.showModal, this, 1));
        },
        showModal: function(modalType) {
            var html = document.getElementsByTagName("html")[0];
            var body = document.getElementsByTagName("body")[0];

            var screenWidthWithScrollbar = body.offsetWidth;

            if (html) {
                html.style.setProperty("overflow", "hidden");
            }      
            
            var screenWidthWithoutScrollbar = body.offsetWidth;
            var marginRight = screenWidthWithoutScrollbar - screenWidthWithScrollbar;
    
            if (html && marginRight > 0) {
                html.style.setProperty("margin-right", marginRight + "px");
            }  

            if ($("#ModalHTML").length == 0) {
                $.get({ 
                    url: "/assets/dist/development/template/modal/modal.html"
                }, function(html) {
                    var $body = $("body");

                    var $script = $("<script type=\"text/html\" />");
                    $script.attr("id", "ModalHTML");
                    $script.html(html);
                    $body.append($script);

                    html = html.replace(/{{ClassName}}/g, " Image");
                    $body.append(html);
                });
            }
            
            return false;
        }
    };

    return Modal;
})