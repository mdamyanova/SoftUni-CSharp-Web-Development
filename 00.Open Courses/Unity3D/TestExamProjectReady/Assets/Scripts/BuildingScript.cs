using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    //for 11th task
    AirPlaneScript airPlaneScript;

    readonly float resetCoordinate_Z = -20.44f;

    readonly float resetDistance = 202f;

    public float speed = -5f;

    void Awake()
    {
        this.airPlaneScript = GameObject.Find("AirPlane").GetComponent<AirPlaneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //11. Направете когато умреш да спират да се движат сградите.
        if (this.airPlaneScript.isAlive)
        {
            this.transform.Translate(
                this.transform.InverseTransformDirection(Vector3.forward) * this.speed * Time.deltaTime);
            if (this.transform.position.z <= this.resetCoordinate_Z)
            {
                this.transform.Translate(this.transform.InverseTransformDirection(Vector3.forward) * this.resetDistance);
            }
        }
    }
}