using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    //Inflinge da�o al player
    
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {

            if (this.GetComponent<SpinComponent>().EnableSpinDamage)
            {
                GameManager.Instance.Loselifes(2);
                GameManager.Instance.SetKnocBackToPlayer(transform.localScale.x);

            }
            else
            {
                GameManager.Instance.Loselifes(1);
                GameManager.Instance.SetKnocBackToPlayer(transform.localScale.x);
            }
            
        }
    }
}
