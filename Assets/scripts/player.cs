using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D rb;
    public int curHealth;
    public int maxHealth = 100;
    private gameMaster gm;
	void Start () {


        curHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {
            Die();
        }
	}
    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       if(col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
        }
    }
    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        while ( knockDur > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockbackDir.x * 100, knockbackDir.y * knockPwr, transform.position.z));
        }
        yield return 0;
    }
}
