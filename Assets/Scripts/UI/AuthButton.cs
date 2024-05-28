public class AuthButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        Web.AuthAccount();

        base.OnButtonClick();
    }
}
