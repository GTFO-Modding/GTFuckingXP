namespace GTFuckingXP.Information.WebModels
{
    public class XpWebModel
    {
        public XpWebModel(TermsOfUsage howToHandleData)
        {
            if(howToHandleData == TermsOfUsage.Accepted)
            {
                SteamId = SteamManager.LocalPlayerID.ToString();
                PlayFabId = PlayFabManager.EntityID;
                NickName = SteamManager.LocalPlayerName;
            }
            else if(howToHandleData == TermsOfUsage.Anonymized)
            {
                SteamId = "Unknown";
                PlayFabId = "Unknown";
                NickName = "Unknown";
            }
            else
            {
                throw new System.Exception("You should not create a data package if there is no consent!");
            }
        }

        public string SteamId { get; set; }
        public string PlayFabId { get; set; }
        public string NickName { get; set; }
    }
}
