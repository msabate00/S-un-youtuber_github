#pragma strict

var yutub : GameObject;
var yo : GameObject;
var otro : GameObject;

function Start () {
   // yutub.active = false;
}

function Update () {
    if (Input.GetMouseButtonDown(0)) {
        
    }
}
function OnMouseDown () {
    yutub.active = true;
    yo.active = false;
    otro.active = true; 
   
  
}