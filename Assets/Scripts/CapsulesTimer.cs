using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsulesTimer : MonoBehaviour
{
    [SerializeField]
    float timer;

    [SerializeField]
    float timeMin = 10f;

    [SerializeField]
    float timeMax = 30f;

    [SerializeField]
    Slider sliderTimeLeft;

    [SerializeField]
    GameObject capsule;

    [SerializeField]
    GameObject controller;

    [SerializeField]
    GameObject prefabParticles;

    void Start()
    {
        timer = Random.Range(timeMin, timeMax);

        sliderTimeLeft.maxValue = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        sliderTimeLeft.value = timer;

        if (timer <= 0)
        {
            //timer = Random.Range(timeMin, timeMax);
            DestroyCapsule();
        }
    }

    void DestroyCapsule()
    {
        Destroy(gameObject);

        Instantiate(prefabParticles, capsule.transform.position, Quaternion.identity);

        Instantiate(capsule, capsule.transform.position, Quaternion.identity);

        /*CapsuleCreator capsuleCreator = controller.GetComponent<CapsuleCreator>();
        capsuleCreator.CreateCapsule();*/
    }

    
}
