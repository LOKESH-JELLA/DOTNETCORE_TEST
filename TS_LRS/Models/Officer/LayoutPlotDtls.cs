using System.ComponentModel.DataAnnotations;

namespace TS_LRS.Models.Officer
{
    public class LayoutPlotDtls
    {
        [Display(Name = "Application No")]
        public string ApplicationID { get; set; } = string.Empty;
        
        public string PlotNo { get; set; } = string.Empty;
        public string ExtentArea { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
        public string UNiid { get; set; } = string.Empty;
        public string EMPid { get; set; } = string.Empty;

        public string TotalPlots { get; set; } = string.Empty;
        public string TotalSoldPlots { get; set; } = string.Empty;
        public string TotalUnsoldPlots { get; set; } = string.Empty;
        public string TotalUnsoldPlotsArea { get; set; } = string.Empty;
    }
}
