using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float move;

    public static bool isGrounded = false;
    private GameObject finishPosition;



    private void Start()
    {
        
        finishPosition = GameObject.Find("FinishPosition");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Check ground");
        if (other.CompareTag("Ground"))
            isGrounded = true;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    //isGrounded = false;
        //    //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        //    //this.transform.position += new Vector3(0, 3f, 0);
        //}
        
        float moved = Input.GetAxis("Horizontal") * move * Time.deltaTime;
        transform.Translate(moved,0,speed*Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, finishPosition.transform.position,
        //    Time.deltaTime * speed);
    }
}
