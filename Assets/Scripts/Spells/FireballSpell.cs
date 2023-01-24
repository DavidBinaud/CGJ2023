using UnityEngine;

public class FireballSpell : MonoBehaviour, ISpell 
{
    public GameObject prefab;
    
    public void Cast()
    {
        GameObject createdMissile = Instantiate(prefab);
        createdMissile.transform.position = PlayerController.Instance.transform.position;// + Vector3.forward * 100;
        Vector3 forward = PlayerController.Instance.transform.forward*1000;
        createdMissile.GetComponent<Rigidbody>().AddForce(createdMissile.transform.position + forward);

        Debug.Log("Fireball cast");
    }
}
