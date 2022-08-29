using Baracuda.Monitoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonitoredBehaviour
{
    // Start is called before the first frame update
    public GameObject placeholder;
    GameObject _placeholder;
    public float secondComplete = 5;
    float positionX;
    float positionY;
    [Monitor]
    float angle = 0;
    public float radius;
    public int numOfOrbit;
    public int maxNumOfOrbits;
    public int _MaxNumOfEntitiesInOrbits;
    GameObject[] EntityInOrbits;
    [Monitor]
    [SerializeField] private Dictionary<int, Orbit> OrbitToObject = new Dictionary<int, Orbit>();
    float speed;
    class Orbit
    {
        public int maxEntityCount;
        
        public int entityCount;
        
        public GameObject[] entities;
        
        public float[] anglesArr;
        public Orbit(int maxEntityCount)
        {
            this.maxEntityCount = maxEntityCount;
            this.entityCount = 0;
            this.entities = new GameObject[20]; // bad practice, Maybe change later?
            this.anglesArr = new float[20];
        }


        
    }


    void Start()
    {
        speed = (2 * Mathf.PI) / secondComplete;
        for (int i = 0; i < 2; i++)
        {
            AddToOrbit(i, Instantiate(placeholder, transform));
        }
    }
    public int CalculateOrbitNumber(float distance, GameObject entityToAdd)
    {
        

        return 0;
    }
    public void AddToOrbit(float distance, GameObject entityToAdd)
    {

    }
    public void RemoveFromOrbit(float distance, GameObject entityToRemove)
    {


    }

    // Update is called once per frame
    void Update()
    {



    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;

/*        for(int i = 0; i < 10; i++)
        {
            Gizmos.DrawWireSphere(transform.position, radius * i);
        }*/






    }
}
