using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingParticleScript : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.Particle[] m_Particles;
    public Transform target;
    public float speed = 5f;
    private int numParticlesAlive;
    private float step = 0;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (!GetComponent<Transform>())
        {
            GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Particles == null)
            m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];

        numParticlesAlive = ps.GetParticles(m_Particles);
        step = speed * Time.deltaTime;
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, target.position, step);


        }


        ps.SetParticles(m_Particles, numParticlesAlive);
    }
    public void InitAttractorMove(Transform _target)
    {
        target = _target;

        step = 0;

       // distance = 0;
    }
}
