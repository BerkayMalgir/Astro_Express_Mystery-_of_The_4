using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   [SerializeField] private Texture2D cursorTexture;

   private Vector2 _cursorHotspot;

   private void Start()
   {
      _cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
      Cursor.SetCursor(cursorTexture,_cursorHotspot,CursorMode.Auto);
   }
}
