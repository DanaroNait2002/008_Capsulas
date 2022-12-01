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
    GameObject Capsule;

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
            Destroy(gameObject);

            NewCapsule();
        }
    }

    void NewCapsule()
    {
        Instantiate(Capsule);
    }
}
