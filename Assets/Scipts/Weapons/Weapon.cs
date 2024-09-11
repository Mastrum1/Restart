using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    private bool _shootReady = true;
    private int index = 0;

    [SerializeField] PlayerController _playerController;
    [SerializeField] private GameObject Player; 
    [SerializeField] protected string name = "";
    [SerializeField] protected float cooldown = 1;
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected Projectile projectileScript;
    [SerializeField] private GunCD _gunCD;

    [SerializeField] GameObject[] _bulletPool;
    [SerializeField] int _maxBulletCount;
    
    public bool ShootReady
    {
        get => _shootReady;
        set => _shootReady = value;
    }

    public float Cooldown
    {
        get => cooldown;
        set => cooldown = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        _playerController.Fire.AddListener(Shoot);
        
        _maxBulletCount = (int)projectileScript.LifeTime / (int)cooldown + 1;
        _bulletPool = new GameObject[_maxBulletCount];
        for (int i = 0; i < _maxBulletCount; i++)
        {
            _bulletPool[i] = Instantiate(projectile, gameObject.transform);
            _bulletPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Shoot()
    {
        if (_shootReady)
        {
            StartCoroutine(ShootCooldown());
            //Write here in Override projectile weapon logic
            GameObject actualBullet = _bulletPool[index];
            actualBullet.transform.position = Player.transform.position;
            actualBullet.transform.rotation = Player.transform.rotation; 
            actualBullet.SetActive(true);
            actualBullet.GetComponent<Projectile>().Lunch();
            if (index == _maxBulletCount-1)
                index = 0;
            else index++;
        }
    }

    IEnumerator ShootCooldown()
    {
        _shootReady = false;
        //_gunCD.CDPanel();
        yield return new WaitForSeconds(cooldown);
        _shootReady = true; 
    }
}
