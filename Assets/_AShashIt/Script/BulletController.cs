using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  public int damage = 1;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void SetDirection(Vector3 dir, float speed)
  {
    GetComponent<Rigidbody2D>().velocity = dir * speed;
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    //if touch player deal damage
    if (other.gameObject.tag == "Player")
    {
      var character = other.gameObject.GetComponent<CharacterSlash>();
      if (character.isSlashing == false) character.TakeDamage(damage);
      Destroy(gameObject);
    }
    if (other.gameObject.tag.Contains("wall"))
    {
      Destroy(gameObject);
    }
  }

}
