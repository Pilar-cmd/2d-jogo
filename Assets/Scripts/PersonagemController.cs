using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemController : MonoBehaviour
{
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        
    }
}
