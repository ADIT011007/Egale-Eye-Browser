using CefSharp;
using CefSharp.Handler;

public class CustomRequestHandler : RequestHandler
{
    private AdBlocker adBlocker;

    public CustomRequestHandler(AdBlocker adBlocker)
    {
        this.adBlocker = adBlocker;
    }

    protected override bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
    {
        string url = request.Url;
        if (adBlocker.ShouldBlockRequest(url))
        {
            // Cancel the request if it should be blocked
            return true;
        }
        return false;
    }
}
