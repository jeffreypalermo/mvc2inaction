using LoginPortableArea.Login.Messages;
using MvcContrib.PortableAreas;

namespace WebApplication2
{
	public class ForgotPasswordHandler : MessageHandler<ForgotPasswordInputMessage>
	{
		public override void Handle(ForgotPasswordInputMessage message)
		{
			//reset password or send new password.
			message.Result.Message = message.Input.Username + ", your new password is on it's way";
			message.Result.Success = true;
		}
	}
}