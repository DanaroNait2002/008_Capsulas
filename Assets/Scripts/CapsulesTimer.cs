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

    [SerializeField]
    StateManager currentState = StateManager.Waiting;

    public enum StateManager
    {
        Waiting,
        TimerOn,
        TimerOff,
        Destroy,
        Creating,
    }

    void Start()
    {
        timer = Random.Range(timeMin, timeMax);

        sliderTimeLeft.maxValue = timer;

        currentState = StateManager.TimerOn;
    }

    void Update()
    {
        switch (currentState)
        {
            case StateManager.TimerOff:
                DestroyCapsule();
                break;

            case StateManager.Destroy:
                currentState = StateManager.Waiting;
                break;

            case StateManager.Waiting:
                currentState = StateManager.Creating;
                break;

            case StateManager.Creating:
                CreateNewCapsule();
                break;
        }

        timer -= Time.deltaTime;

        sliderTimeLeft.value = timer;

        if (timer <= 0)
        {
            //timer = Random.Range(timeMin, timeMax);
            currentState = StateManager.TimerOff;
        }
    }

    void DestroyCapsule()
    {
        Destroy(gameObject);
        currentState = StateManager.Destroy;
    }

    void CreateNewCapsule()
    {
        Instantiate(prefabParticles, capsule.transform.position, Quaternion.identity);



        //Instantiate(capsule, capsule.transform.position, Quaternion.identity);

        /*CapsuleCreator capsuleCreator = controller.GetComponent<CapsuleCreator>();
        capsuleCreator.CreateCapsule();*/
    }
}
