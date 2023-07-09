using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    #region Instanza
    public static Inventario current;

    public void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    [Header("Ingredienti")]
    public int patate;
    public int pomodori;
    public int carote;
    
   
}