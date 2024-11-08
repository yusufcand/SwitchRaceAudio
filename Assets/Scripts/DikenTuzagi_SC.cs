using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DikenTuzagi_SC : MonoBehaviour
{
    [SerializeField] private CarMaterialController carMaterialController;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        carMaterialController = GameObject.FindWithTag("Player").GetComponent<CarMaterialController>();
    }

    private void OnTriggerStay2D(Collider2D collision) // k�rm�z� ara�, hareket tuza��ndan ge�er
    {
        if (carMaterialController.currentMat.name != "GreenMaterial")
        {
            Destroy(collision.gameObject);
            reloadScene(); // animasyon koyulacaksa bekleme kodu yaz�labilir.
            audioManager.PlaySFX(audioManager.deathSFX);
        }
        else if (carMaterialController.currentMat.name == "GreenMaterial")
        {
            // hi�bir �ey olmayacak.
        }
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
