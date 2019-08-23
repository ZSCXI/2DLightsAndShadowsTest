using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicLight2D;

public class test : MonoBehaviour
{
    // Float a rigidbody object a set distance above a surface.

    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).

    Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //check();
        Debug.Log("identity: " + Quaternion.identity);
        MeshFilter meshFilter = new MeshFilter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void check()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;

            // The force is proportional to the height error, but we remove a part of it
            // according to the object's speed.
            //float force = liftForce * heightError - rb2D.velocity.y * damping;

            // Apply the force to the rigidbody.
            //rb2D.AddForce(Vector3.up * force);
            Debug.Log("collider name :"+ hit.collider.name);
            Debug.Log("centrid: "+hit.centroid);
            Debug.Log("collider: "+ hit.collider);
            Debug.Log("distance: " + hit.distance);
            Debug.Log("fraction: "+hit.fraction);
            Debug.Log("normal: "+ hit.normal);
            Debug.Log("point: " + hit.point); //撞击点
            Debug.Log("tranform: " + hit.transform);
        }
    }
}
