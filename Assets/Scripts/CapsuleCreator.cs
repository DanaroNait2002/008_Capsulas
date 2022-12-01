using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CapsuleCreator : MonoBehaviour
{
    [SerializeField]
    float timer;

    [SerializeField]
    float timeMax = 10f;

    [SerializeField]
    float timeMin = 5f;

    [SerializeField]
    GameObject capsule;

    private void OnEnabled()
    {
        timer = Random.Range(timeMin, timeMax);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            CreateCapsule();
        }
    }

    public void CreateCapsule()
    {
        Instantiate(capsule, capsule.transform.position, Quaternion.identity);
    }
}
