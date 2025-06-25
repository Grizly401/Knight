using UnityEngine;

public class ChangeLever : MonoBehaviour
{
    public void SetTrueGrid(GameObject gameObject)
    {
        //gameObject.GetComponent<GridObstacles>().GridState = true;
        gameObject.SetActive(true);
    }

    public void SetFalseGrid(GameObject gameObject)
    {
        //gameObject.GetComponent<GridObstacles>().GridState = false;
        gameObject.SetActive(false);
    }

}
