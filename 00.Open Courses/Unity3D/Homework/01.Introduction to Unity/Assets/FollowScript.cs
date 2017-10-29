using UnityEngine;

namespace Assets
{
    public class FollowScript : MonoBehaviour
    {
        public Transform Sphere;
        public float FollowSpeed;
        public float MinDistance;


        // Update is called once per frame
        void LateUpdate()
        {
            if (this.Sphere != null)
            {
                this.transform.LookAt(this.Sphere);

                if (Vector3.Distance(this.transform.position, this.Sphere.position) > this.MinDistance)
                {
                    this.transform.Translate(0f, 0f, this.FollowSpeed * Time.deltaTime);
                }
            }

        }
    }
}