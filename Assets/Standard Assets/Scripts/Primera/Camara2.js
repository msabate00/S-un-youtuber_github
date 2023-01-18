#pragma strict

var out : GameObject;
var obj : GameObject;

function Start () {
    out.active = false;	
    obj.active = false;
}

function Update () {
    if (Amplia.num >= 1 && Amplia.num <= 1.9) {;
        GetComponent.<Animation>().Play ("lol");
        obj.active = false;
        out.active = false;   
    }
    if (Amplia.num >= 2) {;
        GetComponent.<Animation>().Play ("lel");
        out.active = true;
        obj.active = true;   
    }
}

//Else if (life > 5) && (life <= 10) {