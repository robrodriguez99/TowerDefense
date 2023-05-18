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
public class Character : Actor, IMovable, IRotable
{

    [SerializeField] private List<Gun> _availableWeapons;
    [SerializeField] private Gun _currentWeapon;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField] private float _rotationSpeed = 15f;
    public float MovementSpeed =>  _movementSpeed;
    [SerializeField] private float _movementSpeed = 5f;
    private CharacterController _characterController;
    [SerializeField] public GameObject pauseMenu;

    Vector2 turn;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 displacement = transform.forward * direction.z * _movementSpeed * Time.deltaTime;
        _characterController.Move(displacement);
    }

    public void Rotation(Vector3 direction)
    {
        transform.Rotate(direction * _rotationSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        EquipWeapon(Weapon.LaserPistol);
    }

    // Update is called once per frame
    void Update()
    {

        //Move fwd and bkw
        Move(new Vector3(0, 0, Input.GetAxis("Vertical")));


        if (Input.GetAxis("Fire1") > 0) _currentWeapon.Attack();
        if (Input.GetKeyDown(KeyCode.R)) _currentWeapon.Reload();

        //Equipar arma
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(Weapon.LaserPistol);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(Weapon.Shotgun);

        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 20 * Time.deltaTime);


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

    private void EquipWeapon(Weapon weaponIdx)
    {
        foreach (Gun gun in _availableWeapons)
        {
            gun.gameObject.SetActive(false);
        }

        _currentWeapon = _availableWeapons[(int) weaponIdx];
        _currentWeapon.gameObject.SetActive(true);
    }

}
