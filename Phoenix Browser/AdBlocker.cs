public class AdBlocker
{
    private string[] blockedDomains = {
    // Your existing blocked domains
    "adserver.com", "adservice.com", "adnetwork.net",
    "doubleclick.net", "googleadservices.com", "adchoices.com",
    "adnxs.com", "adtech.com", "adzerk.net", "bidr.io", "bluekai.com",
    "scorecardresearch.com", "quantserve.com", "pubmatic.com",
    "rubiconproject.com", "criteo.com", "adform.com", "2mdn.net", "yieldmo.com",
    "exampledomain1.com", "exampledomain2.com", "newdomain.net",
    "anotherdomain.com", "yourblockedsite.com",
    "blockeddomain1.com", "blockeddomain2.com", "spamdomain.net",
    "annoyingadvertiser.com", "maliciousadsite.com",
    "trackingdomain.net", "intrusivemarketing.com", "blockmeplease.com",
    "stopadvertisements.com", "annoyingadservice.com", "blockthisad.com",
    "nopopupshere.com", "privacyinvader.net", "adblockerkiller.com",
    "toomanypopups.com", "hideyourads.com", "adwarecentral.net",
    "adblockblocker.com", "superannoyingads.com", "endlessadsite.com",
    "adblockersnightmare.com", "neverendingpopups.com", "adwaregalore.net",
    
    // Additional blocked domains
    "annoyingpopups.com", "intrusiveads.net", "spammyadvertiser.com",
    "malware-delivery.com", "popundercentral.net", "adsfordays.com",
    "endlesspopups.com", "trackmyeverymove.com", "clickbaitcentral.net",
    "adtracker101.com", "obnoxiousadnetwork.com", "autoplayvideos.net",
    "toomanybanners.com", "blockmyadsplease.com", "popupmania.com",
    "annoyingadtracker.com", "adspammer.net", "blockmyview.com",
    "stoptrackersnow.com", "adblockertrap.com", "popupsfordays.com",
    
    // Even more blocked domains
    "clickfraudcentral.com", "annoyingretargeting.com", "maliciousmalware.com",
    "spammylinks.net", "adscam.org", "annoyingaffiliate.com",
    "neverendingtracking.com", "popupsrus.com", "phishingpharm.com",
    "adwareinfection.com", "blockmeifyoucan.com", "trackingeverywhere.net",
    "spamemailcollector.com", "adwareinfestation.com", "browserhijacker.net",
    "spammyoffers.com", "adnetworkscam.com", "toomanyspamlinks.com",
    "blockalltelemarketers.com", "trackmeforever.com", "spammydownload.com",
    "adsareviruses.com", "fakeantivirus.net", "dontclickthislink.com",
    
    // Domains you requested to add
    "adtago.s3.amazonaws.com", "static.doubleclick.net", "m.doubleclick.net",
    "mediavisor.doubleclick.net", "ads30.adcolony.com",
    "adc3-launch.adcolony.com", "events3alt.adcolony.com",
    "wd.adcolony.com", "pagead2.googlesyndication.com",
    "afs.googlesyndication.com", "browser.sentry-cdn.com" , "app.getsentry.com",
    
    // Additional domains
    "newdomain1.com", "newdomain2.com", "newdomain3.com",
    "blockmetoo.com", "annoyingpopunders.net", "spammyaffiliate.com",
    "malwarecentral.com", "stoptrackersnow.net", "popupsforlife.com",
    "annoyingadexchange.com", "blockalldownloadlinks.com", "trackingmadness.net",
    "spamsite.com", "adwarehub.net", "blockmenow.com", "popupsgalore.com",
    "stopunwantedads.net", "adtrackersgonebad.com", "blockallthethings.com",
    "adsrus.com", "fakeupdates.net", "popuptime.com", "maliciousdomains.net",
    "annoyingmarketingtactics.com", "blockallscammers.com",
    "trackingintruders.com", "spamsitetwo.com", "adwareinfestation.net",
    "browserhijackeralert.com", "spammyofferscentral.com", "stopspamlinks.com",
    "blockalltelemarketers.net", "forevertracking.com", "downloadblocker.com",
    "stopvirusespread.com", "adsandmoreads.com", "blockalltheclickbait.com",
    "phishingphishing.com", "stopspammers.net", "adsfordays.net","analytics-api.samsunghealthcn.com",
};

    public bool ShouldBlockRequest(string url)
    {
        foreach (string domain in blockedDomains)
        {
            if (url.Contains(domain))
            {
                return true;
            }
        }
        return false;
    }
}
