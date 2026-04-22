using UnityEngine;

public class ColorBox : MonoBehaviour
{
   public string correctTag; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(correctTag))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
            
        }
    }
}