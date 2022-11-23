using UnityEngine;

public class LoopTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
        if(other.tag == "DestroyingPlane")
        {
            Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
