
$(document).ready(function() {
  $('#contact_form').bootstrapValidator({
      
      feedbackIcons: {
          valid: 'glyphicon glyphicon-ok',
          invalid: 'glyphicon glyphicon-remove',
          validating: 'glyphicon glyphicon-refresh'
      },
      fields: {
          first_name: {
              validators: {
                      stringLength: {
                      min: 2,
                  },
                      notEmpty: {
                      message: 'Please supply your first name'
                  }
              }
          },
           last_name: {
              validators: {
                   stringLength: {
                      min: 2,
                  },
                  notEmpty: {
                      message: 'Please supply your last name'
                  }
              }
          },
          email: {
              validators: {
                  notEmpty: {
                      message: 'Please supply your email address'
                  },
                  emailAddress: {
                      message: 'Please supply a valid email address'
                  }
              }
          },
          phone: {
              validators: {
                  notEmpty: {
                      message: 'Please supply your phone number'
                  },
                  phone: {
                      country: 'US',
                      message: 'Please supply a vaild phone number with area code'
                  }
              }
          },
          address: {
              validators: {
                   stringLength: {
                      min: 8,
                  },
                  notEmpty: {
                      message: 'Please supply your street address'
                  }
              }
          },
          city: {
              validators: {
                   stringLength: {
                      min: 4,
                  },
                  notEmpty: {
                      message: 'Please supply your city'
                  }
              }
          },
          state: {
              validators: {
                  notEmpty: {
                      message: 'Please select your state'
                  }
              }
          },
          zip: {
              validators: {
                  notEmpty: {
                      message: 'Please supply your zip code'
                  },
                  zipCode: {
                      country: 'US',
                      message: 'Please supply a vaild zip code'
                  }
              }
          },
          comment: {
              validators: {
                    stringLength: {
                      min: 10,
                      max: 200,
                      message:'Please enter at least 10 characters and no more than 200'
                  },
                  notEmpty: {
                      message: 'Please supply a description of your project'
                  }
                  }
              }
          }
      })
      .on('success.form.bv', function(e) {
          $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
              $('#contact_form').data('bootstrapValidator').resetForm();

          
          e.preventDefault();

         
          var $form = $(e.target);

          
          var bv = $form.data('bootstrapValidator');

        
          $.post($form.attr('action'), $form.serialize(), function(result) {
              console.log(result);
          }, 'json');
      });
});
$("#search-icon").click(function () {
    $(".nav").toggleClass("search");
    $(".nav").toggleClass("no-search");
    $(".search-input").toggleClass("search-active");
  });
  
  $('.menu-toggle').click(function () {
    $(".nav").toggleClass("mobile-nav");
    $(this).toggleClass("is-active");
  });
  $('button').click(function () {
    $(this).toggleClass('clicked');
    $('button p').text(function (i, text) {
      return text === "Sent!" ? "Send" : "Sent!";
    });
  });

$(window).on('load', function () { // makes sure the whole site is loaded 
    $('#status').fadeOut(); // will first fade out the loading animation 
    $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website. 
    $('body').delay(350).css({ 'overflow': 'visible' });
})
