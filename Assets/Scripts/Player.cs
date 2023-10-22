using UnityEngine;

/// <summary>
/// this script is used to control our player
/// and manage his collisions
/// at the start of the scrit we get player's rigidbody2D component
/// in the Jump method we get the input and push up the player
/// adding a force to his rigidBody
/// 
/// we also check the collisions with the walls and triggers with the scores
/// if the player hit the wall its gameover
/// else if the player trigger the score we will increase the value score in gm(Game Manager)
/// </summary>


public class Player : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    
    //[SerializeField] AudioSource dieAudio, pointAudio, flyAudio;

    [SerializeField] private float upForce = 5f;
    bool _isAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if(rigidBody == null)
        {
            Debug.LogError($"Missing Ridibody on gameobject [{gameObject.name}]");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive) {
            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.gravityScale = 0.5f;
            rigidBody.velocity = new Vector2(0, upForce);    
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score" )
        {
            //pointAudio.Play();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameManager.gameManager.PlayerScored();
            

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" )
        {
            
            _isAlive = false;
            //dieAudio.Play();
            GetComponent<Animator>().SetTrigger("die");
            GameManager.gameManager.IsGameOver(true);
            this.enabled = false;
        }
    }
    
}
