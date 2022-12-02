using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CapsulesTimer : MonoBehaviour
{
    [Header("TIME")] 
        [SerializeField]
        float timer;
        [SerializeField]
        float timeMin = 10f;
        [SerializeField]
        float timeMax = 30f;

    [Header("UI")]
        [SerializeField]
        Slider sliderTimeLeft;
        [SerializeField]
        TextMeshProUGUI timeText;

    [Header("GAMEOBJECT")]
        [SerializeField]
        GameObject capsule;
        [SerializeField]
        GameObject controller;

    [Header("PARTICLE SYSTEM")]
        [SerializeField]
        GameObject prefabParticles;

    [Header("MATERIALS")]
        [SerializeField]
        Material blue;
        [SerializeField]
        Material red;


    //Al iniciar el script
    private void OnEnable()
    {
        //Se da valor a timer entre dos números aleatorios
        timer = Random.Range(timeMin, timeMax);

        //Se le asigna el valor máximo del slider el valor de timer
        sliderTimeLeft.maxValue = timer;

        //Se activan los elementos en caso de no estarlo (los nuevos)
        sliderTimeLeft.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        capsule.gameObject.SetActive(true);

        //El color de la cápsula es azul
        capsule.gameObject.GetComponent<MeshRenderer>().material = blue;
        //capsule.gameObject.LeanColor(Color.blue, 0.5f).setEaseInBack();

        //Se escala la nueva cápsula
        LeanTween.scale(capsule, Vector3.one, 1f).setEaseOutBack();
    }

    //Cada Frame
    void Update()
    {
        //A timer se le resta valor en relación al tiempo
        timer -= Time.deltaTime;

        //Se le asigna de valor al slider el de timer
        sliderTimeLeft.value = timer;

        //Se le da al texto para que muestre el valor en pantalla
        timeText.text = timer.ToString("00.00");

        //Si el tiempo es menor a 10
        if (timer <= 5.0f)
        {
            //La cápsula es de color rojo
            capsule.gameObject.GetComponent<MeshRenderer>().material = red;
            //capsule.gameObject.LeanColor(Color.red, 0.5f).setEaseInBack();

        }

        //Si el tiempo es menor o igual a 0
        if (timer <= 0)
        {
            //Se llama a la funcíón:
            DestroyCapsule();

            //El slider y el texto se desactivan
            sliderTimeLeft.gameObject.SetActive(false);
            timeText.gameObject.SetActive(false);

            //Timer se convierte en 2 para no crear problemas
            timer = 2f;
        }
    }

    void DestroyCapsule()
    {
        //La cápsula se escala a 0
        LeanTween.scale(capsule, Vector3.zero, 1f).setEaseInBack().setOnComplete(DestroyCapsuleEnd);

        //Se instancian las partículas
        Instantiate(prefabParticles, capsule.transform.position, Quaternion.identity);
    }

    void DestroyCapsuleEnd()
    {
        //Buscamos en el otr script esta función:
        controller.GetComponent<CapsuleCreator>().CapsuleCreation();

        //Se destruye el objeto
        Destroy(capsule);
    }
}
