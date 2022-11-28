using UnityEngine;

public class LoopTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
        if(other.CompareTag("DestroyingPlane"))
        {
            Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
