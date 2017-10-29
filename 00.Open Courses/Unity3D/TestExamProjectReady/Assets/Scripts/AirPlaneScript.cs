using UnityEngine;

public class AirPlaneScript : MonoBehaviour
{
    AudioSource attachedAudioSource;

    Rigidbody attachedRigidbody;

    float gameTime;

    public GuiManager guiManager;

    public bool isAlive;

    float moveSpeed = 0.05f;

    Camera planeCamera;

    readonly float planeReturnDampTime = 0.2f;

    float planeReturnRotationSpeed;

    readonly float planeRotateTime = 1f;

    //for 5th task
    Transform rotor;

    readonly float rotorSpeed = 1000f;

    public int score;

    float xMax = 7.77f;

    float xMin = 0.88f;

    readonly float yCoordinate = 4.43f;

    readonly float zMax = 5f;

    readonly float zMin = -1.8f;

    // Use this for initialization
    void Start()
    {
        this.isAlive = true;
        this.score = PlayerPrefs.GetInt("Score", 0);
        this.guiManager.scoreLbl.text = string.Format("Score : {0}", this.score);
        this.planeCamera = Camera.main;
        this.rotor = this.transform.FindChild("Rotor");
        this.gameTime = 0f;
        this.attachedAudioSource = this.GetComponent<AudioSource>();
        this.attachedRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isAlive)
        {
            this.ManageInput();
            this.ManageLimitations();

            //5. Направете ротора на самолета да се върти като използвате float rotorSpeed = 1000f; 
            //намиращ се в AirPlaneScript. (Кодът е препоръчително, но не задължително, да е към AirPlaneScript)
            this.rotor.Rotate(0f, 0f, this.rotorSpeed * Time.deltaTime);

            //8. Направете така, че на всеки 60 секунди игра управлението 
            //(от точка 4) на самолета да става малко по чувствително.
            this.ManageSensitivity();
        }
    }
   
    void ManageInput()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //4. В AirPlaneScript в метода ManageInput добавете код, 
        //с който самолета да се движи напред/назад и наляво/надясно 
        //посредством клавиатурата(стрелките и WASD)
        this.transform.position += new Vector3(horizontalAxis * this.moveSpeed, 0f, verticalAxis * this.moveSpeed);

        if (horizontalAxis > 0f)
        {
            this.transform.rotation = Quaternion.Euler(
                0f,
                0f,
                Mathf.SmoothDampAngle(
                    this.transform.rotation.eulerAngles.z,
                    -90f,
                    ref this.planeReturnRotationSpeed,
                    this.planeRotateTime));
        }
        else if (horizontalAxis < 0f)
        {
            this.transform.rotation = Quaternion.Euler(
                0f,
                0f,
                Mathf.SmoothDampAngle(
                    this.transform.rotation.eulerAngles.z,
                    90f,
                    ref this.planeReturnRotationSpeed,
                    this.planeRotateTime));
        }
        else if (this.transform.rotation.eulerAngles != Vector3.zero)
        {
            this.transform.rotation = Quaternion.Euler(
                0f,
                0f,
                Mathf.SmoothDampAngle(
                    this.transform.rotation.eulerAngles.z,
                    0f,
                    ref this.planeReturnRotationSpeed,
                    this.planeReturnDampTime));
        }
    }

    void ManageLimitations()
    {
        float planeToViewPort_Y = this.planeCamera.WorldToViewportPoint(this.transform.position).y;
        float zDistance = Mathf.Abs((this.planeCamera.transform.position - this.transform.position).z);
        this.xMin = this.planeCamera.ViewportToWorldPoint(new Vector3(0f, planeToViewPort_Y, zDistance)).x;
        this.xMax = this.planeCamera.ViewportToWorldPoint(new Vector3(1f, planeToViewPort_Y, zDistance)).x;
        this.transform.position = new Vector3(
            Mathf.Clamp(this.transform.position.x, this.xMin, this.xMax),
            this.yCoordinate,
            Mathf.Clamp(this.transform.position.z, this.zMin, this.zMax));
    }

    void ManageSensitivity()
    {
        if (Time.timeSinceLevelLoad > (this.gameTime + 15))
        {
            this.gameTime += 15;
            this.moveSpeed += 0.01f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            this.CrashPlane();
        }
        else if (col.tag == "Coin" || col.tag == "GreenCoin")
        {
            col.gameObject.SetActive(false);

            //1. Направете така, че да се добавя по една точка (Score в горния ляв ъгъл) при колизия с монета.  
            //9. Добавете втори тип монета, която да е зелена и механизма на работа и на генериране да е идентичен 
            //като на жълтите монети, но зелените монети да носят 2 точки.       
            this.score += col.tag == "Coin" ? 1 : 2;

            //12. Добавете звук при вземане на монета от двата типа. Звукът е Sounds/CollectCoin.wav.
            this.attachedAudioSource.Play();
            this.guiManager.scoreLbl.text = string.Format("Score : {0}", this.score);

            //При всяко добавяне трябва да се запазват точките така, че след рестарт на играта да се пазят.
            PlayerPrefs.SetInt("Score", this.score);
        }
    }

    void CrashPlane()
    {
        this.isAlive = false;
        this.attachedRigidbody.isKinematic = false;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }

        this.guiManager.ShowDeadText();
    }
}