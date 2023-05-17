using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    Pistol = 0,
    Shotgun = 1
}

public class Character : MonoBehaviour, IMovable, IRotable
{

    [SerializeField] private List<Gun> _availableWeapons;
    [SerializeField] private Gun _currentWeapon;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField] private float _rotationSpeed = 15f;
    public float MovementSpeed =>  _movementSpeed;
    [SerializeField] private float _movementSpeed = 5f;
    private CharacterController _characterController;

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
        EquipWeapon(Weapon.Pistol);
    }

    // Update is called once per frame
    void Update()
    {
        //Move fwd and bkw
        Move(new Vector3(0, 0, Input.GetAxis("Vertical")));
        Rotation(Vector3.up * Input.GetAxis("Horizontal"));


        if (Input.GetAxis("Fire1") > 0) _currentWeapon.Attack();
        if (Input.GetKeyDown(KeyCode.R)) _currentWeapon.Reload();

        //Equipar arma
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(Weapon.Pistol);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(Weapon.Shotgun);



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
