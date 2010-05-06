using LoginPortableArea.Login.Messages;
using MvcContrib.PortableAreas;

namespace WebApplication2
{
	public class LoginHandler : MessageHandler<LoginInputMessage>
	{
		public override void Handle(LoginInputMessage message)
		{
			//check user's credentials to verify good login attempt
			message.Result.Success = true;
			message.Result.Username = message.Input.Username;
		}
	}
}