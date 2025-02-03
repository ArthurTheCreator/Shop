namespace Arguments.Arguments.Base.DTO;

public class BaseInputIdentityView<TInputIdentityViewDTO> where TInputIdentityViewDTO : BaseInputIdentityView<TInputIdentityViewDTO>, IHashId { }
public class BaseInputIdentityView_0 : BaseInputIdentityView<BaseInputIdentityView_0>, IHashId
{
    public long Id { get; private set; }
}