namespace SimpleIdentityService.Config
{
    public interface IEmailSetting
    {
        string FromAddress { get;  }
        string Server { get;  }
        string Password { get;  }
        string UserName { get; }
    }
}