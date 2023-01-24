using UnityEngine;

public class FireballSpell : MonoBehaviour, ISpell 
{
    public GameObject prefab;
    
    public void Cast()
    {
        GameObject createdMissile = Instantiate(prefab);
        createdMissile.transform.position = PlayerController.Instance.transform.position;
        //prefab.transform and push it
        //createdMissile.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //createdMissile.transform.forward = 
        Debug.Log("Fireball cast");
    }
}
