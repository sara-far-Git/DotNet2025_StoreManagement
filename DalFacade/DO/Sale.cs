namespace DO;

/// <summary>
/// 
/// </summary>
/// <param name="productId">מזהה מוצר</param>
/// /// <param name="id_uniqe">מספר רץ אוטומטי </param>
/// <param name="priceSale">כמות נדרשת למבצע</param>
/// <param name="allSale">מחיר כולל במבצע</param>
/// <param name="amount">מבצע למועדון או לא</param>
/// <param name="dateStart">התחלת המבצע  </param>
/// /// <param name="dateEnd">תאריך סוף המבצע</param>
public record Sale(int productId,int id_uniqe, int priceSale,bool allSale,DateTime dateStart,DateTime? dateEnd= null,double ? amount = null)
{
    
    public Sale():this(0,0,0,false,DateTime.Now,null)
    {
        
    }
}
