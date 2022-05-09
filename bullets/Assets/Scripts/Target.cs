using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Vector2 targetVelocity=new Vector2(5,0);

    [SerializeField] private float speed = 5;
    private Rigidbody2D rigdbody2d;
    
    static  Vector2 backwardX= new Vector2(-1,1);
    static  Vector2 backwardY= new Vector2(1,-1);
    

    Bounds cameraBounds;

    void SetCameraBounds(){    
        cameraBounds=OrthographicBounds(Camera.main);    
    }

    private void Awake()
    {
        SetCameraBounds();
        rigdbody2d = GetComponent<Rigidbody2D>();
        //cameraBounds=OrthographicBounds(Camera.main);
        SetCameraBounds();
        SetVelocity();
    }



    private void SetVelocity()
    {
        float x = Random.Range(1.0f, 2.0f);
        float y = Random.Range(1.0f, 2.0f);
        rigdbody2d.velocity=new Vector2(x*speed,y*speed);
    }


    public static Bounds OrthographicBounds (Camera camera)
     {
         if (!camera.orthographic)
         {
             Debug.Log(string.Format("The camera {0} is not Orthographic!", camera.name), camera);
             return new Bounds();
         }
 
         var t = camera.transform;
         var x = t.position.x;
         var y = t.position.y;
         var size = camera.orthographicSize * 2;
         var width = size * (float)Screen.width / Screen.height;
         var height = size;
 
         return new Bounds(new Vector3(x, y, 0), new Vector3(width, height, 0));
     }

    private void FixedUpdate()
    {

        if ((transform.position.x > cameraBounds.max.x)||(transform.position.x < cameraBounds.min.x))
        {
            rigdbody2d.velocity = rigdbody2d.velocity * backwardX;
        }
        
        if ((transform.position.y < cameraBounds.min.y)||(transform.position.y > cameraBounds.max.y) )
        {
            rigdbody2d.velocity=rigdbody2d.velocity*backwardY;
        }

    }

    
}
