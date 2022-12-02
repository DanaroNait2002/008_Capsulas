using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CapsuleCreator : MonoBehaviour
{
    [Header("GAMEOBJECTS")]
        [SerializeField]
        GameObject capsule;

    [Header("PARTICLESSYSTEM")]
    [SerializeField]
    GameObject prefabParticles;

    Vector3 pos;

    public void CapsuleCreation()
    {
        pos = new Vector3(Random.Range(-8, 8), 1.2f, Random.Range(-8, 8));

        //Se instancia la nueva capsula en la posición de la anterior
        Instantiate(capsule, pos, Quaternion.identity);

        //Se instancian las nuevas partículas
        Instantiate(prefabParticles, capsule.transform.position, Quaternion.identity);
    }
}
