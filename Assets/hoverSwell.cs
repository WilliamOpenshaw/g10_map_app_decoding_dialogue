using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class hoverSwell : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler// required interface when using the OnPointerEnter method.
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
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerExit(PointerEventData eventData2)
    {
        Debug.Log("The cursor EXITED the selectable UI element.");
        gameObject.transform.localScale = new Vector3(  sX, sY, sZ );
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        gameObject.transform.localScale = new Vector3(  sX * 2, sY * 2 , sZ * 2 );
    }

    
}

