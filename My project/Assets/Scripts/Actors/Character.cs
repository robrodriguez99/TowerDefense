using System.Collections;
using System.Collections.Generic;
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

    private CharacterController _characterController;
    [SerializeField] public GameObject pauseMenu;//
    [SerializeField] public GameObject NoMoneyMessage;

    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBackwards;
    private CmdRotation _cmdRotateLeft;
    private CmdRotation _cmdRotateRight;


    private CmdAttack _cmdAttack;
    private CmdReload _cmdReload;

    // Start is called before the first frame update
     protected override void Start()
    {
        base.Start();
        _movementController = GetComponent<MovementController>();
        _characterController = GetComponent<CharacterController>();
        _transactionController = GetComponent<TransactionController>();
        EquipWeapon(Weapon.LaserPistol);
        Debug.Log("Movement Controller: " + _movementController);
        _cmdMoveForward = new CmdMovement(_movementController, Vector3.forward);
        _cmdMoveBackwards = new CmdMovement(_movementController, Vector3.back);
        _cmdRotateLeft = new CmdRotation(_movementController, -Vector3.up);
        _cmdRotateRight = new CmdRotation(_movementController, Vector3.up);
        _cmdAttack = new CmdAttack(_currentWeapon);
        _cmdReload = new CmdReload(_currentWeapon);
        
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

        if (Input.GetKeyDown(KeyCode.F2)) GetComponent<LifeController>().TakeDamage(10);

        //TODO: REMOVE THIS
        if (Input.GetKeyDown(KeyCode.F1)) {

            _transactionController.Buy(10);
            EventManager.instance.ActionGoldChange(_transactionController.Gold);

        }

        if (Input.GetKeyDown(KeyCode.F3)) {
            //TODO: REMOVE THIS
            //we set the no more money message
            EnableNoMoneyMessage();
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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // This makes the game run at normal speed again
        pauseMenu.SetActive(false);
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
        EventManager.instance.ActionGoldChange(_transactionController.Gold);

    }

    private void OnEnemySuccess(int damage) => _lifeController.TakeDamage(damage);

}
