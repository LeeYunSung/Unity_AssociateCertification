using UnityEngine;

public class PlayerController : MonoBehaviour{

    private const float jumpForce = 15f;
    private const float gravityModifier = 3f;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private bool isOnGround = true;
    private bool isGameOver = false;

    public static PlayerController Instance;
    private void Awake(){
        if (Instance == null) Instance = this;
    }

    void Start(){
        playerRb = transform.GetComponent<Rigidbody>();
        playerAnim = transform.GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

    public bool GetGameOver(){
        return isGameOver;
    }
}
