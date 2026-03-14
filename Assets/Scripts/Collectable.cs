using UnityEngine;

public class Collectable : MonoBehaviour
{
    
Animator animator;

   private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

   private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < leftEdge){
            Destroy(gameObject);
            animator.enabled = false;
        }
    }

}
