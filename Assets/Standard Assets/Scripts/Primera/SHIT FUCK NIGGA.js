#pragma strict

var lal : int = 1;
var w1 : GameObject;
var w2 : GameObject;
var w3 : GameObject;
var yo : GameObject;

function Start () {
	
}

function Update () {
	
}

function OnMouseDown () {
    
    Amplia.num = lal;
    Debug.Log(Amplia.num);
    w1.active = true;
    w2.active = false;
    w3.active = false;
    yo.active = false;
}