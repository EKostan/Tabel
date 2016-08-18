namespace Core.Users.Autentification
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException(string samUserName)
            : base(string.Format("Пользователь {0} не зарегистрирован в системе.", samUserName))
        {
            ErrorCode = "000500";
        }
    }
}
