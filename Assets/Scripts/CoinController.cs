using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pontuacao pontuacao = other.GetComponent<Pontuacao>();
            pontuacao.AddPoints();
            Destroy(this.gameObject);
        }
    }
}
