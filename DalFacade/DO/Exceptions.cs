

namespace DO;

[Serializable]
public class DalNotFound : Exception
{
    public DalNotFound(string message) : base(message) { }
}


[Serializable]
public class DalFound : Exception
{
    public DalFound(string message) : base(message) { }
}

