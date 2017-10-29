using UnityEngine;

public class CoinScript : MonoBehaviour
{
    readonly float resetCoordinate_Z = -20.44f;

    readonly float rotateSpeed = 100f;

    readonly float speed = -5f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(
            this.transform.InverseTransformDirection(Vector3.forward) * this.speed * Time.deltaTime);

        if (this.transform.position.z < this.resetCoordinate_Z)
        {
            this.gameObject.SetActive(false);
        }

        //6. Направете монетите да се въртят около оста си.
        this.transform.Rotate(0f, 0f, this.rotateSpeed * Time.deltaTime);
    }
}