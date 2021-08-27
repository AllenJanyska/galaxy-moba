using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoBase : MonoBehaviour
{


    [SerializeField] private float baseDamage;

    // Start is called before the first frame update
    void Start(float _damage)
    {
        baseDamage = _damage;
        StartCoroutine("lifeTimer");
    }

    protected void setDamage(float newVal)
    {
        baseDamage = newVal;
    }

    public float getDamage()
    {
        return baseDamage;
    }

    private IEnumerator lifeTimer()
    {
        yield return new WaitForSeconds(5.0f); // wait 5 seconds
        Destroy(gameObject);
    }


}
