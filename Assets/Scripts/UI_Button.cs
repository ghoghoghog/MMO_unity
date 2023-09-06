using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UI_Button : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, Object[]>();

    private int _score = 0;

    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log($"name : {names[i]}");
            objects[i] = FindChild<T>(gameObject, names[i], true);
        }
    }

    public Object FindChild<T>(GameObject go, string name = null , bool recursive = false)where T: Object
    {
        throw new NotImplementedException();
    }

    public void OnButtonClicked()
    {
        _score++;
        //_text.text = $"score :" + _score;
    }
}
