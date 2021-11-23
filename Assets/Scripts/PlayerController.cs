using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //Variables del movimiento del personaje
    public float jumpForce = 6f;
    private float distanceRay = 1f;
    public float runningSpeed = 2f;
    Vector3 startPosition;
    private Rigidbody2D rigidBody;
    //Ahora para agregarle animación al personaje dependiendo de su estado
    Animator animator;
    //private  TimeController timeController;
    //Para el sonido
    public AudioSource clip;

    //Necesito referenciar las variables booleanas que he creado en Unity (IsOnTheGround)

    private const string STATE_ON_THE_GROUND = "IsOnTheGround";
    private const string STATE_IS_WALKING = "IsWalking";
    
    public LayerMask groundMask;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()    
    {
      
        startPosition = this.transform.position;
        //timeController = GameObject.Find("TimeController").GetComponent<TimeController>();

    }

    public void StartGame()
    {   //Cuando empezamos a jugar el jugador no estará en el suelo
        animator.SetBool(STATE_ON_THE_GROUND, false);
        animator.SetBool(STATE_IS_WALKING, false); 
        this.transform.position = startPosition;
        //Esto se pone para que la velocidad sea igual a la de la inicial
        this.rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {   

            Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        //Debug.DrawRay(this.transform.position, Vector2.down * distanceRay, Color.red);
    }

    private void FixedUpdate()
    {           
        if (Input.GetKey(KeyCode.RightArrow))
        {   //Para la direccion de la animacion
            rigidBody.GetComponent<SpriteRenderer>().flipX = false;
            //Para la velocidad de movimiento en X
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            //Para activar el estado STATE_IS_WALKING
            animator.SetBool(STATE_IS_WALKING, true);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {   rigidBody.GetComponent<SpriteRenderer>().flipX = true;
            rigidBody.velocity = new Vector2(-runningSpeed, rigidBody.velocity.y);
            animator.SetBool(STATE_IS_WALKING, true);
        }
        else
        {   //Poner en estado off la animación de caminar
            animator.SetBool(STATE_IS_WALKING, false);
            //Evitar deslizamiento cuando se desactive la fricción  
            rigidBody.velocity = new Vector2(runningSpeed * 0, rigidBody.velocity.y);
        }
    }

    // Es un método que si o si se va a utilizar
    void Jump()
    {
        animator.SetBool(STATE_IS_WALKING, false);

        if (IsTouchingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
        }

    
    }
    // Para esto debo crear un nuevo Layer llamado Ground para todas las plataformas
    //Esto nos va a servir para que el salto no se haga consecutivo
    bool IsTouchingTheGround()
    {   //this.position = desde la posición desde donde hasta donde quiero trazar el rayo (down) 
        if (Physics2D.Raycast(this.transform.position, Vector2.down, distanceRay,groundMask))
        {       
            //GameManager.sharedInstance.currentGameState = GameManager.GameState.inGame;
            
            return true;
            
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Incorrect")
        {
            print("Colision - Disminuye el tiempo");
            TimeController.timeController.disminucion(5);
        }
        else if (collision.CompareTag("Correct"))
        {   
            if (Application.loadedLevelName == "Level_1")  SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
            else if (Application.loadedLevelName == "Level_2") SceneManager.LoadScene("Level_3", LoadSceneMode.Single);
            else if (Application.loadedLevelName == "Level_3") SceneManager.LoadScene("Level_4", LoadSceneMode.Single);
            else if (Application.loadedLevelName == "Level_4") SceneManager.LoadScene("Level_5", LoadSceneMode.Single);
            else if (Application.loadedLevelName == "Level_5") SceneManager.LoadScene("Level_6", LoadSceneMode.Single);
            else if (Application.loadedLevelName == "Level_6") SceneManager.LoadScene("Level_7", LoadSceneMode.Single);
            else if (Application.loadedLevelName == "Level_7") SceneManager.LoadScene("Level_8", LoadSceneMode.Single);
            print("Colision - Gano el juego");
        }
        else if (collision.CompareTag("Coin"))
        {
            print("Colision - Aumenta el tiempo");
            TimeController.timeController.restante += 10;
        }
    }


}
