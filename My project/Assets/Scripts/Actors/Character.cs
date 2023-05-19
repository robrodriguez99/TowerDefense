using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Weapon
{
    LaserPistol = 0,
    Shotgun = 1
}
[RequireComponent(typeof(CharacterController))]
public class Character : Actor
{

    [SerializeField] private List<Gun> _availableWeapons;
    [SerializeField] private Gun _currentWeapon;

    private MovementController _movementController;

    private TransactionController _transactionController;

    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject NoMoneyMessage;

    [SerializeField] private Transform camera;

    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBackwards;
    private CmdRotation _cmdRotateLeft;
    private CmdRotation _cmdRotateRight;


    private CmdAttack _cmdAttack;
    private CmdReload _cmdReload;

    private bool _isBuildableSpot = false;

    // Start is called before the first frame update
     protected override void Start()
    {
        base.Start();

        _movementController = GetComponent<MovementController>();
        _transactionController = GetComponent<TransactionController>();
        EquipWeapon(Weapon.LaserPistol);
        InitializeCommands();
        
        
        if (_transactionController == null)
        {
            Debug.LogError("TransactionController component not found on " + gameObject.name);
        }

        EventManager.instance.onRewardEarned += OnRewardEarned;
        EventManager.instance.onEnemySuccess += OnEnemySuccess;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            // Access the object that was hit
            GameObject objectHit = hit.transform.gameObject;
            _isBuildableSpot = objectHit.tag == "Platform" ? true : false;
        }

        //Move fwd and bkw
        if (Input.GetKey(KeyCode.W)) _cmdMoveForward.Execute();
        if (Input.GetKey(KeyCode.S)) _cmdMoveBackwards.Execute();

        if (Input.GetKey(KeyCode.A)) _cmdRotateLeft.Execute();
        if (Input.GetKey(KeyCode.D)) _cmdRotateRight.Execute();

        if (Input.GetAxis("Fire1") > 0) _cmdAttack.Execute();
        if (Input.GetKeyDown(KeyCode.R)) _cmdReload.Execute();

        //Equipar arma
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(Weapon.LaserPistol);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(Weapon.Shotgun);

        if(Input.GetKeyDown(KeyCode.O) && _isBuildableSpot)
        {
            if (_transactionController.Gold < 10)
                EnableNoMoneyMessage();
            else
            {
                _transactionController.Buy(10);
                Node node = hit.transform.gameObject.GetComponent<Node>();
                node?.BuildTurret();
            }
        }

         // Pause game
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
            else if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // This "pauses" the game by making everything happen at "0 speed"
        pauseMenu.SetActive(true);

        // Make the mouse cursor visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // this line will unlock the cursor if it was locked.
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // This makes the game run at normal speed again
        pauseMenu.SetActive(false);

        // Hide the mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // this line will lock the cursor again when the game is unpaused.
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Ensure that the game is unpaused when you go back to the Main Menu
        SceneManager.LoadScene(UnityScenes.MainMenu.ToString());
    }

    public void EnableNoMoneyMessage()
    {
        //we set it active for 3 seconds
        NoMoneyMessage.SetActive(true);
        Invoke("DisableNoMoneyMessage", 3f);
    
    }

    public void DisableNoMoneyMessage()
    {
        NoMoneyMessage.SetActive(false);
    }

    private void EquipWeapon(Weapon weaponIdx)
    {
        foreach (Gun gun in _availableWeapons)
        {
            gun.gameObject.SetActive(false);
        }

        _currentWeapon = _availableWeapons[(int) weaponIdx];
        _currentWeapon.gameObject.SetActive(true);
        _cmdAttack = new CmdAttack(_currentWeapon);
        _cmdReload = new CmdReload(_currentWeapon);

        EventManager.instance.ActionWeaponChange((int) weaponIdx);
        EventManager.instance.ActionAmmoChange(_currentWeapon.CurrentBulletCount, _currentWeapon.MagSize);
    }

    private void OnRewardEarned(int amount)
    {
        _transactionController.Earn(amount);
    }

    private void OnEnemySuccess(int damage) => lifeController.TakeDamage(damage);

    private void InitializeCommands()
    {
        _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
        _cmdMoveBackwards = new CmdMovement(_movementController, Vector3.back);
        _cmdRotateLeft = new CmdRotation(_movementController, -Vector3.up);
        _cmdRotateRight = new CmdRotation(_movementController, Vector3.up);
        _cmdAttack = new CmdAttack(_currentWeapon);
        _cmdReload = new CmdReload(_currentWeapon);
    }

}
