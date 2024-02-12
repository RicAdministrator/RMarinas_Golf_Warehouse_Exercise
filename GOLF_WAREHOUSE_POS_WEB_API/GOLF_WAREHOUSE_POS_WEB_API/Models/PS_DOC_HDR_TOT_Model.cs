/* File: PS_DOC_HDR_TOT_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_HDR_TOT_Model
    {
        public string TOT_TYP {  get; set; }
        public string HAS_TAX_OVRD { get; set; }
        public int? LINS { get; set; }
        public decimal SUB_TOT { get; set; }
        public int TAX_OVRD_LINS { get; set; }
        public decimal? TOT_EXT_COST { get; set; }
        public decimal TOT_MISC { get; set; }
        public decimal TAX_AMT { get; set; }
        public decimal NORM_TAX_AMT { get; set; }
        public decimal TOT_TND { get; set; }
        public decimal TOT_CHNG { get; set; }
        public decimal TOT_WEIGHT { get; set; }
        public decimal TOT_CUBE { get; set; }
        public decimal TOT_HDR_DISC { get; set; }
        public decimal TOT_LIN_DISC { get; set; }
        public decimal TOT_HDR_DISCNTBL_AMT { get; set; }
        public decimal TOT_TIP_AMT { get; set; }
    }
}
