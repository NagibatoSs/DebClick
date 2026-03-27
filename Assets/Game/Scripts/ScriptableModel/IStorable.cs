using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStorable
{
    public bool Save();
    public bool Load();
}
