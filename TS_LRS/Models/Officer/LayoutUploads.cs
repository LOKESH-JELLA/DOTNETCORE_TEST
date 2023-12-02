using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TS_LRS.Models.Officer
{
    public class LayoutUploads
    {
        public string layoutcopyDoc { get; set; } = string.Empty;
        public string ownershipDoc { get; set; } = string.Empty;
        public string encumbranceCertifiDoc { get; set; } = string.Empty;
        public string otherdocs { get; set; } = string.Empty;
        public string IsUnsoldplotDtls { get; set; } = string.Empty;

        [Display(Name = "Application No")]
        public string ApplicationId { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string TotalunsoldArea { get; set; } = string.Empty;
        public string UniRefID { get; set; } = string.Empty;
        public string Image1 { get; set; } = string.Empty;
        public string Image2 { get; set; } = string.Empty;
        public string Image3 { get; set; } = string.Empty;
        public string PlotArea { get; set; } = string.Empty;
        public string PlotArea_NEW { get; set; } = string.Empty;
        public string ROAD_PlotArea { get; set; } = string.Empty;
        public string PlotNo { get; set; } = string.Empty;
        public string BOUNDARIES_LAYOUT { get; set; } = string.Empty;
        public string ROAD_EXISTING { get; set; } = string.Empty;
        public string WIDTH_ROAD_EXISTING { get; set; } = string.Empty;
        public string SRDP_RDP { get; set; } = string.Empty;
        public string PLOT_OPENSPACE { get; set; } = string.Empty;
        public string LAYOUTNAME { get; set; } = string.Empty;

        [Display(Name = "Applicant Name")]
        public string LAYOUTOWNERNAME { get; set; } = string.Empty;
        public string OWNERMOBILE { get; set; } = string.Empty;
        public string TOTALPLOTS { get; set; } = string.Empty;
        public string FTL { get; set; } = string.Empty;
        public string PROHIBITED { get; set; } = string.Empty;
        public string HIGHTEN { get; set; } = string.Empty;
        public string MasterPlan_ZDP { get; set; } = string.Empty;
        public string OthersZdp { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string Citizen_Remarks { get; set; } = string.Empty;
        public string L1_CONDITION { get; set; } = string.Empty;
        public string SRO_CODE { get; set; } = string.Empty;
        public string STATUSID { get; set; } = string.Empty;


    }
}
