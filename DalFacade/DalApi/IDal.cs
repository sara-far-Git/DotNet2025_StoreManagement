using DO;


namespace DalApi;

public interface IDal
{
     IClient Client { get; }
     IProduct Product { get; }
     Isale Sale { get; }
}
