using UnityEngine;

public class FireballSpell : ISpell
{
    public static GameObject Prefab;
    
    public static void Cast()
    {
        var createdMissile = Instantiate(Prefab, PlayerController.Instance.transform);
        //prefab.transform and push it
        //createdMissile.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        createdMissile.transform.forward = 
        Debug.Log("Fireball cast");
    }
}
