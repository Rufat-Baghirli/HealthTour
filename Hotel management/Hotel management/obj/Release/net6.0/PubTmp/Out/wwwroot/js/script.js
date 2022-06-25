
var ScriptButton = document.querySelector(".fa-angle-down")
var OpenHeadItem = document.querySelector(" ._hotelAccardion_item")
if (ScriptButton != null) {
  ScriptButton.addEventListener("click", (e) => {
    if (OpenHeadItem.style.display === "none") {
      OpenHeadItem.style.display = "block"
      ScriptButton.style.transform = "rotate(180deg)";
    }
    else {
      OpenHeadItem.style.display = "none"
      ScriptButton.style.transform = "rotate(0deg)";

    }


  })
}

$(window).on('load', function () { // makes sure the whole site is loaded 
  $('#status').fadeOut(); // will first fade out the loading animation 
  $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website. 
  $('body').delay(350).css({ 'overflow': 'visible' });
})

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

const NavbarItems = document.querySelector(".navbar_items")
const NavbarMenuItem = document.querySelector(".Nav_menu_items")


if (NavbarItems != null) {
  NavbarItems.addEventListener("click", function () {

    if (NavbarMenuItem != null) {
      if (NavbarMenuItem.style.opacity == 0) {
        NavbarMenuItem.style.opacity = 1
      }
      else {
        NavbarMenuItem.style.opacity = 0
      }
    }
  })
}
const ButtonUser = document.getElementById("MisafirButton");
const ButenUserItem = document.querySelector(".ButenUserItem")
if (ButenUserItem != null) {
  ButtonUser.addEventListener("click", (e) => {
    e.preventDefault();
    // ButenUserItem.style.opacity="1"
    if (ButenUserItem.style.opacity === "0") {
      ButenUserItem.style.opacity = "1";

    } else {
      ButenUserItem.style.opacity = "0";
    }
  })
}

AOS.init({
  offset: 120,
  delay: 120,
  easing: 'ease',
  duration: 1200,
  disable: false,
  once: false,
  mirror: false,
  anchorPlacement: 'top-bottom',
  startEvent: 'DOMContentLoaded',
  animatedClassName: 'aos-animate',
  initClassName: 'aos-init',
  useClassNames: false,
  disableMutationObserver: false,
  throttleDelay: 99,
  debounceDelay: 50
});

// function AddRomms() {
//  const AddromsData = document.querySelector(".addroomsTable")
//  const RoomData = document.querySelector(".addRoomModal_item")

//  let count = 0

// if(RoomData!=null){
//  RoomData.addEventListener("click", function (e) {
//    e.preventDefault()
//    count++

//    const RommInnerHTML = `
    
   
//    <span>Room ${count}</span>
  
//    <div class="Room_itemModal">
//      <div class="_ModalItemHead">
//        <p>Adults</p>
//        <span class="roomMinus">-</span>
//  <input class="text-center" type="number" value="1" min="1" max="4" class="roomSay"  name="Adult" />

//        <span class="roomPlus">+</span>
  
//      </div>
//      <div class="_roomServiceModal">
//        <ul class="listbody">
        
//        <li>
//        <div class="countTypes">
      
//        </div>
   
//          <select name="RoomTypes" id="RoomTypes">
  
//            <option value="full board and treatment">full board and treatment
//            </option>
//            <option value="full board without treatment">full board without
//              treatment</option>

//          </select>
//        </li>
        
//        </ul>
//      </div>
//    </div>
  
//    <div class="Modal_item_child">
//      <div class="_ModalItemHeadChild">
//        <p>Children</p>
//        <span class="roomMinusChild">-</span>
//        <span class="roomSayChild">0</span>
//        <span class="roomPlusChild">+</span>
  
  
       
//      </div>
//    </div>
//    <div class="_roomServiceModal">
//      <ul class="listbodyChild">
//      <li>
//      <div class="countTypes">
      
//       </div>
 
//     <select name="RoomTypes" id="RoomTypes">
 
//       <option value="full board and treatment">full board and treatment
//       </option>
//       <option value="full board without treatment">full board without
//         treatment</option>
//       <option vallue="half board and treatment">half board and treatment
//       </option>
//       <option value="half board without treatment">half board without
//         treatment</option>
//     </select>
 
 
//     <select  name="AgeChild" id=" ageChild">
 
//       <option selected="selected" value="Age">Age</option>
//       <option value="1">1</option>
//       <option value="2">2</option>
//       <option value="3">3</option>
//       <option value="4">4</option>
//       <option value="5">5</option>
//       <option value="6">6</option>
//       <option value="7">7</option>
//       <option value="8">8</option>
//       <option value="9">9</option>
//       <option value="10">10</option>
//       <option value="11">11</option>
//       <option value="12">12</option>
//       <option value="13">13</option>
//       <option value="14">14</option>
//       <option value="15">15</option>
//       <option value="16">16</option>
//       <option value="17">17</option>
//       <option value="18">18</option>
//     </select>
//   </li> 
      
//      </ul>
//    </div>
    
//    `

//    AddromsData.innerHTML += RommInnerHTML
//  })
// }
//  function addAdult() {

//    var RoomMinus = document.querySelector(".roomMinus")
//    var RoomMSayi = document.querySelector(".roomSay")
//    var RoomPlus = document.querySelector(".roomPlus")
//    let count = 1

//    const list = document.querySelector(".listbody")
//    const countTypes = document.querySelector(".countTypes")

//    const RoomAdultData = document.querySelector("._roomServiceModal")


//    if (RoomPlus != null) {
//      RoomPlus.addEventListener("click", (e) => {
//        e.preventDefault()
//        count++;
//        RoomMSayi.value = count.valueOf()

//        const newInnerHtml = `
    
       
//          <li>
//          <div class="countTypes">
//          ${count}
//          </div>
     
//            <select name="RoomTypes" id="RoomTypes">
    
//              <option value="full board and treatment">full board and treatment
//              </option>
//              <option value="full board without treatment">full board without
//                treatment</option>
             
//            </select>
//          </li>
        
    
//          `
//        list.innerHTML += newInnerHtml



//      })
//    }
//    if (RoomMinus != null) {
//      RoomMinus.addEventListener("click", () => {
//        if (count > 1) {
//          count--;
//          const { children } = list;

//          if (children.length) {
//            console.log(children.length);
//            list.removeChild(children[children.length - 1]);
//          }


//          if (RoomMSayi.value == 1) {
//            RoomMSayi.value = 1
//          }
//          else {
//            RoomMSayi.value = count.valueOf()
//          }

//        }
//      })
//    }
//  }
//  addAdult();


//  function AddChild() {
//    var childPlus = document.querySelector(".roomPlusChild")
//    var childMinus = document.querySelector(".roomMinusChild")
//    var childSay = document.querySelector(".roomSayChild")
//    var Child = document.querySelector(".listbodyChild")
//    let count = 0



//    if (childPlus != null) {

//      childPlus.addEventListener('click', (e) => {
//        e.preventDefault()
//        count++;
//          childSay.value = count.valueOf()
//        const ChildInnerHtml = `
//         <li>
//         <div class="countTypes">
//          ${count}
//          </div>
    
//        <select name="RoomTypes" id="RoomTypes">
    
//          <option value="full board and treatment">full board and treatment
//          </option>
//          <option value="full board without treatment">full board without
//            treatment</option>
//        </select>
    
    
//        <select  name="AgeChild" id=" ageChild">
    
//          <option selected="selected" value="Age">Age</option>
//          <option value="1">1</option>
//          <option value="2">2</option>
//          <option value="3">3</option>
//          <option value="4">4</option>
//          <option value="5">5</option>
//          <option value="6">6</option>
//          <option value="7">7</option>
//          <option value="8">8</option>
//          <option value="9">9</option>
//          <option value="10">10</option>
//          <option value="11">11</option>
//          <option value="12">12</option>
//          <option value="13">13</option>
//          <option value="14">14</option>
//          <option value="15">15</option>
//          <option value="16">16</option>
//          <option value="17">17</option>
//        </select>
//      </li> 
        
//        `
//        Child.innerHTML += ChildInnerHtml
//      })
//    }

//    if (childMinus != null) {

//      childMinus.addEventListener('click', (e) => {
//        e.preventDefault()

//        if (count > 0) {
//          count--;
//          const { children } = Child;

//          if (children.length) {
//            console.log(children.length);
//            Child.removeChild(children[children.length - 1]);
//          }


//          if (childSay.value == 0) {
//            childSay.value = 0
//          }
//          else {
//              childSay.value = count.valueOf()
//          }

//        }



//      })
//    }
//  }
//  AddChild()


//}
//AddRomms()

//function AddRomms() {
//    const AddromsData = document.querySelector(".addroomsTable")
//    const RoomData = document.querySelector(".addRoomModal_item")

//    let count = 0

//    if (RoomData != null) {
//        RoomData.addEventListener("click", function (e) {
//            e.preventDefault()
//            count++

//            const RommInnerHTML = `
    
   
//    <span>Room ${count}</span>
  
//    <div class="Room_itemModal">
//      <div class="_ModalItemHead">
//        <p>Adults</p>
//        <span class="roomMinus">-</span>
//        <span class="roomSay">0</span>
//        <span class="roomPlus">+</span>
  
//      </div>
//      <div class="_roomServiceModal">
//        <ul class="listbody">
        
//        <li>
//        <div class="countTypes">
      
//        </div>
   
//          <select name="RoomTypes" id="RoomTypes">
  
//            <option value="full board and treatment">full board and treatment
//            </option>
//            <option value="full board without treatment">full board without
//              treatment</option>
//            <option value="half board and treatment">half board and treatment
//            </option>
//            <option value="half board without treatment">half board without
//              treatment</option>
//          </select>
//        </li>
        
//        </ul>
//      </div>
//    </div>
  
//    <div class="Modal_item_child">
//      <div class="_ModalItemHeadChild">
//        <p>Children</p>
//        <span class="roomMinusChild">-</span>
//        <span class="roomSayChild">0</span>
//        <span class="roomPlusChild">+</span>
  
  
       
//      </div>
//    </div>
//    <div class="_roomServiceModal">
//      <ul class="listbodyChild">
//      <li>
//      <div class="countTypes">
      
//       </div>
 
//     <select name="RoomTypes" id="RoomTypes">
 
//       <option value="full board and treatment">full board and treatment
//       </option>
//       <option value="full board without treatment">full board without
//         treatment</option>
//       <option vallue="half board and treatment">half board and treatment
//       </option>
//       <option value="half board without treatment">half board without
//         treatment</option>
//     </select>
 
 
//     <select  name="AgeChild" id=" ageChild">
 
//       <option selected="selected" value="Age">Age</option>
//       <option value="1">1</option>
//       <option value="2">2</option>
//       <option value="3">3</option>
//       <option value="4">4</option>
//       <option value="5">5</option>
//       <option value="6">6</option>
//       <option value="7">7</option>
//       <option value="8">8</option>
//       <option value="9">9</option>
//       <option value="10">10</option>
//       <option value="11">11</option>
//       <option value="12">12</option>
//       <option value="13">13</option>
//       <option value="14">14</option>
//       <option value="15">15</option>
//       <option value="16">16</option>
//       <option value="17">17</option>
//       <option value="118">18</option>
//     </select>
//   </li> 
      
//      </ul>
//    </div>
    
//    `

//            AddromsData.innerHTML += RommInnerHTML
//        })
//    }
//    function addAdult() {

//        var RoomMinus = document.querySelector(".roomMinus")
//        var RoomMSayi = document.querySelector(".roomSay")
//        var RoomPlus = document.querySelector(".roomPlus")
//        let count = 0

//        const list = document.querySelector(".listbody")
//        const countTypes = document.querySelector(".countTypes")

//        const RoomAdultData = document.querySelector("._roomServiceModal")


//        if (RoomPlus != null) {
//            RoomPlus.addEventListener("click", (e) => {
//                e.preventDefault()
//                count++;
//                RoomMSayi.innerHTML = count

//                const newInnerHtml = `
    
       
//          <li>
//          <div class="countTypes">
//          ${count}
//          </div>
     
//            <select name="Withtreatment" id="RoomTypes">
    
//              <option value="true">full board and treatment
//              </option>
//              <option value="false">full board without
//                treatment</option>
             
//            </select>
//          </li>
        
    
//          `
//                list.innerHTML += newInnerHtml



//            })
//        }
//        if (RoomMinus != null) {
//            RoomMinus.addEventListener("click", () => {
//                if (count > 0) {
//                    count--;
//                    const { children } = list;

//                    if (children.length) {
//                        console.log(children.length);
//                        list.removeChild(children[children.length - 1]);
//                    }


//                    if (RoomMSayi.innerHTML == 0) {
//                        RoomMSayi.innerHTML = 0
//                    }
//                    else {
//                        RoomMSayi.innerHTML = count
//                    }

//                }
//            })
//        }
//    }
//    addAdult();


//    function AddChild() {
//        var childPlus = document.querySelector(".roomPlusChild")
//        var childMinus = document.querySelector(".roomMinusChild")
//        var childSay = document.querySelector(".roomSayChild")
//        var Child = document.querySelector(".listbodyChild")
//        let count = 0



//        if (childPlus != null) {

//            childPlus.addEventListener('click', (e) => {
//                e.preventDefault()
//                count++;
//                childSay.innerHTML = count

//                const ChildInnerHtml = `
//         <li>
//         <div class="countTypes">
//          ${count}
//          </div>
    
//        <select name="RoomTypes" id="RoomTypes">
    
//          <option value="full board and treatment">full board and treatment
//          </option>
//          <option value="full board without treatment">full board without
//            treatment</option>
//          <option vallue="half board and treatment">half board and treatment
//          </option>
//          <option value="half board without treatment">half board without
//            treatment</option>
//        </select>
    
    
//        <select  name="AgeChild" id=" ageChild">
    
//          <option selected="selected" value="Age">Age</option>
//          <option value="1">1</option>
//          <option value="2">2</option>
//          <option value="3">3</option>
//          <option value="4">4</option>
//          <option value="5">5</option>
//          <option value="6">6</option>
//          <option value="7">7</option>
//          <option value="8">8</option>
//          <option value="9">9</option>
//          <option value="10">10</option>
//          <option value="11">11</option>
//          <option value="12">12</option>
//          <option value="13">13</option>
//          <option value="14">14</option>
//          <option value="15">15</option>
//          <option value="16">16</option>
//          <option value="17">17</option>
//          <option value="118">18</option>
//        </select>
//      </li> 
        
//        `
//                Child.innerHTML += ChildInnerHtml
//            })
//        }

//        if (childMinus != null) {

//            childMinus.addEventListener('click', (e) => {
//                e.preventDefault()

//                if (count > 0) {
//                    count--;
//                    const { children } = Child;

//                    if (children.length) {
//                        console.log(children.length);
//                        Child.removeChild(children[children.length - 1]);
//                    }


//                    if (childSay.innerHTML == 0) {
//                        childSay.innerHTML = 0
//                    }
//                    else {
//                        childSay.innerHTML = count
//                    }

//                }



//            })
//        }
//    }
//    AddChild()


//}
//AddRomms()








//function Increment() {
//  let count = 0;
//  const plus = document.querySelector("#plus")
//  const Count = document.querySelector("#counts");
//  const Minus = document.querySelector("#minus");
//  if (plus != null) {
//    plus.addEventListener("click", function (e) {
//      e.preventDefault()
//      count++
//      Count.innerHTML = count
//    })
//  }
//  if (Minus != null) {
//    Minus.addEventListener("click", function (e) {
//      e.preventDefault()
//      if (count > 0) {
//        count--;
//        if (Count.innerHTML == 0) {
//          Count.innerHTML = 0
//        }
//        else {
//          Count.innerHTML = count
//        }
//      }
//    })
//  }
//}
//Increment()



//function Increment1() {
//  let count = 0;
//  const pluse = document.querySelector(".plu")
//  const Count = document.querySelector(".deyer");
//  const Minuse = document.querySelector(".min");
//  const childAges = document.querySelector(".childAges")

//  if (pluse != null) {
//    pluse.addEventListener("click", function (e) {
//      e.preventDefault();

//      count++
//      Count.innerHTML = count;

//      childAges.style.opacity = "1";



//    })
//  }
//  if (Minuse != null) {
//    Minuse.addEventListener("click", function (e) {
//      e.preventDefault()
//      if (count > 0) {
//        count--;
//        if (Count.innerHTML == 0) {
//          Count.innerHTML = 0
//        }
//        else {
//          Count.innerHTML = count
//        }
//      }
//    })
//  }
//}
//Increment1()


$(document).ready(function () {


  var accardion = function () {
    var data = $(".accordion").attr("data-accordion");

    $(".accordion-header").on("click", function () {
      if (data === "close") {
        $(".accordion-body").slideUp();
        if ($(this).hasClass("active")) {
          $(this).toggleClass("active");
        }
        else {
          $(".accordion-header").removeClass("active");
          $(this).toggleClass("active");
        }
      }
      else {
        $(this).toggleClass("active");
      }
      $(this).next(".accordion-body").not(":animated").slideToggle();
    });
  };

  accardion();


  $('.slider').slick({
    dots: false,
    prevArrow: '<i class="fas fa-chevron-left left"></i>',
    nextArrow: '<i class="fas fa-chevron-right right"></i>',
    infinite: false,
    speed: 300,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 1200,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 968,
        settings: {

          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 520,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
    ]
  });


  $('#detail .main-img-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    infinite: true,
    arrows: true,
    fade: true,
    autoplay: true,
    autoplaySpeed: 4000,
    speed: 300,
    lazyLoad: 'ondemand',
    asNavFor: '.thumb-nav',
    prevArrow: '<div class="slick-prev"><i class="i-prev"></i><span class="sr-only sr-only-focusable">Previous</span></div>',
    nextArrow: '<div class="slick-next"><i class="i-next"></i><span class="sr-only sr-only-focusable">Next</span></div>'
  });
  // Thumbnail/alternates slider for product page
  $('.thumb-nav').slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    infinite: true,
    centerPadding: '0px',
    asNavFor: '.main-img-slider',
    dots: false,
    centerMode: false,
    draggable: true,
    speed: 200,
    focusOnSelect: true,
    prevArrow: '<div class="slick-prev"><i class="i-prev"></i><span class="sr-only sr-only-focusable">Previous</span></div>',
    nextArrow: '<div class="slick-next"><i class="i-next"></i><span class="sr-only sr-only-focusable">Next</span></div>'
  });


  //keeps thumbnails active when changing main image, via mouse/touch drag/swipe
  $('.main-img-slider').on('afterChange', function (event, slick, currentSlide, nextSlide) {
    //remove all active class
    $('.thumb-nav .slick-slide').removeClass('slick-current');
    //set active class for current slide
    $('.thumb-nav .slick-slide:not(.slick-cloned)').eq(currentSlide).addClass('slick-current');
  });


});
const ClickAccardionButtons = document.querySelector("#AccardionButtons")
const OpenAccordionItem = document.querySelector(".AccardionItems")
const AccardionsIcon = document.querySelector(".accardionSocial i")
if (ClickAccardionButtons != null) {
  ClickAccardionButtons.addEventListener("click", (e) => {

    e.preventDefault();
    if (OpenAccordionItem.style.opacity === "0") {
      OpenAccordionItem.style.opacity = "1";
      AccardionsIcon.style.transform = "rotate(180deg)";

    } else {
      OpenAccordionItem.style.opacity = "0";
      AccardionsIcon.style.transform = "rotate(0deg)";
    }

  })
}


function modalSlider($modal, $trigger) {

  var $overlay = $('.overlay'),
    $modalInner = $('.modal-inner'),
    $modalClose = $('.modal-close'),
    $slider = $modal.find('.slider'),
    $btnPrev = $('.btn-prev'),
    $btnNext = $('.btn-next'),
    $body = $('body'),
    showClass = 'show',
    noScrollClass = 'no-scroll';

  var currentIndex = 0,
    sliderSum = $slider.length - 1;


  $trigger.on('click', function (e) {
    e.preventDefault();
    currentIndex = $trigger.index(this);

    $modal.addClass(showClass);
    $modalInner.addClass(showClass);

    $slider.removeClass(showClass);
    $slider.eq(currentIndex).addClass(showClass);

    $body.addClass(noScrollClass);
    // noScroll();
  });


  $modalClose.on('click', function () {
    hideModal();

  });
  $('.to-attention').on('click', function () {
    hideModal();

  });


  $overlay.on('click', function () {
    hideModal();
    // noScroll();
  });


  var hideModal = function () {
    $modal.removeClass(showClass);
    $modalInner.removeClass(showClass);
    $body.removeClass(noScrollClass);
    // noScroll();
  }


  var hideBtn = function () {
    if (currentIndex === 0) {
      $btnPrev.removeClass(showClass);
    } else if (currentIndex === sliderSum) {
      $btnNext.removeClass(showClass);
    } else {
      $btnPrev.addClass(showClass);
      $btnNext.addClass(showClass);
    }
  }


  function mvSlider() {

    $btnPrev.on('click', function () {
      if (currentIndex === 0) {
        currentIndex = sliderSum;
      } else {
        currentIndex = currentIndex - 1;
      }

      switchSlider();
    });


    $btnNext.on('click', function () {
      if (currentIndex === sliderSum) {
        currentIndex = 0;
      } else {
        currentIndex = currentIndex + 1;
      }

      switchSlider();
    });


    function switchSlider() {
      $slider.removeClass(showClass);
      $slider.eq(currentIndex).addClass(showClass);
    }
  }

  mvSlider();
}

modalSlider($('.modal-wrap'), $('.modal-trigger'));


//Navbar
//Tabs Item Tour Page

$('.tabgroup > div').hide();
$('.tabgroup > div:first-of-type').show();
$('.tabs a').click(function (e) {
  e.preventDefault();
  var $this = $(this),
    tabgroup = '#' + $this.parents('.tabs').data('tabgroup'),
    others = $this.closest('li').siblings().children('a'),
    target = $this.attr('href');
  others.removeClass('active');
  $this.addClass('active');
  $(tabgroup).children('div').hide();
  $(target).show();

})

$(document).ready(function () {
  $('.picZoomer').picZoomer();
  $('.piclist li').on('click', function (event) {
    var $pic = $(this).find('img');
    $('.picZoomer-pic').attr('src', $pic.attr('src'));
  });

  var owl = $('#recent_post');
  owl.owlCarousel({
    margin: 20,
    dots: false,
    nav: true,
    navText: [
      "<i class='fa fa-chevron-left'></i>",
      "<i class='fa fa-chevron-right'></i>"
    ],
    autoplay: true,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 2
      },
      600: {
        items: 3
      },
      1000: {
        items: 5
      },
      1200: {
        items: 4
      }
    }
  });

  $('.decrease_').click(function () {
    decreaseValue(this);
  });
  $('.increase_').click(function () {
    increaseValue(this);
  });
  function increaseValue(_this) {
    var value = parseInt($(_this).siblings('input#number').val(), 10);
    value = isNaN(value) ? 0 : value;
    value++;
    $(_this).siblings('input#number').val(value);
  }

  function decreaseValue(_this) {
    var value = parseInt($(_this).siblings('input#number').val(), 10);
    value = isNaN(value) ? 0 : value;
    value < 1 ? value = 1 : '';
    value--;
    $(_this).siblings('input#number').val(value);
  }
});


; (function ($) {
  $.fn.picZoomer = function (options) {
    var opts = $.extend({}, $.fn.picZoomer.defaults, options),
      $this = this,
      $picBD = $('<div class="picZoomer-pic-wp"></div>').css({ 'width': opts.picWidth + 'px', 'height': opts.picHeight + 'px' }).appendTo($this),
      $pic = $this.children('img').addClass('picZoomer-pic').appendTo($picBD),
      $cursor = $('<div class="picZoomer-cursor"><i class="f-is picZoomCursor-ico"></i></div>').appendTo($picBD),
      cursorSizeHalf = { w: $cursor.width() / 2, h: $cursor.height() / 2 },
      $zoomWP = $('<div class="picZoomer-zoom-wp"><img src="" alt="" class="picZoomer-zoom-pic"></div>').appendTo($this),
      $zoomPic = $zoomWP.find('.picZoomer-zoom-pic'),
      picBDOffset = { x: $picBD.offset(),left, y: $picBD.offset().top };


    opts.zoomWidth = opts.zoomWidth || opts.picWidth;
    opts.zoomHeight = opts.zoomHeight || opts.picHeight;
    var zoomWPSizeHalf = { w: opts.zoomWidth / 2, h: opts.zoomHeight / 2 };


    $zoomWP.css({ 'width': opts.zoomWidth + 'px', 'height': opts.zoomHeight + 'px' });
    $zoomWP.css(opts.zoomerPosition || { top: 0, left: opts.picWidth + 30 + 'px' });

    $zoomPic.css({ 'width': opts.picWidth * opts.scale + 'px', 'height': opts.picHeight * opts.scale + 'px' });


    $picBD.on('mouseenter', function (event) {
      $cursor.show();
      $zoomWP.show();
      $zoomPic.attr('src', $pic.attr('src'))
    }).on('mouseleave', function (event) {
      $cursor.hide();
      $zoomWP.hide();
    }).on('mousemove', function (event) {
      var x = event.pageX - picBDOffset.x,
        y = event.pageY - picBDOffset.y;

      $cursor.css({ 'left': x - cursorSizeHalf.w + 'px', 'top': y - cursorSizeHalf.h + 'px' });
      $zoomPic.css({ 'left': -(x * opts.scale - zoomWPSizeHalf.w) + 'px', 'top': -(y * opts.scale - zoomWPSizeHalf.h) + 'px' });

    });
    return $this;

  };
  $.fn.picZoomer.defaults = {
    picHeight: 500,
    scale: 1.3,
    zoomerPosition: { top: '0', left: '0px' },

    zoomWidth: 000,
    zoomHeight: 000
  };
})(jQuery);
$(window).on('load', function () { // makes sure the whole site is loaded 
  $('#status').fadeOut(); // will first fade out the loading animation 
  $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website. 
  $('body').delay(350).css({ 'overflow': 'visible' });
})

var swiper = new Swiper(".mySwiper", {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 2500,
        disableOnInteraction: false,
    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});