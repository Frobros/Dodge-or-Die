using UnityEngine;

public class ParticlePlayback : MonoBehaviour
{
    bool active = false;
    ParticleSystem particles;
    IndependentDeltaTime _time;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        _time = FindObjectOfType<IndependentDeltaTime>();
    }

    private void Update()
    {
        if (active)
        {
            particles.Simulate(_time.deltaTime, true, false);
        }

    }

    public void PlayParticles()
    {
        active = true;
        particles.Play(true);
    }
}
