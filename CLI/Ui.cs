namespace CLI;

public class Ui : LastPass.Ui
{
    private readonly string[] _args;

    public Ui(string[] args)
    {
        _args = args;
    }

    public override string ProvideSecondFactorPassword(SecondFactorMethod method)
    {
        if (_args.Length > 2)
        {
            return _args[2];
        }
        else
        {
            return Helpers.Prompt(string.Format("Please enter {0} code", method));
        }
    }

    public override void AskToApproveOutOfBand(OutOfBandMethod method)
    {
        Console.WriteLine("Please approve out-of-band via {0}", method);
    }
}
