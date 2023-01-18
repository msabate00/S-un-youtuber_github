#pragma strict

var pene : GameObject;
var polla : GameObject;
var polla2 : GameObject;
var polla3 : GameObject;
var polla4 : GameObject;
var polla5 : GameObject;
var monitor : GameObject;
var opsions : GameObject;
var opsions2 : GameObject;
var opsions3 : GameObject;
var opsions4 : GameObject;
var opsions5 : GameObject;
var out : GameObject;
var cama : GameObject;


function Start () {
    pene.active = false;   
    polla.active = false;
    monitor.active = true;
    opsions.active = false;
    out.active = false;
    opsions4.active = false;
}

function Update () {
	
}

function OnMouseOver () {
    
    pene.active = true;
}

function OnMouseExit () {
    
    pene.active = false;
}

function OnMouseDown () {
    
    pene.active = false;
    polla.active = true;
    polla2.active = true;
    polla3.active = true;
    monitor.active = false;
    opsions.active = true;
    opsions2.active = true;
    opsions3.active = true;
    out.active = true;
    cama.active = false;
    opsions4.active = true;
    polla4.active = true;
    polla5.active = true;
    opsions5.active = true;
}
