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
        /*        positionX = (Mathf.Cos(angle) * radius) + gameObject.transform.position.x;
                positionY = (Mathf.Sin(angle) * radius) + gameObject.transform.position.y;

                for (int i = 0; i < numOfOrbit; i++)
                {
                    Orbit temp = OrbitToObject[i];


                }*/
        for(int i = 0; i< maxNumOfOrbits; i++)
        {
            OrbitToObject.Add(i, new Orbit(4));
        }
        positionX = (Mathf.Cos(angle) * radius) + gameObject.transform.position.x;
        positionY = (Mathf.Sin(angle) * radius) + gameObject.transform.position.y;



        Orbit tempOrbit = OrbitToObject[0];
        //_placeholder = Instantiate(placeholder, new Vector3(positionX, positionY, 0), Quaternion.identity) as GameObject;
        tempOrbit.entityCount = 4;
        //AddToOrbit(0, Instantiate(placeholder, new Vector3(positionX, positionY, 0), Quaternion.identity) as GameObject);
        tempOrbit.entities[0] = Instantiate(placeholder, new Vector3(positionX, positionY, 0), Quaternion.identity);
        tempOrbit.entities[1] = Instantiate(placeholder, new Vector3(positionX, positionY, 0), Quaternion.identity);
        tempOrbit.entities[2] = Instantiate(placeholder, new Vector3(positionX, positionY, 0), Quaternion.identity);
        tempOrbit.entities[3] = Instantiate(placeholder, new Vector3(positionX, positionY, 0), Quaternion.identity);
        Refresh();
        Debug.Log(tempOrbit.entityCount);
    }
    public void Refresh()
    {

        Orbit tempOrbit = OrbitToObject[0];
        float fullcircle = 2.0f * 3.141f;
        float angleBetweenGO = fullcircle / tempOrbit.entityCount;

        for (int i = 0; i < tempOrbit.entityCount; i++)
        {
            tempOrbit.anglesArr[i] = i * angleBetweenGO;
        }
    }
    public void AddToOrbit(float distance, GameObject entityToAdd)
    {
        float RingNumber;

        float temp =  radius * numOfOrbit;

        RingNumber = Mathf.Floor(temp - distance)/temp;
        if(RingNumber <= 1)
        {
            RingNumber = 0;
        }
        Orbit tempOrbit = OrbitToObject[(int)RingNumber];
        tempOrbit.entities[tempOrbit.entityCount] = entityToAdd;
        tempOrbit.entityCount += 1;


        float fullcircle = 2.0f * 3.141f;
        float angleBetweenGO = fullcircle/tempOrbit.entityCount;

        for(int i = 0; i< tempOrbit.entityCount; i++)
        {
            tempOrbit.anglesArr[i] = i * angleBetweenGO;
        }

    }

    // Update is called once per frame
    void Update()
    {
        speed = (2 * Mathf.PI) / secondComplete;
        

        for (int i = 0; i < numOfOrbit; i++)
        {
            Orbit temp = OrbitToObject[i];
            int numOfItems = temp.entityCount;

            
            for (int j = 0; j < numOfItems; j++)
            {
                GameObject s = temp.entities[j];
                angle = temp.anglesArr[j];
                angle += speed * Time.deltaTime;
                temp.anglesArr[j] = angle;

                Debug.Log(s.name);

                var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;

                s.transform.position = gameObject.transform.position + (Vector3)offset;
                /*positionX = (Mathf.Cos(angle + ((2 * Mathf.PI) / (j + 1))) * radius) + gameObject.transform.position.x;
                positionY = (Mathf.Sin(angle + ((2 * Mathf.PI) / (j + 1))) * radius) + gameObject.transform.position.y;
                s.transform.position = new Vector3(positionX, positionY, 0);*/
            }

        }
/*        Orbit temp = OrbitToObject[0];
        GameObject s = temp.entities[0];

        Debug.Log(s.name);

        positionX = (Mathf.Cos(angle) * radius) + gameObject.transform.position.x;
        positionY = (Mathf.Sin(angle) * radius) + gameObject.transform.position.y;

        s.transform.position = new Vector3(positionX, positionY, 0);*/
        /*        positionX = (Mathf.Cos(angle) * radius) + gameObject.transform.position.x;
                positionY = (Mathf.Sin(angle) * radius) + gameObject.transform.position.y;
                _placeholder.transform.position = new Vector3(positionX, positionY, 0);*/






    }
}
