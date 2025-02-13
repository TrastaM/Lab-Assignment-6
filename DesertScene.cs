using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{

    public float xAngle, yAngle, zAngle;

    private GameObject cube1, cube2, plane1;

    public Transform target;

    public int layers = 5;
    private float spacing = 1.1f;

    private Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.cyan, Color.yellow, Color.magenta, Color.black };

    // Start is called before the first frame update
    void Start()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.localScale *= 2;
        
        createPyramid();

        createForest();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createPyramid()
    {
        int currentLayer = 5;

        for (int i = layers; i > 0; i--)
        {
            for (int y = 0; y < currentLayer; y++)
            {

                for (int x = 0; x < currentLayer; x++)
                {
                    Vector3 pos = new Vector3((x * spacing) + 5 - (currentLayer * 0.5f), 5.5f - currentLayer, (y * spacing) + 5 - (currentLayer * 0.5f));
                    GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    temp.transform.position = pos;

                    var mat = temp.GetComponent<Renderer>().material;
                    int ix = UnityEngine.Random.Range(0, colors.Length);
                    mat.color = colors[ix];
                }

            }
            currentLayer--;
        }
    }

    void createForest()
    {
        // random number of objects 8-15 DONE
        // random scale on each identifier from 0.5 - 2 DONE
        // random location within bounds of (-1, -1) to (-4, -4) DONE
        // random shade of green


        int numOfTrees = Random.Range(15, 22);

        for(int i = 0; i < numOfTrees; i++)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
           
            temp.transform.localScale = new Vector3(Random.Range(0.5f, 2f), Random.Range(0.5f, 2f), Random.Range(0.5f, 2f));

            temp.transform.position = new Vector3(Random.Range(-1f, -8f), 0.5f, Random.Range(-1f, -8f));

            var mat = temp.GetComponent<Renderer>().material;
            float randGreen = UnityEngine.Random.Range(0.5f, 1f);
            Color temp2 = new Color(0, randGreen, 0, 0.5f);
            mat.color = temp2;
        }
    }
}
