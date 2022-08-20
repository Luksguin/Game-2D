using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectilleBase projectillePrefab;
    public Transform positionShoot;
    public Transform playerSide;
    public float timeShoot;

    private Coroutine _currentCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeShoot);
        }
    }

    public void Shoot()
    {
        var projectille = Instantiate(projectillePrefab);
        projectille.side = playerSide.transform.localScale.x;
        projectille.transform.position = positionShoot.transform.position;
    }
}
