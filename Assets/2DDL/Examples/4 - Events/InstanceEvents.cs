namespace DynamicLight2D
{
	using UnityEngine;
	using System.Collections;
	
	public class InstanceEvents : MonoBehaviour {
		
		DynamicLight2D.DynamicLight light2d;
		float speed = .3f;
        float moveSpeed = 5f;

        private SpriteRenderer sr;

        public GameObject go;
		
		
		IEnumerator Start () {
			// Find and set 2DLight Object //
			light2d = GameObject.Find("2DLight").GetComponent<DynamicLight2D.DynamicLight>() as DynamicLight2D.DynamicLight;

            sr = GetComponent<SpriteRenderer>();
			
			// Add listeners
			
			//light2d.OnEnterFieldOfView += onEnter;
			//light2d.OnExitFieldOfView += onExit;
			
			
			yield return new WaitForEndOfFrame();
			//StartCoroutine(loop());
			
		}

        IEnumerator loop(){
			while(true){
				Vector3 pos = gameObject.transform.position;
				if(pos.y < -39){
					pos.y = 20;
					
				}else{
					pos.y -= speed;
				}
				
				
				
				yield return new WaitForEndOfFrame();
				gameObject.transform.position = pos;
			}
		}

        private void Update()
        {
            float h = Input.GetAxis("Horizontal");//x轴
            float v = Input.GetAxis("Vertical");//Y轴
            
            transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.Self);
            transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.Self);
        }

        void onExit(GameObject g, DynamicLight2D.DynamicLight light){
			Debug.Log("OnExit");
            transform.rotation = Quaternion.AngleAxis(0.0f, transform.forward);
            GetComponent<SpriteRenderer>().color = Color.white;
			speed = 0.3f;
		}
		
		void onEnter(GameObject g, DynamicLight2D.DynamicLight light){
			
			if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
				Debug.Log("OnEnter");
                //Vector3 rota = new Vector3(0, 0, 30);
                transform.rotation = Quaternion.AngleAxis(30.0f, transform.forward);
				GetComponent<SpriteRenderer>().color = Color.red;
				speed = 0.03f;	
			}
			
		}
		
	}

}


