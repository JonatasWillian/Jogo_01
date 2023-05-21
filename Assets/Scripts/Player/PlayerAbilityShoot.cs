using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    //public List<UIGunUpdater> uIGunUpdaters;

    [Header("Gun")]
    public GunBase gunBase;
    public GunBase gunShootBase;
    public GunBase gunShootLimit;
    public GunBase gunShootAngle;

    [Header("Color")]
    public FlashColor _flashColor;

    [Header("Position")]
    public Transform gunPosition;

    private GunBase _currentGun;
    private GunBase _gunShootBaseInstance;
    private GunBase _gunShootLimitInstance;
    private GunBase _gunShootAngleInstance;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CanceledShoot();
        inputs.Gameplay.AbilityShoot_1.performed += ctx => GunShootLimit();
        inputs.Gameplay.AbilityShoot_2.performed += ctx => GunShootAngle();
        inputs.Gameplay.AbilityShoot_3.performed += ctx => GunShootBase();
    }

    private void CreateGun()
    {
        _currentGun = Instantiate(gunBase, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;

        _gunShootBaseInstance =Instantiate(gunShootBase, gunPosition);
        _gunShootBaseInstance.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        _gunShootBaseInstance.gameObject.SetActive(false);

        _gunShootLimitInstance = Instantiate(gunShootLimit, gunPosition);
        _gunShootLimitInstance.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        _gunShootLimitInstance.gameObject.SetActive(false);

        _gunShootAngleInstance = Instantiate(gunShootAngle, gunPosition);
        _gunShootAngleInstance.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        _gunShootAngleInstance.gameObject.SetActive(false);
    }

    #region INSTATIATE_GUN
    private void GunShootBase()
    {
        _currentGun.gameObject.SetActive(false);
        _currentGun = _gunShootBaseInstance;
        _currentGun.gameObject.SetActive(true);
    }

    private void GunShootLimit()
    {
        _currentGun.gameObject.SetActive(false);
        _currentGun = _gunShootLimitInstance;
        _currentGun.gameObject.SetActive(true);
    }

    private void GunShootAngle()
    {
        _currentGun.gameObject.SetActive(false);
        _currentGun = _gunShootAngleInstance;
        _currentGun.gameObject.SetActive(true);
    }
    #endregion

    private void StartShoot()
    {
        _currentGun.StartShoot();
        _flashColor?.Flash();
    }

    private void CanceledShoot()
    {
        _currentGun.StopShoot();
    }
}
