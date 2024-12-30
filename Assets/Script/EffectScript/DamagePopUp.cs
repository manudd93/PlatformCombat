using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopUp : MonoBehaviour
{
    float disappearTime;
        private Color textColor;
    public static DamagePopUp Create(Vector3 position,int DamageAmount)
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        GameObject damagePopUpGameObject = Instantiate(gameManager.damagePop, position, Quaternion.identity);
        DamagePopUp DamagePop = damagePopUpGameObject.GetComponent<DamagePopUp>();

        DamagePop.SetText(DamageAmount);
        return DamagePop;
    }
    private TextMeshPro textMesh;
    // Start is called before the first frame update
 
     void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        //+Random.Range(1, 20),
        float MoveSpeed = 2f;
        transform.position += new Vector3(0, MoveSpeed,0) * Time.deltaTime;
        
        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            float disapperSpeed = 3f;
            textColor.a -= disapperSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
    public void SetText(int Damage)
    {
        textMesh.SetText(Damage.ToString());
        textColor = textMesh.color;
    }
}
