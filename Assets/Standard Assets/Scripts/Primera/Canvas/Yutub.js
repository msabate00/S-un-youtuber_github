#pragma strict

var yutub : GameObject;
var otro : GameObject;
var yo : GameObject;

function Start () {
	
}

function Update () {
    if (Input.GetMouseButtonDown(0)) {
       
    }

}
function OnMouseDown () {
    yutub.active = true;
    otro.active = false;    
    yo.active = false;
    Debug.Log ("Va coño joder");  
}