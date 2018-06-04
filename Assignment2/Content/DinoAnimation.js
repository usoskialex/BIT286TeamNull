/* Dino animation for the kids project */
/* Huge thank you for the code below to Blake Bowen who's code I implemented in the project /codepen.io/anon/pen/pVdKga */

var svg = document.querySelector("#eyes");
var mouse = svg.createSVGPoint();

var leftEye = createEye("#left-eye");
var rightEye = createEye("#right-eye");

var requestId = null;

window.addEventListener("mousemove", onMouseMove)

function onFrame() {
  
  var point = mouse.matrixTransform(svg.getScreenCTM().inverse());
  
  leftEye.rotateTo(point);
  rightEye.rotateTo(point);
  
  requestId = null;
}

function onMouseMove(event) {
  mouse.x = event.clientX;
  mouse.y = event.clientY;
  
  if (!requestId) {
    requestId = requestAnimationFrame(onFrame);
  }
}

function createEye(selector) {
  
  var element = document.querySelector(selector);
  
  TweenMax.set(element, {
    transformOrigin: "center"
  });
  
  var bbox = element.getBBox();
  var centerX = bbox.x + bbox.width / 2;
  var centerY = bbox.y + bbox.height / 2;
  
  function rotateTo(point) {
    
    var dx = point.x - centerX;
    var dy = point.y - centerY;
    
    var angle = Math.atan2(dy, dx);
    
    TweenMax.to(element, 0.3, {
      rotation: angle + "_rad_short"
    });
  }
  
  return {
    element: element,
    rotateTo: rotateTo
  };
}


<!-- MOVING EYES END -->
<!-- moving tail-->

var element = document.getElementById("path3229");

TweenMax.to(element, 0.3, {x:"+=30", yoyo:true, repeat:-1});
TweenMax.to(element, 0.3, {x:"-=10", yoyo:true, repeat:-1});

var element = document.getElementById("path3334");

TweenMax.to(element, 0.3, {x:"+=30", yoyo:true, repeat:-1});
TweenMax.to(element, 0.3, {x:"-=15", yoyo:true, repeat:-1});

/*foots*/
$("#path3220, #path3245").click(function(){
  TweenLite.fromTo(this, 0.3, {x:-1}, {x:1, ease:RoughEase.ease.config({strength:15, points:20, template:Linear.easeNone, randomize:false}) , clearProps:"x"})
})

/*right horn*/

$("#path3190_1_").click(function(){
    $(this).hide();
    alert("Never touch Dino's horns!!! It hurts :(");
});

/*left horn*/

var horn = document.getElementById("#path3214_3_, #path3363_2_");

$("#path3214_3_").click(function(){
    TweenLite.to(this, 5, { ease: Power3.easeOut, x: 33 });
    alert("Actually, I like when you touch my left horn :) I always wanted to be a unicorn!!!!");
});



/*horse*/
$(".st5").click(function(){
  TweenLite.fromTo(this, 0.3, {x:-4}, {x:4, ease:RoughEase.ease.config({strength:20, points:50, template:Linear.easeNone, randomize:true}) , clearProps:"x"})
})




/*free animals*/
$("#button1").click(function(){
        $("#Layer_1").hide();
    });

$("#button2").click(function(){
        $("#Layer_2").hide();
    });

/*get them back*/
$("#button3").click(function(){
        $("#Layer_1, #Layer_2").show();
    });