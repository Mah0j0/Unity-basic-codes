using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneInteraction : MonoBehaviour
{
    public Image[] heartSprites; // Arreglo de sprites de corazones
    public int VidasActuales = 3; // Vidas iniciales
    public float jumpBoostDuration = 5f; // Duración del aumento de salto
    public float jumpBoostMultiplier = 2f; // Multiplicador del salto

    private int maxVidas = 5;
    private bool isJumpBoosted = false;

    void Start()
    {
        UpdateHeartDisplay();
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "HongoAumentaVida":
                IncreaseLife();
                break;
            case "HongoQuitaVida":
                DecreaseLife();
                break;
            case "Quitar2Vidas":
                Decrease2Lifes();
                break;
            default:
                Debug.Log("Colisión desconocida con " + other.gameObject.name);
                break;
        }
    }

    void IncreaseLife()
    {
        if (VidasActuales < maxVidas)
        {
            VidasActuales++;
            UpdateHeartDisplay();
        }
    }

    void DecreaseLife()
    {
        if (VidasActuales > 0)
        {
            VidasActuales--;
            UpdateHeartDisplay();
        }
    }
    void Decrease2Lifes()
    {
        if (VidasActuales > 0)
        {
            VidasActuales=1;
            UpdateHeartDisplay();
        }
    }

    void UpdateHeartDisplay()
    {
        for (int i = 0; i < heartSprites.Length; i++)
        {
            heartSprites[i].enabled = i < VidasActuales;
        }
    }
}