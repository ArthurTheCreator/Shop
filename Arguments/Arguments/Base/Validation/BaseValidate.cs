namespace Arguments.Arguments.Base;

public class BaseValidate
{
    public bool Invalid { get; private set; }

    public bool SetInvalid()
    {
        return Invalid = true;
    }
}
