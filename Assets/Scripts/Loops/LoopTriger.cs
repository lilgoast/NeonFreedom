using UnityEngine;

public class LoopTriger : MonoBehaviour
{
    bool loopHitted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !loopHitted)
        {
            PlayParticle(0);
            loopHitted = true;
        }
        else if(other.CompareTag("DestroyingPlane") && !loopHitted)
        {
            PlayParticle(1);
            loopHitted = true;
        }
        DestroyLoop();
    }

    private void DestroyLoop()
    {
        Destroy(gameObject);
        Destroy(gameObject.transform.parent.gameObject);
    }

    private void PlayParticle(int particleIndex)  // 0 - hit, 1 - miss
    {
        gameObject.transform.GetChild(particleIndex).GetComponent<ParticleSystem>().Play();
        gameObject.transform.DetachChildren();
    }


}
