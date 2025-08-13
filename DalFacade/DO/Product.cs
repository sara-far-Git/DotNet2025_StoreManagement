namespace DO;

/// <summary>
/// 
/// </summary>
/// <param name="id">מספר מזהה יחודי אוטומטי</param>
/// <param name="name">שם מוצר</param>
/// <param name="category">קטגוריה</param>
/// <param name="price">מחיר</param>
/// <param name="count">כמות במלאי</param>
public record Product(int id,string? name,double? price,int? count, Category? category)
{
     
    public Product() : this(0, " ", 0.0, 0,Category.נוף)
    {
        
    }
}
