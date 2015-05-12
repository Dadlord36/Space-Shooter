using UnityEngine;

public class DesrtoyByContact : MonoBehaviour
{

    //public Animator anim;
    public GameObject playerExplosion;
    public GameObject explosion;
    public int scoreValue = 10;
    private GameController gameController;


    //void Awake()
    //{
    //    anim = GetComponent<Animator>();
    //}


    void Start()
    {
         
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            gameController = GameControllerObject.GetComponent<GameController>();
        }

        if (gameController = null)
        {
            Debug.Log("Невозможно найти GameControllre script");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        //if (other.tag == "Player")
        //{
            
        //    return;
        //}

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        ;
        Destroy(other.gameObject);
        Destroy(gameObject);
        ScoreManager.score += scoreValue;

    }
}
