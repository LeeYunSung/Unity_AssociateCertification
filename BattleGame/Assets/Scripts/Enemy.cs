using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;

    private void Start(){
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update(){
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        //¾Æ·¡·Î ¶³¾îÁö¸é Enemy °´Ã¼ ÆÄ±«
        if (transform.position.y < -10) Destroy(gameObject);
    }
}
