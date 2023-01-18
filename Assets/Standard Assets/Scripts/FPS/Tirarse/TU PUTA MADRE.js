var projectile : Rigidbody;
var speed = 20;
var instantiatedProjectile;

function Update()
{
    
       
        instantiatedProjectile.velocity =
         transform.TransformDirection( Vector3( -1, 0, 0 ) );
        Physics.IgnoreCollision( instantiatedProjectile. collider,
         transform.root.GetComponent.<Collider>() );
    
}
