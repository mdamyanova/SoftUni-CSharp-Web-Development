using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    //Допълнете скрипта, по следния начин:
    //С левия бутон на мишката трябва да стреля
    //Трябва да има два режима на стрелба, които се сменят с клавиши 1 и 2 Keycode.Alpha1/Keycode.Alpha2
    //Режим 1 прави "дупка в стената" като просто инстанцира bulletholepfb и го слага в точката на удара (raycast) и му прави ротацията като на уцеления обект
    //Режим 2 инстанцира bulletPfb и го изтрелва от позиция/ротация newBulletPosition чрез rigibody.AddRelativeForce

    public GameObject bulletHolePfb;

    public GameObject bulletPfb;

    bool isInBulletHoleMode;

    public GameObject newBulletPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.isInBulletHoleMode = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.isInBulletHoleMode = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (this.isInBulletHoleMode)
            {
                GameObject newBullet = Instantiate(this.bulletPfb);
                newBullet.gameObject.SetActive(true);
                newBullet.transform.position = this.newBulletPosition.transform.position;
                newBullet.transform.rotation = this.newBulletPosition.transform.rotation;
                newBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, 50f), ForceMode.Impulse);
            }
            else
            {
                Ray ray = Camera.main.ViewportPointToRay(Vector2.one * 0.5f);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 50f))
                {
                    Debug.Log("hit : " + hit.collider.name);
                    GameObject newBullet = Instantiate(this.bulletHolePfb);
                    newBullet.gameObject.SetActive(true);
                    newBullet.transform.position = hit.point - newBullet.transform.forward * 0.5f;
                    newBullet.transform.rotation = hit.collider.transform.rotation;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.005f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}