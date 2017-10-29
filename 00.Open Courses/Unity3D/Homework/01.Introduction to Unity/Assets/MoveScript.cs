using UnityEngine;

namespace Assets
{
    public class MoveScript : MonoBehaviour
    {

        public Transform Cube;

        public float Speed;

        void Awake()
        {
            Debug.Log("Awake");
        }

        // Use this for initialization
        void Start ()
        {
            Debug.Log("Start");
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(0f, 0f, this.Speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(0f, 0f, this.Speed * -1 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(this.Speed * -1 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(this.Speed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
