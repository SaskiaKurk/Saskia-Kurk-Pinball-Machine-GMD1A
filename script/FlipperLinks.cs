using UnityEngine;
using System.Collections;


public class FlipperLinks : MonoBehaviour
{
    public float maxAngle2 = -20.0f; //maximale hoek die gemaakt kan worden door de flipper
    public float flipTime = 0.1f; //snelheid waarme de flipper draait... hoe lager waarde hoe sneller
    public string buttonName = "Fire1"; //(mouse)button for activation flipper rotation
    public bool bol; //for activation flipper collision
    private Quaternion initialOrientation; //begin punt voordat de hoek gemaakt word
    private Quaternion finalOrientation; //de hoek die gemaakt word
    private float t; //rotatie op stilstaand moment van (draaiend) object
    public Vector3 direction; //directie voor collision
    public Rigidbody ball; //GameObject > bal
    public float force2 = -150; //snelheid waarmee bal wegschiet

    // Use this for initialization
    void Start()
    {
        initialOrientation = transform.rotation; //begin waarden van (rotation) object = begin initialOrientation
        finalOrientation.eulerAngles = new Vector3(initialOrientation.eulerAngles.x, initialOrientation.eulerAngles.y + maxAngle2, initialOrientation.eulerAngles.z); //eindwaarde van object na (beginwaarde rotatie x-as, beginwaarde rotatie y-as + maximale draaihoek[in dit geval nodig op y-as voor de juiste hoek kan verschillen bij andere projecten], beginwaarde rotatie z-as)

    }
    // Update is called once per frame
    void Update()
    {


        {
            if (Input.GetButton(buttonName))//buttonName1 = de knop die je indrukt
            {
                transform.rotation = Quaternion.Slerp(initialOrientation, finalOrientation, t / flipTime);//verandering rotatie object door middel van begin rotatie , eindrotatie, stilstaand punt en snelheid 
                t += Time.deltaTime; //stilstaand punt + snelheid van berekenen frames per sec
                if (t > flipTime) //als stilstaand punt groter is dan snelheid...
                {
                    t = flipTime;//stilstaand punt word veranderd naar eind punt
                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(initialOrientation, finalOrientation, t / flipTime);
                t -= Time.deltaTime;
                if (t < 0)//als stilstaand punt kleiner is dan 0....
                {
                    t = 0;//stilstaand punt is dan weer bij begin
                }
            }

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (Input.GetButton(buttonName))
        {
            bol = true;//als knop is ingedrukt bool zet collision op true
            direction = collision.contacts[0].point;//terugkaatsende richting tijdens collision veroorzaken
            ball.AddForce(direction * force2);//de snelheid waarme de bal terugkaatst
        }
    }
}