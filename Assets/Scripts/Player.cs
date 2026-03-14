using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    
    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioClip deathSound;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void onEnable()
    {
        direction = Vector3.zero;   
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }
        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")){
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);

            GameManager.Instance.GameOver();
        }

        if (other.CompareTag("Collectable")){
            SoundFXManager.instance.PlaySoundFXClip(collectSound, transform, 1f);
            GameManager.Instance.score += 50;
            Destroy(other.gameObject);
            
        }       
    }        
}

