using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    //public string cenaDestino; 
    public void CarregarCenaDestino(string cenaDestino )
    {
        SceneManager.LoadScene(cenaDestino);
    }
}
