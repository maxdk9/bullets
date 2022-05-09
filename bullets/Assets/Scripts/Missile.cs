using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    [SerializeField] private float rotationSpeed=1f;
    [SerializeField] private float movementSpeed=2f;
    private Rigidbody2D rigitbody2d;
    private Quaternion rotTarget;
    private Vector3 direction;
    private Target target;


    public void  SetTarget(Target t)
    {
        target = t;
    }
    
    private void Awake()
    {
        rigitbody2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 pTarget = ((Vector2) transform.position - (Vector2) target.transform.position);
            pTarget.Normalize();
            float value = Vector3.Cross(pTarget, transform.right).z;
            rigitbody2d.angularVelocity = rotationSpeed * value * 100;
            rigitbody2d.velocity = transform.right * movementSpeed;            
        }
    }


   

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(this.gameObject);
        Instantiate(ExplosionPrefab,
            this.transform.position,Quaternion.identity);
    }
}
