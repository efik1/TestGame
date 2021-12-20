using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    public ParticleSystem particleSystem;
    
    private void Start()
    {
        particleSystem.Stop();
    }
    private void Awake()
    {
        particleSystem.Play();
    }
}
