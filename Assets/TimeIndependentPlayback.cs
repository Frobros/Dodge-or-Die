using System;
using UnityEngine;

public class TimeIndependentPlayback : MonoBehaviour
{
    bool active = false;
    ParticleSystem particles;
    IndependentDeltaTime _time;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        _time = FindObjectOfType<IndependentDeltaTime>();
        Debug.Log(particles.time);
    }

    private void Update()
    {
        if (active)
        {
            particles.Simulate(_time.deltaTime, true, false);
            Debug.Log(particles.time);
        }

    }

    public void PlayParticles()
    {
        active = true;
        particles.Play(true);
    }
}
