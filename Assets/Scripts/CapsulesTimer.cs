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

    [Header("PARTICLE SYSTEM")]
        [SerializeField]
        GameObject prefabParticles;
        [SerializeField]
        GameObject prefabParticles2;

    //Al iniciar el script
    private void OnEnable()
    {
        //Se da valor a timer entre dos n�meros aleatorios
        timer = Random.Range(timeMin, timeMax);

        //Se le asigna el valor m�ximo del slider el valor de timer
        sliderTimeLeft.maxValue = timer;

        //Se activan los elementos en caso de no estarlo (los nuevos)
        sliderTimeLeft.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        capsule.gameObject.SetActive(true);

        //Se escala la nueva c�psula
        LeanTween.scale(capsule, Vector3.one, 1f).setEaseOutBack();
    }

    //Cada Frame
    void Update()
    {
        //A timer se le resta valor en relaci�n al tiempo
        timer -= Time.deltaTime;

        //Se le asigna de valor al slider el de timer
        sliderTimeLeft.value = timer;

        //Se le da al texto para que muestre el valor en pantalla
        timeText.text = timer.ToString("00.00");

        //Si el tiempo es menor o igual a 0
        if (timer <= 0)
        {
            //Se llama a la func��n:
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
        //La c�psula se escala a 0
        LeanTween.scale(capsule, Vector3.zero, 1f).setEaseInBack().setOnComplete(DestroyCapsuleEnd);

        //Se instancian las part�culas
        Instantiate(prefabParticles, capsule.transform.position, Quaternion.identity);
    }

    void DestroyCapsuleEnd()
    {
        //Se instancia la nueva capsula en la posici�n de la anterior
        Instantiate(capsule, capsule.transform.position, Quaternion.identity);

        //Se instancian las nuevas part�culas
        Instantiate(prefabParticles2, capsule.transform.position, Quaternion.identity);

        //Se destruye el objeto
        Destroy(capsule);
    }
}
