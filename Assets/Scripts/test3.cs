using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicLight2D;

public class test3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PolygonCollider2D polygonCollider2D = this.GetComponent<PolygonCollider2D>();
        Vector2[] vector2s = new Vector2[4];
        vector2s[0] = new Vector2(-2.56f, 2.56f);
        vector2s[1] = new Vector2(-2.56f, -2.56f);
        vector2s[2] = new Vector2(2.56f, -2.56f);
        vector2s[3] = new Vector2(12.56f, 12.56f);
        //List<Vector2> colliderPoints = DynamicLight.GetColliderPoints();
        polygonCollider2D.SetPath(0, vector2s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
