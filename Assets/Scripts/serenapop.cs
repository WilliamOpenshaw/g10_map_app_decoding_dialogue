using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class serenapop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
public float sX;
public float sY;
public float sZ;
public void Start()
{
sX = gameObject.transform.localScale.x;
sY = gameObject.transform.localScale.y;
sZ = gameObject.transform.localScale.z;
}
{
public float sX;
public float sY;
Debug.Log("The cursor EXITED the selectable UI element.");
gameObject.transform.localScale = new Vector3( sX, sY, sZ );
}
public void OnPointerEnter(PointerEventData eventData)
{
Debug.Log("The cursor entered the selectable UI element.");
gameObject.transform.localScale = new Vector3( sX * 2, sY * 2 , sZ * 2 );   
}