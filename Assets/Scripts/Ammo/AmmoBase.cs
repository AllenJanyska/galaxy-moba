using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoBase : MonoBehaviour
{


    private AudioSource _audioSource;
    [SerializeField] private float baseDamage;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.Play();
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
