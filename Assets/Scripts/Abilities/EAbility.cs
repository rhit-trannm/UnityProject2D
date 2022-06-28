using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAbility : MonoBehaviour
{
    public GameObject EAbilityHitbox;
    float speed = 1f;
    float angle = 0;
    float radius = 2f;
    float numberOfCubes = 1;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        float temp = 360 / numberOfCubes;
        for(int i = 0; i < numberOfCubes; i++)
        {
            float positionX = Mathf.Cos(temp*i) * radius;
            float positionY = Mathf.Sin(temp * i) * radius;
            //Instantiate()
        }
    }
    void Update()
    {
        angle += speed;
        float positionX = Mathf.Cos(angle) * radius;
    }
}
