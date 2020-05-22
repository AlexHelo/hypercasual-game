using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    //Declare variables
    public GameObject Food;
    public float Speed;

    //Called when the game begins
    void Start()
    {
        //Call the function over and over again
        InvokeRepeating("Generate", 0, Speed);
    }

    //This function creates a new food bit
    void Generate()
    {
        //Generate random x and y pixel positions
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        //Turn into word space
        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        //Create food object from prefab
        Instantiate(Food, Target, Quaternion.identity);
    }
}