namespace DO;

using DalApi;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
/// <param name="tz">ת"ז לקוח</param>
/// <param name="name">שם לקוח</param>
/// <param name="address">כתובת לקוח</param>
/// <param name="phone">טלפון</param>
public record Client(int tz,string? name,string? address,int phone)
{
    public Client():this(0,"","",0)
    {
    }
}
