﻿using DO;

namespace DalApi;
public delegate Func<T,bool> filter<T>();

public interface ICrud<T>
{
    int Create(T item);
    T? Read(int id);
    List<T?> ReadAll(Func<T,bool>? filter=null);
    void Update(T item);
    void Delete(int id);
    T? Read(Func<T,bool>? filter);
}
