/* File: PS_DOC_HDR_MISC_CHRG_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_HDR_MISC_CHRG_Model
    {
        public string TOT_TYP { get; set; }
        public int MISC_CHRG_NO { get; set; }
        public string MISC_TYP { get; set; }
        public decimal MISC_AMT { get; set; }
        public decimal MISC_PCT { get; set; }
        public decimal MISC_TAX_AMT_ALLOC { get; set; }
        public decimal MISC_NORM_TAX_AMT_ALLOC { get; set; }
    }
}
