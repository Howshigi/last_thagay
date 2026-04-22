using UnityEngine;

public class Senser : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over");
        GameManager.Instance.GameOver();
    }

}
