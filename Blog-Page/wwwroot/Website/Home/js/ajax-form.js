!function(e){"use strict";var t,a=e(".contact-form form"),s=e(".messenger-box-contact__msg");function n(e){s.fadeIn().removeClass("alert-danger").addClass("alert-success"),s.text(e),setTimeout((function(){s.fadeOut()}),3e3),a.find('input:not([type="submit"]), textarea').val("")}function u(e){s.fadeIn().removeClass("alert-success").addClass("alert-success"),s.text(e.responseText),setTimeout((function(){s.fadeOut()}),3e3)}a.submit((function(s){s.preventDefault();const l=document.getElementById("full-name"),o=document.getElementById("email");if(!l.value||!o.value)return l.classList.add("invalid"),console.log("false"),!1;t=e(this).serialize(),e.ajax({type:"POST",url:a.attr("action"),data:t}).done(n).fail(u)}))}(jQuery);