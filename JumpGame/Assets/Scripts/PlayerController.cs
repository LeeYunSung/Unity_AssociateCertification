using UnityEngine;

public class PlayerController : MonoBehaviour{

    private const float jumpForce = 15f;
    private const float gravityModifier = 3f;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    private bool isOnGround = true;
    private bool isGameOver = false;

    public static PlayerController Instance;
    private void Awake(){
        if (Instance == null) Instance = this;
    }

    void Start(){
        playerRb = transform.GetComponent<Rigidbody>();
        playerAnim = transform.GetComponent<Animator>();
        playerAudio = transform.GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {
            isGameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            dirtParticle.Stop();
            explosionParticle.Play();

            playerAudio.PlayOneShot(crashSound, 0.5f);
        }
    }

    public bool GetGameOver(){
        return isGameOver;
    }
}
